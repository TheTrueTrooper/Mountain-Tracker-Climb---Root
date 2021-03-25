//using MTCSharedModels.Models;
using Mountain_Tracker_Climb___API.DBModelContexts.StoredProcs;
using Mountain_Tracker_Climb___API.Models;
using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class DBContext : IDisposable
    {
        internal sealed class TokenCheckerDBContext
        {
            CheckTokenDBContext BasicTokenChecker { get; }
            CheckTokenWithAccessLevelDBContext TokenAccesLevelChecker { get; }

            public TokenCheckerDBContext(IDBRootContext Context)
            {
                BasicTokenChecker = new CheckTokenDBContext(Context);
                TokenAccesLevelChecker = new CheckTokenWithAccessLevelDBContext(Context);
            }

            public CheckTokenProcReturn CheckToken(CheckTokenProc Value)
            {
                return BasicTokenChecker.CheckToken(Value);
            }

            public CheckTokenProcReturn CheckToken(CheckTokenWithAccessLevelProc Value)
            {
                return TokenAccesLevelChecker.CheckToken(Value);
            }
        }

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
        public RouteGearDBContext RockClimbingRoutesGearLinkingTable { get; }
        public RouteGearDBContext RouteGearTable { get => RockClimbingRoutesGearLinkingTable; }
        public GearSizesDBContext GearSizesTable { get; }
        public GearDBContext GearTable { get; }
        public UserAccessLevelDBContext UserAccessLevelTable { get; }
        public UserDBContext UserTable { get; }



        public TokenCheckerDBContext TokenChecker { get; }

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
            RockClimbingRoutesGearLinkingTable = new RouteGearDBContext(RockClimbingDifficultiesTable);
            GearSizesTable = new GearSizesDBContext(RockClimbingRoutesGearLinkingTable);
            GearTable = new GearDBContext(GearSizesTable);
            UserAccessLevelTable = new UserAccessLevelDBContext(GearTable);
            UserTable = new UserDBContext(UserAccessLevelTable);


            TokenChecker = new TokenCheckerDBContext(UserAccessLevelTable);
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