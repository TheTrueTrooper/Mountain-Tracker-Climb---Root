using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class CountriesDBContext : RootDBContext<Country>
    {
        public override string DBTable => "dbo.Countries";

        public CountriesDBContext() : base() { }

        public CountriesDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<Country> GetListOfCountries()
        {
            return GetListOf();
        }

        public Country GetCountry(int ID)
        {
            return GetListOf($"ID = {ID}").First();
        }
    }
}