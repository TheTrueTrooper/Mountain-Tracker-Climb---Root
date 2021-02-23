﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MTCSharedModels.Models;
using Mountain_Tracker_Climb___API.DBModelContexts;

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
            using (DBContext DB = new DBContext())
                DB.ClimbingWallsTable.AddClimbingWall(Values);
        }

        [HttpPut]
        public void Put(int id, [FromBody] ClimbingWall Values)
        {
            using (DBContext DB = new DBContext())
                DB.ClimbingWallsTable.UpdateClimbingWall(id, Values);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            using (DBContext DB = new DBContext())
                DB.ClimbingWallsTable.DeleteClimbingWall(id);
        }
    }
}