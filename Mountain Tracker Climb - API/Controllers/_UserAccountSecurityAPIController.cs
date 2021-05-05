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
using Mountain_Tracker_Climb___API.Security;
using System.Data.SqlClient;
using Mountain_Tracker_Climb___API.App_Start;

namespace Mountain_Tracker_Climb___API.Controllers
{
    public class UserAccountSecurityController : ApiController
    {

        [NonAction]
        void EnsureOwnerShip(int id)
        {
            this.EnsureOwnerShip(id, null);
        }

        [APISecurityLevel()]
        [HttpPut]
        public void Put(int id, [FromBody]UserPasswordChange Values)
        {
            ControllerHelper.ClearObjectsEmptyStrings(Values);
            ControllerHelper.CheckObjectForPutErrorException(Values);

            EnsureOwnerShip(id);

            UserFullWithSecurity User;
            using (DBContext DB = new DBContext())
            {
                User = DB.UserTable.GetUser(id);
            }

            
            string HashedOldPassword = SecurityHelper.PasswordToSaltedHash(Values.OldPassword, User.Salt);
            if (HashedOldPassword == User.HashedPassword)
            {
                string NewSalt = SecurityHelper.GetCode();
                User = new UserFullWithSecurity()
                {
                    Salt = NewSalt,
                    HashedPassword = SecurityHelper.PasswordToSaltedHash(Values.NewPassword, NewSalt)
                };

                try
                {
                    using (DBContext DB = new DBContext())
                        DB.UserTable.UpdateUser(id, User);
                }
                catch (SqlException e)
                {
                    throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
                }
            }
            else
            {
                const string Error = "Your old password does not match your current password.";
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = Error,
                    Content = new StringContent(Error)
                });
            }
        }

        [HttpGet]
        [Route("api/UserAccountSecurity/ForgotPassword")]
        public void GetForgotPassword(string Email)
        {
                const string Error = "API end point has not been fully implemented yet.";
                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.MethodNotAllowed,
                    ReasonPhrase = Error,
                    Content = new StringContent(Error)
                });

        }

        [HttpGet]
        [Route("api/UserAccountSecurity/ForgotUserName")]
        public void GetForgotUserName(string Email)
        {
            const string Error = "API end point has not been fully implemented yet.";
            throw new HttpResponseException(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.MethodNotAllowed,
                ReasonPhrase = Error,
                Content = new StringContent(Error)
            });
        }

    }
}