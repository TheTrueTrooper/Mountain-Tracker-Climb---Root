using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MTCSharedModels.Models;
using Mountain_Tracker_Climb___API.DBModelContexts;
using Mountain_Tracker_Climb___API.Security;

namespace Mountain_Tracker_Climb___API.Controllers
{
    [SecurityLevel()]
    public class RockClimbingDifficultiesController : ApiController
    {
        [HttpGet]
        public IEnumerable<RockClimbingDifficulty> Get()
        {
            using (DBContext DB = new DBContext())
                return DB.RockClimbingDifficultiesTable.GetListOfRockClimbingDifficulties();
        }

        [HttpGet]
        public RockClimbingDifficulty Get(byte id)
        {
            using (DBContext DB = new DBContext())
                return DB.RockClimbingDifficultiesTable.GetRockClimbingDifficulty(id);
        }

    }
}