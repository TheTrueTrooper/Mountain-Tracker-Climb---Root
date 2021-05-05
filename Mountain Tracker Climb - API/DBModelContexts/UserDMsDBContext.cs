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
    internal class UserDMsDBContext : RootDBContext<UserDM>
    {

        public UserDMsDBContext() : base() 
        {
        }

        public UserDMsDBContext(IDBRootContext Context) : base(Context.DB) 
        {
        }

        public IEnumerable<UserDM> GetListOfMessages(int UserID)
        {
            return GetListOf($"UserFromID = {UserID} or UserToID = {UserID}");
        }

        public IEnumerable<UserDM> GetListOfMessagesBewteenUsers(int User1, int User2, bool MarkAsRead = true)
        {
            IEnumerable<UserDM> Return = GetListOf($"(UserFromID = {User1} and UserToID = {User2}) or (UserFromID = {User2} and UserToID = {User1})");
            if(MarkAsRead)
                ExecuteCustomNonQuery($"update {this.DBTable} set Seen = 1 where (UserFromID = {User1} and UserToID = {User2}) or (UserFromID = {User2} and UserToID = {User1})");
            return Return;
        }

        public UserDM GetListOfMessagesBewteenUsers(int DirectMessageID)
        {
            return GetListOf($"DirectMessageID = {DirectMessageID}").FirstOrDefault();
        }

        public int AddMessage(UserDM Values)
        {
            return InsertData(Values);
        }

        public int UpdateMessage(int DirectMessageID, UserDM Values)
        {
            return UpdateData(Values, $"DirectMessageID = {DirectMessageID} and UserFromID = {Values.UserFromID} and UserToID = {Values.UserToID}");
        }

        public int DeleteMessage(int DirectMessageID, int UserFromID)
        {
            return DeleteData($"DirectMessageID = {DirectMessageID} and UserFromID = {UserFromID}");
        }
    }
}