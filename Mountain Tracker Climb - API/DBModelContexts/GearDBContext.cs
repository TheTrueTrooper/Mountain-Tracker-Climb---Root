using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class GearDBContext : RootDBContext<Gear>
    {
        public override string DBTable => "dbo.Gear";

        public GearDBContext() : base() { }

        public GearDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<Gear> GetListOfGear()
        {
            return GetListOf();
        }

        public Gear GetGear(byte ID)
        {
            return GetListOf($"ID = {ID}").FirstOrDefault();
        }
    }
}