using Mountain_Tracker_Climb___API.Models;
using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts.StoredProcs
{
    internal class AcceptFriendRequestDBContext : RootDBStoredProcContext<AcceptFriendRequestProc>
    {
        public AcceptFriendRequestDBContext() : base() { }

        public AcceptFriendRequestDBContext(IDBRootContext Context) : base(Context.DB) { }

        protected override string DBStoredProcedure => "dbo.AcceptFriendRequest";

        public int AcceptRequest(AcceptFriendRequestProc Values)
        {
            return Execute(Values);
        }
    }
}