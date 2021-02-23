using Mountain_Tracker_Climb___API.DBModelContexts;
using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Mountain_Tracker_Climb___API.Controllers
{
    public class DistrictsController : ApiController
    {
        [HttpGet]
        public IEnumerable<District> Get()
        {
            using (DBContext DB = new DBContext())
                return DB.DistrictsTable.GetListOfDistricts();
        }

        //[Route("customers/{customerId}/orders")]
        [HttpGet]
        public IEnumerable<District> GetByRegion(int RegionID)
        {
            using (DBContext DB = new DBContext())
                return DB.DistrictsTable.GetListOfDistricts(RegionID);
        }

        [HttpGet]
        public District Get(int id)
        {
            using (DBContext DB = new DBContext())
                return DB.DistrictsTable.GetDistrict(id);
        }

        [HttpPost]
        public void Post([FromBody] District Values)
        {
            using (DBContext DB = new DBContext())
                DB.DistrictsTable.AddDistrict(Values);
        }

        [HttpPut]
        public void Post(int id, [FromBody] District Values)
        {
            using (DBContext DB = new DBContext())
                DB.DistrictsTable.UpdateDistrict(id, Values);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            using (DBContext DB = new DBContext())
                DB.DistrictsTable.DeleteDistrict(id);
        }

    }
}