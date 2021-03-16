using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Mountain_Tracker_Climb___API.Helpers
{
    internal static class ControllerHelper
    {
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

        public static HttpResponseMessage MakeHttpGenericSQLErrorResposnse(SqlException e)
        {
            HttpResponseMessage ErrorResposnse;
            if (e.Message.StartsWith("Violation of UNIQUE KEY constraint"))
            {
                int StartIndex = e.Message.IndexOf("(") + 1;
                int Length = e.Message.IndexOf(")") - StartIndex;
                string ErrorString = $"The unique value already exists. {e.Message.Substring(StartIndex, Length)} already exists!";
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
                int Length = e.Message.IndexOf("_", StartIndex) - StartIndex;
                string ErrorString = $"The delete confilicted existing dependant data.\n{e.Message.Substring(StartIndex, Length)} has dependant data that you would need to delete first!";
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
                    ReasonPhrase = ErrorString
                };
            }
            return ErrorResposnse;
        }
    }
}