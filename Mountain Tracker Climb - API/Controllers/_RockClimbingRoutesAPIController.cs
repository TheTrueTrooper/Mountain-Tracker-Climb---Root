using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MTCSharedModels.Models;
using Mountain_Tracker_Climb___API.DBModelContexts;

namespace Mountain_Tracker_Climb___API.Controllers
{
    //RockClimbingRoutesDBContext
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
                IEnumerable<RockClimbingRoute> Routes = DB.RockClimbingRoutesTable.GetListOfRockClimbingRoutes();
                foreach(RockClimbingRoute Route in Routes)
                {
                    Route.Difficulty = DB.RockClimbingDifficultiesTable.GetRockClimbingDifficulty(Route.DifficultyID.Value);
                    Route.RouteType = DB.ClimbingTypesTable.GetClimbingType(Route.TypeID.Value);
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
                return Route;
            }
        }

        [HttpPost]
        public void Post([FromBody] RockClimbingRoute Values)
        {
            using (DBContext DB = new DBContext())
                DB.RockClimbingRoutesTable.AddRockClimbingRoute(Values);
        }

        [HttpPut]
        public void Put(int id, [FromBody]RockClimbingRoute Values)
        {
            using (DBContext DB = new DBContext())
                DB.RockClimbingRoutesTable.UpdateRockClimbingRoute(id, Values);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            using (DBContext DB = new DBContext())
                DB.RockClimbingRoutesTable.DeleteRockClimbingRoute(id);
        }
    }
}