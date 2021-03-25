using Mountain_Tracker_Climb___API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts.StoredProcs
{
    internal class CheckTokenDBContext : RootDBStoredProcContext<CheckTokenProc, CheckTokenProcReturn>
    {
        public CheckTokenDBContext() : base() { }

        public CheckTokenDBContext(IDBRootContext Context) : base(Context.DB) { }

        protected override string DBStoredProcedure => "dbo.CheckToken";

        public CheckTokenProcReturn CheckToken(CheckTokenProc Values)
        {
            return Execute(Values).FirstOrDefault();
        }
    }
}