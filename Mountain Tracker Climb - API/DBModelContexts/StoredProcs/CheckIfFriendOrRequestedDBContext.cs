using Mountain_Tracker_Climb___API.Models;
using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts.StoredProcs
{
    internal class CheckIfFriendOrRequestedDBContext : RootDBStoredProcContext<CheckIfFriendProc, CheckIfFriendProcReturn>
    {
        public CheckIfFriendOrRequestedDBContext() : base() { }

        public CheckIfFriendOrRequestedDBContext(IDBRootContext Context) : base(Context.DB) { }

        protected override string DBStoredProcedure => "dbo.CheckIfFriendOrRequested";

        public CheckIfFriendProcReturn CheckIfFriendOrRequested(int UserID, int FriendUserID)
        {
            return CheckIfFriendOrRequested(new CheckIfFriendProc() { UserID = UserID, FriendUserID = FriendUserID });
        }

        public CheckIfFriendProcReturn CheckIfFriendOrRequested(CheckIfFriendProc Values)
        {
            return Execute(Values).FirstOrDefault();
        }
    }
}