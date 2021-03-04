using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class RouteGearDBContext : RootDBContext<RouteGear>
    {
        public override string DBTable => "dbo.RockClimbingRoutesGearLinkingTable";

        public RouteGearDBContext() : base() { }

        public RouteGearDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<RouteGear> GetListOfRouteGear()
        {
            return GetListOf();
        }

        public IEnumerable<RouteGear> GetListOfRouteGear(int RockClimbingRoutesID)
        {
            return GetListOf($"RockClimbingRoutesID = {RockClimbingRoutesID}");
        }

        public RouteGear GetRouteGear(int RockClimbingRoutesID, byte GearSizeID)
        {
            return GetListOf($"RockClimbingRoutesID = {RockClimbingRoutesID} and GearSizeID = {GearSizeID}").First();
        }

        public int AddRouteGear(RouteGear Values)
        {
            return InsertData(Values);
        }

        public int UpdateRouteGear(int RockClimbingRoutesID, byte GearSizeID, RouteGear Values)
        {
            return UpdateData(Values, $"RockClimbingRoutesID = {RockClimbingRoutesID} and GearSizeID = {GearSizeID}");
        }

        public int DeleteRouteGear(int RockClimbingRoutesID, byte GearSizeID)
        {
            return DeleteData($"RockClimbingRoutesID = {RockClimbingRoutesID} and GearSizeID = {GearSizeID}");
        }
    }
}