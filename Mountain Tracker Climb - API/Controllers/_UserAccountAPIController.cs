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
using System.IO;
using System.Net.Http.Headers;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;

namespace Mountain_Tracker_Climb___API.Controllers
{
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

        [NonAction]
        void EnsureOwnerShip(int id)
        {
            object CurrentUserIDBoxed;
            Request.Properties.TryGetValue(StaticVars.UserID, out CurrentUserIDBoxed);
            object AccessLevelIDBoxed;
            Request.Properties.TryGetValue(StaticVars.AccessLevelID, out AccessLevelIDBoxed);

            if (CurrentUserIDBoxed == null && ((int)CurrentUserIDBoxed != id || (AccessLevelIDBoxed == null && (int)CurrentUserIDBoxed > APISecurityLevelAttribute.AccessLevels["Moderater"])))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        [APISecurityLevel()]
        [HttpGet]
        public object Get(int id)
        {
            UserFullWithSecurity User;
            using (DBContext DB = new DBContext())
            {
                User = DB.UserTable.GetUser(id);

                if (User == null)
                    return "No user found!";

                /*  'Unrestricted Admin',
                    'Admin'
                    'Moderater'
                    'Guide'
                    'PayedUser'
                    'User'*/

                //will check if it is user
                object CurrentUserIDBoxed;
                Request.Properties.TryGetValue(StaticVars.UserID, out CurrentUserIDBoxed);
                object AccessLevelIDBoxed;
                Request.Properties.TryGetValue(StaticVars.AccessLevelID, out AccessLevelIDBoxed);
                if (CurrentUserIDBoxed != null && AccessLevelIDBoxed != null && ((int)CurrentUserIDBoxed  == User.ID || (int)CurrentUserIDBoxed <= APISecurityLevelAttribute.AccessLevels["Moderater"]))
                    return new UserFull()
                    {
                        ID = User.ID,
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
                    UserName = User.UserName,
                    KeepPrivate = User.KeepPrivate
                };
            else
                return new UserInfoPublic()
                {
                    ID = User.ID,
                    UserName = User.UserName,
                    KeepPrivate = User.KeepPrivate,
                    FirstName = User.FirstName,
                    MiddleName = User.MiddleName,
                    LastName = User.LastName,
                    ProfileURL = User.ProfileURL,
                    Bio = User.Bio
                };
        }

        [HttpGet]
        [Route("Api/UserAccount/{id}/ProfilePicture")]
        public async Task<HttpResponseMessage> GetProfilePicture(int id)
        {
            UserProfilePicture PictureRaw = null;
            using (DBContext Context = new DBContext())
                PictureRaw = Context.ProfilePictures.GetUserProfilePicture(id);

            if (PictureRaw != null && PictureRaw.ProfilePictureBytes != null)
                return ControllerHelper.GeneratePNGImageResponse(PictureRaw);


            using (MemoryStream PictureFileMemory = await ControllerHelper.LoadFileToMemoryAsync(ControllerHelper.MapVirtualPath("~/StaticImages/Values_Sustainablity.PNG")))
            {
                PictureRaw.ProfilePictureBytes = PictureFileMemory.ToArray();
            }
            return ControllerHelper.GeneratePNGImageResponse(PictureRaw);
        }

        [APISecurityLevel()]
        [HttpPut]
        [Route("Api/UserAccount/{id}/ProfilePicture")]
        public async Task<HttpResponseMessage> UploadProfilePicture(int id)
        {
            EnsureOwnerShip(id);
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            try
            {
                MultipartMemoryStreamProvider MPMemoryStream = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(MPMemoryStream);
                //begin read

                Task<byte[]> Result = MPMemoryStream.Contents[1].ReadAsByteArrayAsync();

                if (MPMemoryStream.Contents[1].Headers.ContentType == null)
                {
                    return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
                }

                string ContentType = MPMemoryStream.Contents[1].Headers.ContentType.MediaType.ToLower();
                //do checks while waiting
                if (ContentType != "image/png" /*&& ContentType != "image/jpeg"*/)
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

                await Result;
                UserProfilePicture PictureRaw = new UserProfilePicture() {
                    ProfilePictureBytes = Result.Result
                };

                using (DBContext DB = new DBContext())
                    DB.ProfilePictures.UpdateUserProfilePicture(id, PictureRaw);

                return Request.CreateResponse(HttpStatusCode.OK);

                #region UsefulSnidBit
                //multifile app
                //foreach (var file in MPMemoryStream.Contents)
                //{
                //    var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                //    var buffer = await file.ReadAsByteArrayAsync();
                //    //Do whatever you want with filename and its binary data.
                //}
                #endregion
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("Api/UserAccount/{id}/BannerPicture")]
        public async Task<HttpResponseMessage> GetBannerPicture(int id)
        {
            UserBannerPicture PictureRaw = null;
            using (DBContext Context = new DBContext())
                PictureRaw = Context.BannerPictures.GetUserBannerPicture(id);

            if (PictureRaw != null && PictureRaw.BannerPictureBytes != null)
                return ControllerHelper.GeneratePNGImageResponse(PictureRaw);

            using (MemoryStream PictureFileMemory = await ControllerHelper.LoadFileToMemoryAsync(ControllerHelper.MapVirtualPath("~/StaticImages/Values_Sustainablity.PNG")))
            {
                PictureRaw.BannerPictureBytes = PictureFileMemory.ToArray();
            }
            return ControllerHelper.GeneratePNGImageResponse(PictureRaw);
        }

        [APISecurityLevel()]
        [HttpPut]
        [Route("Api/UserAccount/{id}/BannerPicture")]
        public async Task<HttpResponseMessage> UploadBannerPicture(int id)
        {
            EnsureOwnerShip(id);
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            try
            {
                MultipartMemoryStreamProvider MPMemoryStream = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(MPMemoryStream);
                //begin read
                Task<byte[]> Result = MPMemoryStream.Contents[1].ReadAsByteArrayAsync();

                string ContentType = MPMemoryStream.Contents[1].Headers.ContentType.MediaType.ToLower();
                //do checks while waiting
                if (ContentType != "image/png" /*&& ContentType != "image/jpeg"*/)
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

                await Result;
                UserBannerPicture PictureRaw = new UserBannerPicture()
                {
                    BannerPictureBytes = Result.Result
                };

                using (DBContext DB = new DBContext())
                    DB.BannerPictures.UpdateUserBannerPicture(id, PictureRaw);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [APISecurityLevel()]
        [HttpGet]
        public IEnumerable<UserInfoPrivate> Get(string NameSearch)
        {
            IEnumerable<UserFullWithSecurity> User;
            List<UserInfoPrivate> Return = new List<UserInfoPrivate>();
            using (DBContext DB = new DBContext())
            {
                User = DB.UserTable.GetListOfUsers(NameSearch);
                foreach(UserFullWithSecurity FU in User)
                {
                    //return shorter data for faster consumption
                    Return.Add(new UserInfoPrivate()
                    {
                        ID = FU.ID,
                        UserName = FU.UserName,
                        KeepPrivate = FU.KeepPrivate
                    });
                }
            }
            //if ir is not the user there are two states based on if it is private or not.
            return Return;
        }

        [HttpPost]
        public void Post([FromBody] UserCreate Values)
        {
            ControllerHelper.ClearObjectsEmptyStrings(Values);
            ControllerHelper.CheckObjectForPostErrorException(Values);

            UserFullWithSecurity NewUser = new UserFullWithSecurity() {
                UserName = Values.UserName,
                Password = Values.Password,
                FirstName = Values.FirstName,
                MiddleName = Values.MiddleName,
                LastName = Values.LastName,
                PrimaryPersonalEmail = Values.PrimaryPersonalEmail,
                PrimaryPhone = Values.PrimaryPhone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")
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

        [APISecurityLevel()]
        [HttpPut]
        public void Put(int id, [FromBody] UserFull Values)
        {
            ControllerHelper.ClearObjectsEmptyStrings(Values);
            ControllerHelper.CheckObjectForPutErrorException(Values);

            EnsureOwnerShip(id);

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
                KeepPrivate = Values.KeepPrivate
            };

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

        [APISecurityLevel()]
        [HttpDelete]
        public void Delete(int id)
        {
            EnsureOwnerShip(id);

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