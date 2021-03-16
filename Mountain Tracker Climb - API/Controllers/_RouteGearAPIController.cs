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

namespace Mountain_Tracker_Climb___API.Controllers
{
    public class RouteGearController : ApiController
    {
        public IEnumerable<RouteGear> Get()
        {
            using (DBContext DB = new DBContext())
                return DB.RouteGearTable.GetListOfRouteGear();
        }

        //[Route("customers/{customerId}/orders")]
        [HttpGet]
        public IEnumerable<RouteGear> GetByProvinceOrState(int RockClimbingRoutesID)
        {
            using (DBContext DB = new DBContext())
            {
                IEnumerable<RouteGear> Return = DB.RouteGearTable.GetListOfRouteGear(RockClimbingRoutesID);
                foreach(RouteGear RG in Return)
                {
                    RG.Gear = DB.GearSizesTable.GetGearSize(RG.GearSizeID.Value);
                }
                return Return;
            }
        }

        // GET api/values/5
        [HttpGet]
        public RouteGear Get(int RockClimbingRoutesID, byte GearSizeID)
        {
            using (DBContext DB = new DBContext())
            {
                RouteGear Return = DB.RouteGearTable.GetRouteGear(RockClimbingRoutesID, GearSizeID);
                Return.Gear = DB.GearSizesTable.GetGearSize(Return.GearSizeID.Value);
                return DB.RouteGearTable.GetRouteGear(RockClimbingRoutesID, GearSizeID);
            }
        }

        [HttpPost]
        public void Post([FromBody] RouteGear Values)
        {
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.RouteGearTable.AddRouteGear(Values);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }

        [HttpPut]
        public void Put(int RockClimbingRoutesID, byte GearSizeID, [FromBody] RouteGear Values)
        {
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.RouteGearTable.UpdateRouteGear(RockClimbingRoutesID, GearSizeID, Values);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }

        [HttpDelete]
        public void Delete(int RockClimbingRoutesID, byte GearSizeID)
        {
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.RouteGearTable.DeleteRouteGear(RockClimbingRoutesID, GearSizeID);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }

    }
}