using Mountain_Tracker_Climb___API.DBModelContexts;
using Mountain_Tracker_Climb___API.Helpers;
using Mountain_Tracker_Climb___API.Security;
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
    [SecurityLevel()]
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
        [SecurityLevel("Admin")]
        public void Post([FromBody] DistrictZone Values)
        {
            ControllerHelper.CheckObjectForPostErrorException(Values);
            try
            {
                using (DBContext DB = new DBContext())
                    DB.DistrictZonesTable.AddDistrictZone(Values);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e, ". There can be only one per District."));
            }
        }

        [HttpPut]
        [SecurityLevel("Admin")]
        public void Put(int id, [FromBody] DistrictZone Values)
        {
            ControllerHelper.ClearObjectsEmptyStrings(Values);
            ControllerHelper.CheckObjectForPutErrorException(Values);
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.DistrictZonesTable.UpdateDistrictZone(id, Values);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e, ". There can be only one per District."));
            }
        }

        [HttpDelete]
        [SecurityLevel("Admin")]
        public void Delete(int id)
        {
            try
            { 
                using (DBContext DB = new DBContext())
                    DB.DistrictZonesTable.DeleteDistrictZone(id);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }

    }
}