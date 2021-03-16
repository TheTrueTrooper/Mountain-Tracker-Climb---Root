using Mountain_Tracker_Climb___API.DBModelContexts;
using Mountain_Tracker_Climb___API.Helpers;
using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.DistrictsTable.AddDistrict(Values);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }

        [HttpPut]
        public void Put(int id, [FromBody] District Values)
        {
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.DistrictsTable.UpdateDistrict(id, Values);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.DistrictsTable.DeleteDistrict(id);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }

    }
}