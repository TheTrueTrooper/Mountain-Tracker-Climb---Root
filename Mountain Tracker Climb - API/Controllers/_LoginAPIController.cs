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

namespace Mountain_Tracker_Climb___API.Controllers.API
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public UserLoginReturn Post([FromBody] UserLogin Values)
        {
            ControllerHelper.ClearObjectsEmptyStrings(Values);
            ControllerHelper.CheckObjectForPostErrorException(Values);
            UserLoginReturn Return;
            try
            {
                using (DBContext DB = new DBContext())
                    Return = DB.UserTable.LoginPhone(Values);
            }
            catch
            {
                const string ErrorString = "Login has failed due to a internal issue. Please try again later or contact the help desk.";
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Content = new StringContent(ErrorString),
                    ReasonPhrase = ErrorString,
                });
            }
            if (Return == null)
            {
                const string ErrorString = "Login has failed due to either your password or user name being incorect. Please check both and then try again.";
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent(ErrorString),
                    ReasonPhrase = ErrorString,
                });
            }

            return Return;
        }

        //[HttpPut]
        //public void Post([FromBody] UserPasswordChange Values)
        //{

        //}

    }
}