using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class DistrictZonesDBContext : RootDBContext<DistrictZone>
    {
        public DistrictZonesDBContext() : base() { }

        public DistrictZonesDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<DistrictZone> GetListOfDistrictZones()
        {
            return GetListOf();
        }

        public IEnumerable<DistrictZone> GetListOfDistrictZones(int DistrictID)
        {
            return GetListOf($"DistrictID = {DistrictID}");
        }

        public DistrictZone GetDistrictZone(int ID)
        {
            return GetListOf($"ID = {ID}").First();
        }

        public int AddDistrictZone(DistrictZone Values)
        {
            return InsertData(Values);
        }

        public int UpdateDistrictZone(int ID, DistrictZone Values)
        {
            return UpdateData(Values, $"ID = {ID}");
        }

        public int DeleteDistrictZone(int ID)
        {
            return DeleteData($"ID = {ID}");
        }
    }
}