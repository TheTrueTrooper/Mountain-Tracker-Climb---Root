using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class DistrictsDBContext : RootDBContext<District>
    {
        public DistrictsDBContext() : base() { }

        public DistrictsDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<District> GetListOfDistricts()
        {
            return GetListOf();
        }

        public IEnumerable<District> GetListOfDistricts(int RegionID)
        {
            return GetListOf($"RegionID = {RegionID}");
        }

        public District GetRegion(int ID)
        {
            return GetListOf($"ID = {ID}").First();
        }
    }
}