using MTCSharedModels.Models;
using Mountain_Tracker_Climb___API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mountain_Tracker_Climb___API.Helpers;
using Mountain_Tracker_Climb___API.Security;
using Mountain_Tracker_Climb___API.DBModelContexts.StoredProcs;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class UserFriendsDBContext : RootDBContext<UserFriend>
    {

        public UserFriendsDBContext() : base() 
        {
        }

        public UserFriendsDBContext(IDBRootContext Context) : base(Context.DB) 
        {
        }

        public IEnumerable<UserFriend> GetListOfFriends(int UserOfFriends)
        {
            return GetListOf($"UserFromID = {UserOfFriends} or UserToID = {UserOfFriends}");
        }

        public UserFriend GetFriendship(int UserFromID, int UserToID)
        {
                return GetListOf($"UserFromID = {UserFromID} and UserToID = {UserToID}").FirstOrDefault();
        }

        public int AddFriendshipRequest(UserFriend Values)
        {
            Values.Accepted = false;
            return InsertData(Values);
        }

        public int UpdateFriendshipToAccepted(UserFriend Values)
        {
            Values.Accepted = true;
            return UpdateData(Values, $"UserFromID = {Values.UserFromID} and UserToID = {Values.UserToID}");
        }

        public int DeleteFriendship(int UserFromID, int UserToID)
        {
            return DeleteData($"UserFromID = {UserFromID} and UserToID = {UserToID}");
        }
    }
}