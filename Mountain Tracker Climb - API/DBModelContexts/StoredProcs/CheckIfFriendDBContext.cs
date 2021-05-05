using Mountain_Tracker_Climb___API.Models;
using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts.StoredProcs
{
    internal class CheckIfFriendDBContext : RootDBStoredProcContext<CheckIfFriendProc, CheckIfFriendProcReturn>
    {
        public CheckIfFriendDBContext() : base() { }

        public CheckIfFriendDBContext(IDBRootContext Context) : base(Context.DB) { }

        protected override string DBStoredProcedure => "dbo.CheckIfFriend";

        public CheckIfFriendProcReturn CheckIfFriend(int UserID, int FriendUserID)
        {
            return CheckIfFriend(new CheckIfFriendProc() { UserID = UserID, FriendUserID = FriendUserID });
        }

        public CheckIfFriendProcReturn CheckIfFriend(CheckIfFriendProc Values)
        {
            return Execute(Values).FirstOrDefault();
        }
    }
}