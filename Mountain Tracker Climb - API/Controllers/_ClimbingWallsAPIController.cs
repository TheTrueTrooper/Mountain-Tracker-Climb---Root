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
    public class ClimbingWallsController : ApiController
    {
        [HttpGet]
        public IEnumerable<ClimbingWall> Get()
        {
            using (DBContext DB = new DBContext())
                return DB.ClimbingWallsTable.GetListOfClimbingWalls();
        }

        //[Route("customers/{customerId}/orders")]
        [HttpGet]
        public IEnumerable<ClimbingWall> GetByArea(int AreaID)
        {
            using (DBContext DB = new DBContext())
                return DB.ClimbingWallsTable.GetListOfClimbingWalls(AreaID);
        }

        [HttpGet]
        public ClimbingWall Get(int id)
        {
            using (DBContext DB = new DBContext())
                return DB.ClimbingWallsTable.GetClimbingWall(id);
        }

        [HttpPost]
        public void Post([FromBody] ClimbingWall Values)
        {
            ControllerHelper.CheckObjectForPostErrorException(Values);
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.ClimbingWallsTable.AddClimbingWall(Values);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e, ". There can be only one per Area."));
            }
        }

        [HttpPut]
        public void Put(int id, [FromBody] ClimbingWall Values)
        {
            ControllerHelper.ClearObjectsEmptyStrings(Values);
            ControllerHelper.CheckObjectForPutErrorException(Values);
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.ClimbingWallsTable.UpdateClimbingWall(id, Values);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e, ". There can be only one per Area."));
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.ClimbingWallsTable.DeleteClimbingWall(id);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }
    }
}