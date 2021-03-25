using Mountain_Tracker_Climb___API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts.StoredProcs
{
    internal class CheckTokenWithAccessLevelDBContext : RootDBStoredProcContext<CheckTokenWithAccessLevelProc, CheckTokenWithAccessLevelProcReturn>
    {
        public CheckTokenWithAccessLevelDBContext() : base() { }

        public CheckTokenWithAccessLevelDBContext(IDBRootContext Context) : base(Context.DB) { }

        protected override string DBStoredProcedure => "dbo.CheckTokenWithAccessLevel";

        public CheckTokenWithAccessLevelProcReturn CheckToken(CheckTokenWithAccessLevelProc Values)
        {
            return Execute(Values).FirstOrDefault();
        }
    }
}