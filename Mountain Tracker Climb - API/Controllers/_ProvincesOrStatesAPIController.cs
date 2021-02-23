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
    public class ProvincesOrStatesController : ApiController
    {
        public IEnumerable<ProvinceOrState> Get()
        {
            using (DBContext DB = new DBContext())
                return DB.ProvincesOrStatesTable.GetListOfProvincesOrStates();
        }

        //[Route("customers/{customerId}/orders")]
        public IEnumerable<ProvinceOrState> GetByCountry(int CountryID)
        {
            using (DBContext DB = new DBContext())
                return DB.ProvincesOrStatesTable.GetListOfProvincesOrStates(CountryID);
        }

        // GET api/values/5
        public ProvinceOrState Get(int id)
        {
            using (DBContext DB = new DBContext())
                return DB.ProvincesOrStatesTable.GetProvinceOrState(id);
        }
    }
}