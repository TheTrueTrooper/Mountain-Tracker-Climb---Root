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
    [APISecurityLevel()]
    public class UserAccountController : ApiController
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
                ErrorResposnse = ControllerHelper.MakeHttpUnknownErrorResposnse();
            return ErrorResposnse;
        }

        [HttpGet]
        public object Get(int id)
        {
            UserFullWithSecurity User;
            using (DBContext DB = new DBContext())
            {
                User = DB.UserTable.GetUser(id);

                if (User == null)
                    return "No user found!";

                /*(0, 'Unrestricted Admin'),
(1, 'Admin'),
(2, 'Moderater'),
(3, 'Guide'),
(4, 'PayedUser'),
(5, 'User');*/

                //will check if it is user
                object CurrentUserIDBoxed;
                Request.Properties.TryGetValue(StaticVars.UserIDRequestProperty, out CurrentUserIDBoxed);
                object AccessLevelIDBoxed;
                Request.Properties.TryGetValue(StaticVars.AccessLevelIDProperty, out AccessLevelIDBoxed);
                if (CurrentUserIDBoxed != null && ((int)CurrentUserIDBoxed  == User.ID || (int)CurrentUserIDBoxed <= APISecurityLevelAttribute.AccessLevels["Moderater"]))
                    return new UserFull()
                    {
                        ID = User.ID,
                        BannerPicturePath = User.BannerPicturePath,
                        ProfilePicturePath = User.ProfilePicturePath,
                        UserName = User.UserName,
                        KeepPrivate = User.KeepPrivate,
                        FirstName = User.FirstName,
                        MiddleName = User.MiddleName,
                        LastName = User.LastName,
                        ProfileURL = User.ProfileURL,
                        Bio = User.Bio,
                        AccessLevelID = User.AccessLevelID,
                        UserAccessLevel = DB.UserAccessLevelTable.GetUserAccessLevel(User.AccessLevelID.Value),
                        EmailValidated = User.EmailValidated,
                        PhoneValidated = User.PhoneValidated,
                        PrimaryPersonalEmail = User.PrimaryPersonalEmail,
                        PrimaryPhone = User.PrimaryPhone
                        //leave password null as it is only for setting it in a update
                    };
            }
            //if ir is not the user there are two states based on if it is private or not.
            if (User.KeepPrivate.Value)
                return new UserInfoPrivate()
                {
                    ID = User.ID,
                    BannerPicturePath = User.BannerPicturePath,
                    ProfilePicturePath = User.ProfilePicturePath,
                    UserName = User.UserName,
                    KeepPrivate = User.KeepPrivate
                };
            else
                return new UserInfoPublic()
                {
                    ID = User.ID,
                    BannerPicturePath = User.BannerPicturePath,
                    ProfilePicturePath = User.ProfilePicturePath,
                    UserName = User.UserName,
                    KeepPrivate = User.KeepPrivate,
                    FirstName = User.FirstName,
                    MiddleName = User.MiddleName,
                    LastName = User.LastName,
                    ProfileURL = User.ProfileURL,
                    Bio = User.Bio
                };
        }

        [HttpPost]
        public void Post([FromBody] UserFull Values)
        {
            ControllerHelper.CheckObjectForPostErrorException(Values);
            UserFullWithSecurity NewUser = new UserFullWithSecurity() { 
                UserName = Values.UserName, 
                Password = Values.Password,
                FirstName = Values.FirstName, 
                MiddleName = Values.MiddleName, 
                LastName = Values.LastName, 
                PrimaryPersonalEmail = Values.PrimaryPersonalEmail, 
                PrimaryPhone = Values.PrimaryPhone
            };

            NewUser.Salt = SecurityHelper.GetCode();
            NewUser.HashedPassword = SecurityHelper.PasswordToSaltedHash(NewUser.Password, NewUser.Salt);

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
        public void Put(int id, [FromBody] UserFull Values)
        {
            ControllerHelper.ClearObjectsEmptyStrings(Values);
            ControllerHelper.CheckObjectForPutErrorException(Values);

            UserFullWithSecurity NewUser = new UserFullWithSecurity()
            {
                UserName = Values.UserName,
                FirstName = Values.FirstName,
                MiddleName = Values.MiddleName,
                LastName = Values.LastName,
                PrimaryPersonalEmail = Values.PrimaryPersonalEmail,
                PrimaryPhone = Values.PrimaryPhone,
                Bio = Values.Bio,
                ProfileURL = Values.ProfileURL,
                BannerPicturePath = Values.BannerPicturePath,
                ProfilePicturePath = Values.ProfilePicturePath,
                KeepPrivate = Values.KeepPrivate
            };

            //Dont do this here for security
            //if (Values.Password != null)
            //{
            //    NewUser.Salt = SecurityHelper.GetCode();
            //    NewUser.HashedPassword = SecurityHelper.PasswordToSaltedHash(NewUser.Password, NewUser.Salt);
            //}

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