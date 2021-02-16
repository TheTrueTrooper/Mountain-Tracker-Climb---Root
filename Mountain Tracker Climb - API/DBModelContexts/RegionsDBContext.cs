using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class RegionsDBContext : RootDBContext<Region>
    {
        public RegionsDBContext() : base() { }

        public RegionsDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<Region> GetListOfRegions()
        {
            return GetListOf();
        }

        public IEnumerable<Region> GetListOfRegions(int ProvinceOrStateID)
        {
            return GetListOf($"ProvinceOrStateID = {ProvinceOrStateID}");
        }

        public Region GetRegion(int ID)
        {
            return GetListOf($"ID = {ID}").First();
        }
    }
}