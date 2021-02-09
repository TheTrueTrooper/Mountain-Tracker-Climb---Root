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
    public class CountiesController : ApiController
    {
        public IEnumerable<Country> Get()
        {
            using (CountriesDBContext DB = new CountriesDBContext())
                return DB.GetListOfCountries();
        }

        // GET api/values/5
        public Country Get(int id)
        {
            using (CountriesDBContext DB = new CountriesDBContext())
                return DB.GetCountry(id);
        }

        //public Country Get(int id, bool WithProvinces)
        //{
        //    Country Return = null;
        //    using (CountriesDBContext DB = new CountriesDBContext())
        //        Return = DB.GetCountry(id);
        //    if(WithProvinces)
        //    using (ProvincesOrStatesDBContext DB = new ProvincesOrStatesDBContext())
        //        Return.ProvincesOrStates = DB.GetListOfProvincesOrStates(Return.ID).ToList();
        //    return Return;
        //}

        public int Get(bool Test)
        {
            using (CountriesDBContext DB = new CountriesDBContext())
                return DB.InsertCountry(new List<Country> { new Country() { ID = 1, EnglishFullName = "Test", CountryCode = "CA" }, new Country() { ID = 2, EnglishFullName = "Test2", CountryCode = "CB" } });
        }

        //// POST api/values
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}