using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class DBContext : IDisposable
    {
        public CountriesDBContext CountriesTable { get; }
        public ProvincesOrStatesDBContext ProvincesOrStatesTable { get; }
        public RegionsDBContext RegionsTable { get; }
        public DistrictsDBContext DistrictsTable { get; }

        public DBContext()
        {
            CountriesTable = new CountriesDBContext();
            ProvincesOrStatesTable = new ProvincesOrStatesDBContext(CountriesTable);
            RegionsTable = new RegionsDBContext(ProvincesOrStatesTable);
            DistrictsTable = new DistrictsDBContext(RegionsTable);
        }

        public void Dispose()
        {
            CountriesTable.Dispose();
            //ProvincesOrStatesTable.Dispose();
            //RegionsTable.Dispose();
            //DistrictsTable.Dispose();
            //One handles all disposible as the disposable part is shared now
        }
    }
}