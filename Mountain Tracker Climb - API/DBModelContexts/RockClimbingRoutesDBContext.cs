using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class RockClimbingRoutesDBContext : RootDBContext<RockClimbingRoute>
    {
        public RockClimbingRoutesDBContext() : base() { }

        public RockClimbingRoutesDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<RockClimbingRoute> GetListOfRockClimbingRoutes()
        {
            return GetListOf();
        }

        public IEnumerable<RockClimbingRoute> GetListOfRockClimbingRoutes(int ClimbingWallID)
        {
            return GetListOf($"ClimbingWallID = {ClimbingWallID}");
        }

        public RockClimbingRoute GetRockClimbingRoute(int id)
        {
            return GetListOf($"ID = {id}").First();
        }

        public int AddRockClimbingRoute(RockClimbingRoute Values)
        {
            return InsertData(Values);
        }

        public int UpdateRockClimbingRoute(int ID, RockClimbingRoute Values)
        {
            return UpdateData(Values, $"ID = {ID}");
        }

        public int DeleteRockClimbingRoute(int ID)
        {
            return DeleteData($"ID = {ID}");
        }
    }
}