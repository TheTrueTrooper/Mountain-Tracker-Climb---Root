//using MTCSharedModels.Models;
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
        public DistrictZonesDBContext DistrictZonesTable { get; }
        public ZoneAreasDBContext ZoneAreasTable { get; }
        public ClimbingWallsDBContext ClimbingWallsTable { get; }
        public RockClimbingRoutesDBContext RockClimbingRoutesTable { get; }
        public RockClimbingDifficultiesDBContext RockClimbingDifficultiesTable { get; }
        public ClimbingTypeDBContext ClimbingTypesTable { get; }

        public DBContext()
        {
            CountriesTable = new CountriesDBContext();
            ProvincesOrStatesTable = new ProvincesOrStatesDBContext(CountriesTable);
            RegionsTable = new RegionsDBContext(ProvincesOrStatesTable);
            DistrictsTable = new DistrictsDBContext(RegionsTable);
            DistrictZonesTable = new DistrictZonesDBContext(DistrictsTable);
            ZoneAreasTable = new ZoneAreasDBContext(DistrictZonesTable);
            ClimbingWallsTable = new ClimbingWallsDBContext(ZoneAreasTable);
            RockClimbingRoutesTable = new RockClimbingRoutesDBContext(ClimbingWallsTable);
            ClimbingTypesTable = new ClimbingTypeDBContext(RockClimbingRoutesTable);
            RockClimbingDifficultiesTable = new RockClimbingDifficultiesDBContext(ClimbingTypesTable);
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