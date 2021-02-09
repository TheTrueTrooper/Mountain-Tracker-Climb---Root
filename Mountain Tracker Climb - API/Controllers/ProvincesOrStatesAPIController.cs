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
            using (ProvincesOrStatesDBContext DB = new ProvincesOrStatesDBContext())
                return DB.GetListOfProvincesOrStates();
        }

        //[Route("customers/{customerId}/orders")]
        public IEnumerable<ProvinceOrState> GetByCountry(int CountryID)
        {
            using (ProvincesOrStatesDBContext DB = new ProvincesOrStatesDBContext())
                return DB.GetListOfProvincesOrStates();
        }

        // GET api/values/5
        public ProvinceOrState Get(int id)
        {
            using (ProvincesOrStatesDBContext DB = new ProvincesOrStatesDBContext())
                return DB.GetProvinceOrState(id);
        }
    }
}