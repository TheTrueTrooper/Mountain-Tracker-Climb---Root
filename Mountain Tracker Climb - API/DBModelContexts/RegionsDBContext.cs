using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

        public Region GetRegion(int id)
        {
            return GetListOf($"ID = {id}").First();
        }

        public int AddRegion(Region Values)
        {
            return InsertData(Values);
        }

        public int UpdateRegion(int ID, Region Values)
        {
            return UpdateData(Values, $"ID = {ID}");
        }

        public int DeleteRegion(int ID)
        {
            return DeleteData($"ID = {ID}");
        }
    }
}