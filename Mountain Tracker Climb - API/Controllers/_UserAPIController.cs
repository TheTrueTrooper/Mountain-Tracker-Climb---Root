using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MTCSharedModels.Models;
using Mountain_Tracker_Climb___API.Models;
using Mountain_Tracker_Climb___API.DBModelContexts;
using Mountain_Tracker_Climb___API.Helpers;
using System.Data.SqlClient;

namespace Mountain_Tracker_Climb___API.Controllers
{
    public class AccountController : ApiController
    {
        [NonAction]
        static HttpResponseMessage GenerateHttpSQLGenericExceptionMessage(SqlException e)
        {
            HttpResponseMessage ErrorResposnse;
            if (e.Message.StartsWith("Violation of UNIQUE KEY constraint"))
            {
                int StartIndex = e.Message.IndexOf("(") + 1;
                int Length = e.Message.IndexOf(")") - StartIndex;
                string ErrorString = $"The a unique value on Account already exists.\n{e.Message.Substring(StartIndex, Length)} already exists.\nIf you require help please contact the help desk.";
                ErrorResposnse = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    StatusCode = HttpStatusCode.Conflict,
                    Content = new StringContent(ErrorString),
                    ReasonPhrase = ErrorString.Replace('\n', ' ')
                };
            }
            else
                ErrorResposnse = ControllerHelper.MakeHttpUnknownErrorResposnse();
            return ErrorResposnse;
        }

        [NonAction]
        static HttpResponseMessage GenerateHttpTooShortPasswordExceptionMessage()
        {
            const string ErrorReason = "Password was too short. Please include that is at least 8 chars long a password for your accounts security!";
            return new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(ErrorReason),
                ReasonPhrase = ErrorReason
            };
        }

        [NonAction]
        static HttpResponseMessage GenerateHttpNoPasswordExceptionMessage()
        {
            const string ErrorReason = "Password was not included. Please include that is at least 8 chars long a password for your accounts security!";
            return new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(ErrorReason),
                ReasonPhrase = ErrorReason
            };
        }


        [HttpGet]
        public UserFull Get(int id)
        {
            using (DBContext DB = new DBContext())
                return DB.UserTable.GetUser(id);
        }

        [HttpPost]
        public void Post([FromBody] UserFull Values)
        {
            HttpResponseMessage ErrorResposnse = null;
            UserFullWithSecurity NewUser = new UserFullWithSecurity() { 
                UserName = Values.UserName, 
                Password = Values.Password,
                FirstName = Values.FirstName, 
                MiddleName = Values.MiddleName, 
                LastName = Values.LastName, 
                PrimaryPersonalEmail = Values.PrimaryPersonalEmail, 
                PrimaryPhone = Values.PrimaryPhone};
            if (Values.Password != null)
            {
                if (Values.Password.Length >= 8)
                {
                    NewUser.Salt = SecurityHelper.GetCode();
                    NewUser.HashedPassword = SecurityHelper.PasswordToSaltedHash(NewUser.Password, NewUser.Salt);
                }
                else
                {
                    ErrorResposnse = GenerateHttpTooShortPasswordExceptionMessage();
                }
            }
            else
            {
                ErrorResposnse = GenerateHttpNoPasswordExceptionMessage();
            }
            if(ErrorResposnse!= null)
                throw new HttpResponseException(ErrorResposnse);
            try
            {
                using (DBContext DB = new DBContext())
                    DB.UserTable.AddUser(NewUser);
            }
            catch(SqlException e)
            {
                throw new HttpResponseException(GenerateHttpSQLGenericExceptionMessage(e));
            }
        }

        [HttpPut]
        public void Post(int id, [FromBody] UserFull Values)
        {
            HttpResponseMessage ErrorResposnse = null;
            UserFullWithSecurity NewUser = new UserFullWithSecurity()
            {
                UserName = Values.UserName,
                Password = Values.Password,
                FirstName = Values.FirstName,
                MiddleName = Values.MiddleName,
                LastName = Values.LastName,
                PrimaryPersonalEmail = Values.PrimaryPersonalEmail,
                PrimaryPhone = Values.PrimaryPhone,
            };
            if (Values.Password != null)
            {
                if (Values.Password.Length >= 8)
                {
                    NewUser.Salt = SecurityHelper.GetCode();
                    NewUser.HashedPassword = SecurityHelper.PasswordToSaltedHash(NewUser.Password, NewUser.Salt);
                }
                else
                {
                    ErrorResposnse = GenerateHttpTooShortPasswordExceptionMessage();
                }
            }
            try 
            { 
                using (DBContext DB = new DBContext())
                    DB.UserTable.UpdateUser(id, NewUser);
            }
            catch(SqlException e)
            {
                throw new HttpResponseException(GenerateHttpSQLGenericExceptionMessage(e));
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                using (DBContext DB = new DBContext())
                    DB.UserTable.DeleteUser(id);
            }
            catch(SqlException e)
            {
                throw new HttpResponseException(GenerateHttpSQLGenericExceptionMessage(e));
            }
        }
    }
}