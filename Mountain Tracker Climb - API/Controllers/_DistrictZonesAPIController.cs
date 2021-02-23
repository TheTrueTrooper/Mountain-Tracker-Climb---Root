using Mountain_Tracker_Climb___API.DBModelContexts;
using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace Mountain_Tracker_Climb___API.Controllers
{
    public class DistrictZonesController : ApiController
    {

        [HttpGet]
        public IEnumerable<DistrictZone> Get()
        {
            using (DBContext DB = new DBContext())
                return DB.DistrictZonesTable.GetListOfDistrictZones();
        }

        //[Route("customers/{customerId}/orders")]
        [HttpGet]
        public IEnumerable<DistrictZone> GetByDistrict(int DistrictID)
        {
            using (DBContext DB = new DBContext())
                return DB.DistrictZonesTable.GetListOfDistrictZones(DistrictID);
        }

        [HttpGet]
        public DistrictZone Get(int id)
        {
            using (DBContext DB = new DBContext())
                return DB.DistrictZonesTable.GetDistrictZone(id);
        }

        [HttpPost]
        public void Post([FromBody] DistrictZone Values)
        {
            using (DBContext DB = new DBContext())
                DB.DistrictZonesTable.AddDistrictZone(Values);
        }

        [HttpPut]
        public void Put(int id, [FromBody] DistrictZone Values)
        {
            using (DBContext DB = new DBContext())
                DB.DistrictZonesTable.UpdateDistrictZone(id, Values);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            using (DBContext DB = new DBContext())
                DB.DistrictZonesTable.DeleteDistrictZone(id);
        }

    }
}