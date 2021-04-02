using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using MTCSharedModels.Models;
using MTCSharedModels.Models.Interfaces;

namespace Mountain_Tracker_Climb___API.Helpers
{
    internal static class ControllerHelper
    {
        public static void ClearObjectsEmptyStrings<T>(T obj)
        {
            if (obj == null)
                return;
            Type OType = typeof(T);
            PropertyInfo[] Properties = OType.GetProperties();
            foreach (PropertyInfo P in Properties)
            {
                if(P.PropertyType == typeof(string))
                {
                    string Value = (string)P.GetValue(obj);
                    if (Value != null && Value.Trim().Length == 0)
                        P.SetValue(obj, null);
                }
            }
        }

        public static List<string> CheckObjectForPutErrors<T>(T obj)
        {
            return CheckObjectForErrors(obj, true);
        }

        public static List<string> CheckObjectForPostErrors<T>(T obj)
        {
            return CheckObjectForErrors(obj, false);
        }

        private static List<string> CheckObjectForErrors<T>(T obj, bool SkipPostErrors)
        {
            if (obj == null)
                return new List<string>() { "Root:You have failed to provide any of the required parameters. Please check with the documentation for usage.;" };
            List<string> Errors = new List<string>();
            Type OType = typeof(T);
            PropertyInfo[] Properties = OType.GetProperties();
            foreach(PropertyInfo P in Properties)
            {
                if (!SkipPostErrors)
                {
                    if (Attribute.IsDefined(P, typeof(APIPostRequiredAttribute)))
                    {
                        if (P.GetValue(obj) == null)
                        {
                            APIPostRequiredAttribute ErrorAttribute = (APIPostRequiredAttribute)Attribute.GetCustomAttribute(P, typeof(APIPostRequiredAttribute));
                            Errors.Add(ErrorAttribute.ErrorMessage);
                        }
                    }
                }
                if (Attribute.IsDefined(P, typeof(APIAlwaysRequiredAttribute)))
                {
                    if (P.GetValue(obj) == null)
                    {
                        APIAlwaysRequiredAttribute ErrorAttribute = (APIAlwaysRequiredAttribute)Attribute.GetCustomAttribute(P, typeof(APIAlwaysRequiredAttribute));
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                }
                if (Attribute.IsDefined(P, typeof(APIMinimumLengthAttribute)))
                {
                    if (P.PropertyType.Name != typeof(string).Name)
                        throw new Exception($"You have applied the 'APICreationRequiredAttribute' to a non supported type in the \nClass {OType.Name} above the {P.Name} property. \nSupported types include the following: strings");

                    APIMinimumLengthAttribute ErrorAttribute = (APIMinimumLengthAttribute)Attribute.GetCustomAttribute(P, typeof(APIMinimumLengthAttribute));
                    string Value = (string)P.GetValue(obj);
                    if (Value != null && Value.Length < ErrorAttribute.Minimum)
                    {       
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                }
                if (Attribute.IsDefined(P, typeof(APIMaximumLengthAttribute)))
                {
                    if (P.PropertyType.Name != typeof(string).Name)
                        throw new Exception($"You have applied the 'APICreationRequiredAttribute' to a non supported type in the \nClass {OType.Name} above the {P.Name} property. \nSupported types include the following: strings");

                    APIMaximumLengthAttribute ErrorAttribute = (APIMaximumLengthAttribute)Attribute.GetCustomAttribute(P, typeof(APIMaximumLengthAttribute));
                    string Value = (string)P.GetValue(obj);
                    if (Value != null && Value.Length > ErrorAttribute.Maximum)
                    {
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                }
                if (Attribute.IsDefined(P, typeof(APIMinimumAttribute)))
                {
                    if (P.PropertyType.Name != typeof(int).Name && P.PropertyType.Name != typeof(short).Name && P.PropertyType.Name != typeof(byte).Name && P.PropertyType.Name != typeof(double).Name && P.PropertyType.Name != typeof(float).Name)
                        throw new Exception($"You have applied the 'APIMinimumAttribute' to a non supported type in the \nClass {OType.Name} above the {P.Name} property. \nSupported types include the following: int, short, byte, double, float");

                    APIMinimumAttribute ErrorAttribute = (APIMinimumAttribute)Attribute.GetCustomAttribute(P, typeof(APIMinimumAttribute));
                    object Value = P.GetValue(obj);

                    if (Value != null && (Value is int || Value is short || Value is byte) && Convert.ToDouble((int)Value) < ErrorAttribute.Minimum)
                    {
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                    else if (Value != null && Value is float && Convert.ToDouble((float)Value) < ErrorAttribute.Minimum)
                    {
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                    else if (Value != null && Value is double && (double)Value < ErrorAttribute.Minimum)
                    {
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                }
                if (Attribute.IsDefined(P, typeof(APIMaximumAttribute)))
                {
                    if (P.PropertyType.Name != typeof(int).Name && P.PropertyType.Name != typeof(short).Name && P.PropertyType.Name != typeof(byte).Name && P.PropertyType.Name != typeof(double).Name && P.PropertyType.Name != typeof(float).Name)
                        throw new Exception($"You have applied the 'APIMaximumAttribute' to a non supported type in the \nClass {OType.Name} above the {P.Name} property. \nSupported types include the following: int, short, byte, double, float");

                    APIMaximumAttribute ErrorAttribute = (APIMaximumAttribute)Attribute.GetCustomAttribute(P, typeof(APIMaximumAttribute));
                    object Value = P.GetValue(obj);

                    if (Value != null && (Value is int || Value is short || Value is byte) && Convert.ToDouble((int)Value) > ErrorAttribute.Maximum)
                    {
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                    else if (Value != null && Value is float && Convert.ToDouble((float)Value) > ErrorAttribute.Maximum)
                    {
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                    else if (Value != null && Value is double && (double)Value > ErrorAttribute.Maximum)
                    {
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                }
                if (Attribute.IsDefined(P, typeof(APIMinimumAttribute)))
                {
                    if (P.PropertyType.Name != typeof(int).Name && P.PropertyType.Name != typeof(short).Name && P.PropertyType.Name != typeof(byte).Name && P.PropertyType.Name != typeof(double).Name && P.PropertyType.Name != typeof(float).Name)
                        throw new Exception($"You have applied the 'APIMinimumAttribute' to a non supported type in the \nClass {OType.Name} above the {P.Name} property. \nSupported types include the following: int, short, byte, double, float");

                    APIMinimumAttribute ErrorAttribute = (APIMinimumAttribute)Attribute.GetCustomAttribute(P, typeof(APIMinimumAttribute));
                    object Value = P.GetValue(obj);

                    if (Value != null && (Value is int || Value is short || Value is byte) && Convert.ToDouble((int)Value) < ErrorAttribute.Minimum)
                    {
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                    else if (Value != null && Value is float && Convert.ToDouble((float)Value) < ErrorAttribute.Minimum)
                    {
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                    else if (Value != null && Value is double && (double)Value < ErrorAttribute.Minimum)
                    {
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                }
                if (Attribute.IsDefined(P, typeof(APIRegexCheckAttribute)))
                {
                    if (P.PropertyType.Name != typeof(string).Name)
                        throw new Exception($"You have applied the 'APIRegexCheckAttribute' to a non supported type in the \nClass {OType.Name} above the {P.Name} property. \nSupported types include the following: string");

                    APIRegexCheckAttribute ErrorAttribute = (APIRegexCheckAttribute)Attribute.GetCustomAttribute(P, typeof(APIRegexCheckAttribute));
                    string Value = (string)P.GetValue(obj);

                    if (Value != null && !Regex.IsMatch(Value, ErrorAttribute.Regex))
                    {
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                }
                //String theEmailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                //+"@"
                //+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";
                if (Attribute.IsDefined(P, typeof(APIEmailAttribute)))
                {
                    if (P.PropertyType.Name != typeof(string).Name)
                        throw new Exception($"You have applied the 'APIEmailAttribute' to a non supported type in the \nClass {OType.Name} above the {P.Name} property. \nSupported types include the following: string");
                    string Value = (string)P.GetValue(obj);
                    if (Value != null && !RegexHelpers.ValidEmailCheck(Value))
                    {
                        APIEmailAttribute ErrorAttribute = (APIEmailAttribute)Attribute.GetCustomAttribute(P, typeof(APIEmailAttribute));
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                }
                if (Attribute.IsDefined(P, typeof(APIPhoneNumberAttribute)))
                {
                    if (P.PropertyType.Name != typeof(string).Name)
                        throw new Exception($"You have applied the 'APIPhoneNumberAttribute' to a non supported type in the \nClass {OType.Name} above the {P.Name} property. \nSupported types include the following: string");
                    string Value = (string)P.GetValue(obj);
                    if (Value != null && (!RegexHelpers.ValidNANPPhoneNumberWithWorldZone(Value)/*|| other world code checks*/))
                    {
                        APIPhoneNumberAttribute ErrorAttribute = (APIPhoneNumberAttribute)Attribute.GetCustomAttribute(P, typeof(APIPhoneNumberAttribute));
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                }
                if (Attribute.IsDefined(P, typeof(APIIllegalCharsAttribute)))
                {
                    if (P.PropertyType.Name != typeof(string).Name)
                        throw new Exception($"You have applied the 'APIIllegalCharsAttribute' to a non supported type in the \nClass {OType.Name} above the {P.Name} property. \nSupported types include the following: string");

                    APIIllegalCharsAttribute ErrorAttribute = (APIIllegalCharsAttribute)Attribute.GetCustomAttribute(P, typeof(APIIllegalCharsAttribute));
                    string Value = (string)P.GetValue(obj);

                    if (Value != null && ErrorAttribute.IllegalChars.Any(x=>Value.Contains(x)))
                    {
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                }
                if (Attribute.IsDefined(P, typeof(APIMatchingFieldAttribute)))
                {

                    APIMatchingFieldAttribute ErrorAttribute = (APIMatchingFieldAttribute)Attribute.GetCustomAttribute(P, typeof(APIMatchingFieldAttribute));

                    PropertyInfo MatchingField = OType.GetProperty(ErrorAttribute.FieldName);
                    if (MatchingField == null)
                        throw new Exception($"The field to match is not defined. Please check your names.");
                    if (P.PropertyType.Name != MatchingField.PropertyType.Name)
                        throw new Exception($"The Property types do not match");
                    object Value = P.GetValue(obj);
                    object Value2 = MatchingField.GetValue(obj);
                    if (Value != null && !Value.Equals(Value2))
                    {
                        Errors.Add(ErrorAttribute.ErrorMessage);
                    }
                }
            }
            if (Errors.Count() != 0)
                return Errors;
            return null;
        }

        

        public static bool CheckEmail(string Value)
        {
            return Regex.IsMatch(Value, "");
        }

        private static HttpResponseMessage CheckObjectForErrorResponse<T>(T obj, bool SkipPostErrors)
        {
            List<string> Errors = CheckObjectForErrors(obj, SkipPostErrors);
            if (Errors != null)
            {
                HttpResponseMessage ErrorResposnse = new HttpResponseMessage(HttpStatusCode.BadRequest);
                string ErrorMessage = "The following errors were detected:";
                foreach (string Error in Errors)
                {
                    ErrorMessage += Error;
                }
                ErrorResposnse.StatusCode = HttpStatusCode.BadRequest;
                ErrorResposnse.Content = new StringContent(ErrorMessage.Replace(";", "\n"));
                if (ErrorMessage.Length > 512)
                    ErrorMessage = ErrorMessage.Substring(0, 512);
                ErrorResposnse.ReasonPhrase = ErrorMessage;
                return ErrorResposnse;
            }
            return null;
        }

        public static HttpResponseMessage CheckObjectForPostErrorResponse<T>(T obj)
        {
            return CheckObjectForErrorResponse(obj, false);
        }

        public static HttpResponseMessage CheckObjectForPutErrorResponse<T>(T obj)
        {
            return CheckObjectForErrorResponse(obj, true);
        }

        private static void CheckObjectForErrorException<T>(T obj, bool SkipPostErrors)
        {
            HttpResponseMessage Errors = CheckObjectForErrorResponse(obj, SkipPostErrors);
            if (Errors != null)
                throw new HttpResponseException(Errors);
        }

        public static void CheckObjectForPostErrorException<T>(T obj)
        {
            CheckObjectForErrorException(obj, false);
        }

        public static void CheckObjectForPutErrorException<T>(T obj)
        {
            CheckObjectForErrorException(obj, true);
        }

        public static HttpResponseMessage MakeHttpUnknownErrorResposnse()
        {
            const string ErrorString = "A unknown error has occured.";
            return new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent(ErrorString),
                ReasonPhrase = ErrorString
            };
        }

        public static HttpResponseMessage MakeHttpGenericSQLErrorResposnse(SqlException e, string Add = "!")
        {
            HttpResponseMessage ErrorResposnse;
            if (e.Message.StartsWith("Violation of UNIQUE KEY constraint"))
            {
                int StartIndex = e.Message.IndexOf("_") + 1;
                int Length = e.Message.IndexOf("'", StartIndex) - StartIndex;
                string ErrorString = $"The unique value already exists. {e.Message.Substring(StartIndex, Length)} already exists{Add}";
                ErrorResposnse = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    StatusCode = HttpStatusCode.Conflict,
                    Content = new StringContent(ErrorString),
                    ReasonPhrase = ErrorString
                };
            }
            else if (e.Message.StartsWith("The DELETE statement conflicted with the REFERENCE constraint"))
            {
                int StartIndex = e.Message.IndexOf("_") + 1;
                //StartIndex = e.Message.IndexOf("_", StartIndex) + 1;
                int Length = e.Message.IndexOf("_", StartIndex) - StartIndex;
                string ErrorString = $"The delete confilicted existing dependant data.\n{e.Message.Substring(StartIndex, Length)} has dependant data that you would need to delete first{Add}";
                ErrorResposnse = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    StatusCode = HttpStatusCode.Conflict,
                    Content = new StringContent(ErrorString),
                    ReasonPhrase = ErrorString.Replace('\n', ' ')
            };
            }
            else
            {
                const string ErrorString = "A unknown error has occured durring SQL execution.";
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(ErrorString),
                    ReasonPhrase = ErrorString,
                };
            }
            return ErrorResposnse;
        }

        public static HttpResponseMessage GeneratePNGImageResponse(IPictureBytes Picture)
        {
            HttpResponseMessage Result = new HttpResponseMessage(HttpStatusCode.OK);
            Result.Content = new ByteArrayContent(Picture.PictureRawBytes);
            Result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return Result;
        }

        public static async Task<MemoryStream> LoadFileToMemoryAsync(string Path)
        {
            MemoryStream Result = new MemoryStream();
            using (Stream Reader = File.Open(Path, FileMode.Open, FileAccess.Read))
            {
                await Reader.CopyToAsync(Result);
            }
            return Result;
        }

        public static string MapVirtualPath(string VirtualPath)
        {
            return HttpContext.Current.Server.MapPath(VirtualPath);
        }
    }
}