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
    public class GearSizesController : ApiController
    {
        [HttpGet]
        public IEnumerable<GearSize> Get()
        {
            using (DBContext DB = new DBContext())
                return DB.GearSizesTable.GetListOfGearSizes();
        }

        [HttpGet]
        public IEnumerable<GearSize> GetListOfGearSizesByGearType(byte GearID)
        {
            using (DBContext DB = new DBContext())
                return DB.GearSizesTable.GetListOfGearSizes(GearID);
        }

        [HttpGet]
        public GearSize Get(byte id)
        {
            using (DBContext DB = new DBContext())
                return DB.GearSizesTable.GetGearSize(id);
        }
        
    }
}