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
    public class ClimbingTypesController : ApiController
    {
        [HttpGet]
        public IEnumerable<ClimbingType> Get()
        {
            using (DBContext DB = new DBContext())
                return DB.ClimbingTypesTable.GetListOfClimbingType();
        }

        [HttpGet]
        public ClimbingType Get(byte id)
        {
            using (DBContext DB = new DBContext())
                return DB.ClimbingTypesTable.GetClimbingType(id);
        }
    }
}