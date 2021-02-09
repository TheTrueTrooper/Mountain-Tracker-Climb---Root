using Microsoft.Ajax.Utilities;
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

        public IEnumerable<Country> GetListOfCountries()
        {
            return GetListOf();
        }

        public Country GetCountry(int ID)
        {
            return GetListOf($"ID = {ID}").First();
        }

        public int InsertCountry(Country NewCountry)
        {
            return InsertData(NewCountry);
        }

        public int InsertCountry(List<Country> NewCountrys)
        {
            return InsertData(NewCountrys);
        }
    }
}