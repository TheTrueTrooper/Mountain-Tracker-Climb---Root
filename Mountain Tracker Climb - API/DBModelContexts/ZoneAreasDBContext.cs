using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class ZoneAreasDBContext : RootDBContext<ZoneArea>
    {
        public ZoneAreasDBContext() : base() { }

        public ZoneAreasDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<ZoneArea> GetListOfZoneAreas()
        {
            return GetListOf();
        }

        public IEnumerable<ZoneArea> GetListOfZoneAreas(int DistrictZoneID)
        {
            return GetListOf($"DistrictZoneID = {DistrictZoneID}");
        }

        public ZoneArea GetZoneArea(int id)
        {
            return GetListOf($"ID = {id}").First();
        }

        public int AddZoneArea(ZoneArea Values)
        {
            return InsertData(Values);
        }

        public int UpdateZoneArea(int ID, ZoneArea Values)
        {
            return UpdateData(Values, $"ID = {ID}");
        }

        public int DeleteZoneArea(int ID)
        {
            return DeleteData($"ID = {ID}");
        }
    }
}