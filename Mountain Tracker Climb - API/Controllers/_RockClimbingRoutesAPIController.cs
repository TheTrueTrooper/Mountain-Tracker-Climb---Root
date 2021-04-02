using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MTCSharedModels.Models;
using Mountain_Tracker_Climb___API.DBModelContexts;
using System.Data.SqlClient;
using Mountain_Tracker_Climb___API.Helpers;
using Mountain_Tracker_Climb___API.Security;

namespace Mountain_Tracker_Climb___API.Controllers
{
    //RockClimbingRoutesDBContext
    [SecurityLevel()]
    public class RockClimbingRoutesController : ApiController
    {
        [HttpGet]
        public IEnumerable<RockClimbingRoute> Get()
        {
            using (DBContext DB = new DBContext())
            {
                IEnumerable<RockClimbingRoute> Routes = DB.RockClimbingRoutesTable.GetListOfRockClimbingRoutes();
                foreach (RockClimbingRoute Route in Routes)
                {
                    Route.Difficulty = DB.RockClimbingDifficultiesTable.GetRockClimbingDifficulty(Route.DifficultyID.Value);
                    Route.RouteType = DB.ClimbingTypesTable.GetClimbingType(Route.TypeID.Value);
                    Route.RoutesGear = DB.RouteGearTable.GetListOfRouteGear(Route.ID.Value).ToList();
                    foreach(RouteGear RG in Route.RoutesGear)
                    {
                        RG.Gear = DB.GearSizesTable.GetGearSize(RG.GearSizeID.Value);
                    }
                }
                return Routes;
            }
        }

        //[Route("customers/{customerId}/orders")]
        [HttpGet]
        public IEnumerable<RockClimbingRoute> GetByWallID(int WallID)
        {
            using (DBContext DB = new DBContext())
            {
                IEnumerable<RockClimbingRoute> Routes = DB.RockClimbingRoutesTable.GetListOfRockClimbingRoutes(WallID);
                foreach(RockClimbingRoute Route in Routes)
                {
                    Route.Difficulty = DB.RockClimbingDifficultiesTable.GetRockClimbingDifficulty(Route.DifficultyID.Value);
                    Route.RouteType = DB.ClimbingTypesTable.GetClimbingType(Route.TypeID.Value);
                    Route.RoutesGear = DB.RouteGearTable.GetListOfRouteGear(Route.ID.Value).ToList();
                    foreach (RouteGear RG in Route.RoutesGear)
                    {
                        RG.Gear = DB.GearSizesTable.GetGearSize(RG.GearSizeID.Value);
                    }
                }
                return Routes;
            }
        }

        [HttpGet]
        public RockClimbingRoute Get(int id)
        {
            using (DBContext DB = new DBContext())
            {
                RockClimbingRoute Route = DB.RockClimbingRoutesTable.GetRockClimbingRoute(id);
                Route.Difficulty = DB.RockClimbingDifficultiesTable.GetRockClimbingDifficulty(Route.DifficultyID.Value);
                Route.RouteType = DB.ClimbingTypesTable.GetClimbingType(Route.TypeID.Value);
                Route.RoutesGear = DB.RouteGearTable.GetListOfRouteGear(Route.ID.Value).ToList();
                foreach (RouteGear RG in Route.RoutesGear)
                {
                    RG.Gear = DB.GearSizesTable.GetGearSize(RG.GearSizeID.Value);
                }
                return Route;
            }
        }

        [HttpPost]
        [SecurityLevel("Admin")]
        public void Post([FromBody] RockClimbingRoute Values)
        {
            ControllerHelper.CheckObjectForPostErrorException(Values);
            try 
            { 
                using (DBContext DB = new DBContext())
                    DB.RockClimbingRoutesTable.AddRockClimbingRoute(Values);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e, ". There can be only one per Wall."));
            }
        }

        [HttpPut]
        [SecurityLevel("Admin")]
        public void Put(int id, [FromBody]RockClimbingRoute Values)
        {
            ControllerHelper.ClearObjectsEmptyStrings(Values);
            ControllerHelper.CheckObjectForPutErrorException(Values);
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.RockClimbingRoutesTable.UpdateRockClimbingRoute(id, Values);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e, ". There can be only one per Wall."));
            }
        }

        [HttpDelete]
        [SecurityLevel("Admin")]
        public void Delete(int id)
        {
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.RockClimbingRoutesTable.DeleteRockClimbingRoute(id);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }
    }
}