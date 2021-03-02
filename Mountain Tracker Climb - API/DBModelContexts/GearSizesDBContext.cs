using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class GearSizesDBContext : RootDBContext<GearSize>
    {
        public GearSizesDBContext() : base() { }

        public GearSizesDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<GearSize> GetListOfGearSizes()
        {
            return GetListOf();
        }

        public IEnumerable<GearSize> GetListOfGearSizes(byte GearID)
        {
            return GetListOf($"GearID = {GearID}");
        }

        public GearSize GetGearSize(byte id)
        {
            return GetListOf($"ID = {id}").First();
        }
    }
}