using Mountain_Tracker_Climb___API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts.StoredProcs
{
    internal class GetUsersSaltDBContext : RootDBStoredProcContext<UserGetSaltProc, UserGetSaltProcReturn>
    {
        public GetUsersSaltDBContext() : base() { }

        public GetUsersSaltDBContext(IDBRootContext Context) : base(Context.DB) { }

        protected override string DBStoredProcedure => "dbo.GetUserSalt";

        public UserGetSaltProcReturn GetSalt(UserGetSaltProc Values)
        {
            return Execute(Values).FirstOrDefault();
        }
    }
}