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
    public class RegionsController : ApiController
    {
        public IEnumerable<Region> Get()
        {
            using (DBContext DB = new DBContext())
                return DB.RegionsTable.GetListOfRegions();
        }

        //[Route("customers/{customerId}/orders")]
        [HttpGet]
        public IEnumerable<Region> GetByProvinceOrState(int ProvinceOrStateID)
        {
            using (DBContext DB = new DBContext())
                return DB.RegionsTable.GetListOfRegions(ProvinceOrStateID);
        }

        // GET api/values/5
        [HttpGet]
        public Region Get(int id)
        {
            using (DBContext DB = new DBContext())
                return DB.RegionsTable.GetRegion(id);
        }

        [HttpPost]
        public void Post([FromBody]Region Values)
        {
            try 
            { 
                using (DBContext DB = new DBContext())
                    DB.RegionsTable.AddRegion(Values);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }

        [HttpPut]
        public void Put(int id, [FromBody] Region Values)
        {
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.RegionsTable.UpdateRegion(id, Values);
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
                    DB.RegionsTable.DeleteRegion(id);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }

    }
}