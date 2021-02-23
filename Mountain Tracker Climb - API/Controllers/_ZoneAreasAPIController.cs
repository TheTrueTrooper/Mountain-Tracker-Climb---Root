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
    public class ZoneAreasController : ApiController
    {
        [HttpGet]
        public IEnumerable<ZoneArea> Get()
        {
            using (DBContext DB = new DBContext())
                return DB.ZoneAreasTable.GetListOfZoneAreas();
        }

        //[Route("customers/{customerId}/orders")]
        [HttpGet]
        public IEnumerable<ZoneArea> GetByZoneID(int ZoneID)
        {
            using (DBContext DB = new DBContext())
                return DB.ZoneAreasTable.GetListOfZoneAreas(ZoneID);
        }

        [HttpGet]
        public ZoneArea Get(int id)
        {
            using (DBContext DB = new DBContext())
                return DB.ZoneAreasTable.GetZoneArea(id);
        }

        [HttpPost]
        public void Post([FromBody] ZoneArea Values)
        {
            using (DBContext DB = new DBContext())
                DB.ZoneAreasTable.AddZoneArea(Values);
        }

        [HttpPut]
        public void Put(int id, [FromBody] ZoneArea Values)
        {
            using (DBContext DB = new DBContext())
                DB.ZoneAreasTable.UpdateZoneArea(id, Values);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            using (DBContext DB = new DBContext())
                DB.ZoneAreasTable.DeleteZoneArea(id);
        }
    }
}