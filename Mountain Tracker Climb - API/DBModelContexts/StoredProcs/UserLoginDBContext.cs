using Mountain_Tracker_Climb___API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts.StoredProcs
{
    internal class UserLoginDBContext : RootDBStoredProcContext<UserLoginProc, UserLoginProcReturn>
    {
        public UserLoginDBContext() : base() { }

        public UserLoginDBContext(IDBRootContext Context) : base(Context.DB) { }

        protected override string DBStoredProcedure => "dbo.UserLogin";

        public UserLoginProcReturn Login(UserLoginProc Values)
        {
            return Execute(Values).FirstOrDefault();
        }
    }
}