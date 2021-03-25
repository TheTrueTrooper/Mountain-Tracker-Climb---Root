using Mountain_Tracker_Climb___API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts.StoredProcs
{
    internal class CreateTokenDBContext1 : RootDBStoredProcContext<CreateTokenProc>
    {
        public CreateTokenDBContext1() : base() { }

        public CreateTokenDBContext1(IDBRootContext Context) : base(Context.DB) { }

        protected override string DBStoredProcedure => "dbo.CreateToken";

        public int CreateToken(CreateTokenProc Values)
        {
            return Execute(Values);
        }
    }

    internal class CreateTokenDBContext2 : RootDBStoredProcContext<CreateTokenProc2>
    {
        public CreateTokenDBContext2() : base() { }

        public CreateTokenDBContext2(IDBRootContext Context) : base(Context.DB) { }

        protected override string DBStoredProcedure => "dbo.CreateToken";

        public int CreateToken(CreateTokenProc2 Values)
        {
            return Execute(Values);
        }
    }
}