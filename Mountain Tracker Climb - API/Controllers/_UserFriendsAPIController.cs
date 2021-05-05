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

namespace Mountain_Tracker_Climb___API.Controllers
{
    //friends was lingo was converted to partners. this is the first level that that difference matters.
    public class UserPartnerController : ApiController
    {

        [NonAction]
        void EnsureOwnerShip(int id)
        {
            this.EnsureOwnerShip(id, null);
        }

        [NonAction]
        void EnsureOwnerShip(int To, int From)
        {
            object CurrentUserIDBoxed;
            Request.Properties.TryGetValue(StaticVars.UserID, out CurrentUserIDBoxed);

            if (CurrentUserIDBoxed == null && (int)CurrentUserIDBoxed != To && (int)CurrentUserIDBoxed != From)
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        [APISecurityLevel()]
        [HttpGet]
        public UserFriendList Get(int id)
        {
            UserFriendList List = new UserFriendList();
            IEnumerable<UserFriend> FriendsRaw = null;
            using (DBContext DBContext = new DBContext())
                FriendsRaw = DBContext.UserFriendsTable.GetListOfFriends(id);
            //quickly sort entire list
            foreach(UserFriend F in FriendsRaw.Where(x=> x.Accepted == false && x.UserFromID == id))
            {
                List.RequestsFrom.Add(F);
            }
            foreach (UserFriend F in FriendsRaw.Where(x => x.Accepted == false && x.UserToID == id))
            {
                List.RequestsTo.Add(F);
            }
            foreach (UserFriend F in FriendsRaw.Where(x => x.Accepted == true && x.UserFromID == id))
            {
                List.FriendsAdded.Add(F);
            }
            foreach (UserFriend F in FriendsRaw.Where(x => x.Accepted == true && x.UserToID == id))
            {
                List.FriendsAccepted.Add(F);
            }
            //Sort based on date for responses
            List.RequestsFrom.Sort((x, y) => (int)(x.RequestCreationDate.Value.Ticks - y.RequestCreationDate.Value.Ticks));
            List.RequestsTo.Sort((x, y) => (int)(x.RequestCreationDate.Value.Ticks - y.RequestCreationDate.Value.Ticks));
            using (DBContext DBContext = new DBContext())
            {
                foreach (UserFriend F in List.FriendsAdded)
                {
                    UserInfoPublic Data = DBContext.UserTable.GetUser(F.UserToID);
                    List.Friends.Add(new UserInfoPublic() { ID = Data.ID, UserName = Data.UserName, Bio = Data.Bio, CountryID = Data.CountryID, FirstName = Data.FirstName, KeepPrivate = Data.KeepPrivate, LastName = Data.LastName, MiddleName = Data.MiddleName, ProfileURL = Data.ProfileURL, ProvinceID = Data.ProvinceID });
                }
                foreach (UserFriend F in List.FriendsAccepted)
                {
                    UserInfoPublic Data = DBContext.UserTable.GetUser(F.UserFromID);
                    List.Friends.Add(new UserInfoPublic() { ID = Data.ID, UserName = Data.UserName, Bio = Data.Bio, CountryID = Data.CountryID, FirstName = Data.FirstName, KeepPrivate = Data.KeepPrivate, LastName = Data.LastName, MiddleName = Data.MiddleName, ProfileURL = Data.ProfileURL, ProvinceID = Data.ProvinceID });
                }
                foreach (UserFriend F in List.RequestsTo)
                {
                    UserInfoPrivate Data = DBContext.UserTable.GetUser(F.UserFromID);
                    List.FriendRequests.Add(new UserInfoPrivate() { KeepPrivate = Data.KeepPrivate, ID = Data.ID, UserName = Data.UserName });
                }
                foreach (UserFriend F in List.RequestsFrom)
                {
                    UserInfoPrivate Data = DBContext.UserTable.GetUser(F.UserToID);
                    List.FriendRequesteds.Add(new UserInfoPrivate() { KeepPrivate = Data.KeepPrivate, ID = Data.ID, UserName = Data.UserName });
                }
            }
            return List;
        }

        //[APISecurityLevel()]
        //[HttpGet]
        //public IEnumerable<UserInfoPrivate> Get(string NameSearch)
        //{
        //    IEnumerable<UserFullWithSecurity> User;
        //    List<UserInfoPrivate> Return = new List<UserInfoPrivate>();
        //    using (DBContext DB = new DBContext())
        //    {
        //        User = DB.UserTable.GetListOfUsers(NameSearch);
        //        foreach(UserFullWithSecurity FU in User)
        //        {
        //            //return shorter data for faster consumption
        //            Return.Add(new UserInfoPrivate()
        //            {
        //                ID = FU.ID,
        //                UserName = FU.UserName,
        //                KeepPrivate = FU.KeepPrivate
        //            });
        //        }
        //    }
        //    //if ir is not the user there are two states based on if it is private or not.
        //    return Return;
        //}

        [APISecurityLevel()]
        [HttpGet]
        public CheckIfFriendProcReturn Get(int UserID, int FriendID)
        {
            this.EnsureOwnerShip(UserID);
            using (DBContext DB = new DBContext())
                return DB.FriendChecker.CheckIfFriend(new CheckIfFriendProc() { UserID = UserID, FriendUserID = FriendID });
        }

        [APISecurityLevel()]
        [HttpGet]
        public CheckIfFriendProcReturn Get(int UserID, int FriendID, bool? Requests)
        {
            this.EnsureOwnerShip(UserID);
            if(Requests!= null && !Requests.Value)
                using (DBContext DB = new DBContext())
                    return DB.FriendChecker.CheckIfFriend(new CheckIfFriendProc() { UserID = UserID, FriendUserID = FriendID });
            using (DBContext DB = new DBContext())
                return DB.FriendRequestChecker.CheckIfFriendOrRequested(new CheckIfFriendProc() { UserID = UserID, FriendUserID = FriendID });
        }

        [APISecurityLevel()]
        [HttpPut]
        public void Put([FromBody] UserFriend Values)
        {
            ControllerHelper.CheckObjectForPostErrorException(Values);
            EnsureOwnerShip(Values.UserToID);

            try
            {
                using (DBContext DB = new DBContext())
                    DB.FriendAcceptor.AcceptRequest(new AcceptFriendRequestProc() { UserFromID = Values.UserFromID, UserToID = Values.UserToID });
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }

        [APISecurityLevel()]
        [HttpPost]
        public void Post([FromBody] UserFriend Values)
        {
            ControllerHelper.CheckObjectForPostErrorException(Values);
            EnsureOwnerShip(Values.UserFromID);

            try
            {
                using (DBContext DB = new DBContext())
                    DB.UserFriendsTable.AddFriendshipRequest(Values);
            }
            catch(SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }

        [APISecurityLevel()]
        [HttpDelete]
        public void Delete(int UserFromID, int UserToID)
        {
            EnsureOwnerShip(UserToID, UserFromID);

            try
            {
                using (DBContext DB = new DBContext())
                    DB.UserFriendsTable.DeleteFriendship(UserFromID, UserToID);
            }
            catch(SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }
    }
}