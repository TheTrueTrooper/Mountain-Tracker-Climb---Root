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
            using (DBContext DB = new DBContext())
                return DB.CountriesTable.GetListOfCountries();
        }

        public IEnumerable<Country> Get(bool? GetAll)
        {
            if (GetAll != false)
            {
                using (DBContext DB = new DBContext())
                {
                    IEnumerable<Country> Countries = DB.CountriesTable.GetListOfCountries();
                    foreach (Country C in Countries)
                    {
                        C.ProvincesOrStates = DB.ProvincesOrStatesTable.GetListOfProvincesOrStates(C.ID).ToList();
                        foreach (ProvinceOrState PS in C.ProvincesOrStates)
                        {
                            PS.Regions = DB.RegionsTable.GetListOfRegions(PS.ID.Value).ToList();
                            foreach (Region R in PS.Regions)
                            {
                                R.Districts = DB.DistrictsTable.GetListOfDistricts(R.ID.Value).ToList();
                                foreach (District D in R.Districts)
                                {
                                    D.Zones = DB.DistrictZonesTable.GetListOfDistrictZones(D.ID.Value).ToList();
                                    foreach (DistrictZone Z in D.Zones)
                                    {
                                        Z.Areas = DB.ZoneAreasTable.GetListOfZoneAreas(Z.ID.Value).ToList();
                                        foreach (ZoneArea A in Z.Areas)
                                        {
                                            A.ClimbingWalls = DB.ClimbingWallsTable.GetListOfClimbingWalls(A.ID.Value).ToList();
                                            foreach (ClimbingWall CW in A.ClimbingWalls)
                                            {
                                                CW.RockClimbingRoutes = DB.RockClimbingRoutesTable.GetListOfRockClimbingRoutes(CW.ID.Value).ToList();
                                                foreach(RockClimbingRoute RCR in CW.RockClimbingRoutes)
                                                {
                                                    RCR.RouteType = DB.ClimbingTypesTable.GetClimbingType(RCR.TypeID.Value);
                                                    RCR.Difficulty = DB.RockClimbingDifficultiesTable.GetRockClimbingDifficulty(RCR.TypeID.Value);
                                                    RCR.RoutesGear = DB.RouteGearTable.GetListOfRouteGear(RCR.ID.Value).ToList();
                                                    foreach (RouteGear RG in RCR.RoutesGear)
                                                    {
                                                        RG.Gear = DB.GearSizesTable.GetGearSize(RG.GearSizeID.Value);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return Countries;
                }
            }
            else
                return Get();
        }

        // GET api/values/5
        public Country Get(int id)
        {
            using (DBContext DB = new DBContext())
            {
                Country Return = DB.CountriesTable.GetCountry(id);
                Return.ProvincesOrStates = DB.ProvincesOrStatesTable.GetListOfProvincesOrStates(Return.ID).ToList();
                return Return;
            }
        }

        //Will do full drill down
        public Country Get(int id, bool? GetAll)
        {
            if (GetAll != false)
            {
                using (DBContext DB = new DBContext())
                {
                    Country Return = DB.CountriesTable.GetCountry(id);
                    Return.ProvincesOrStates = DB.ProvincesOrStatesTable.GetListOfProvincesOrStates(Return.ID).ToList();
                    foreach (ProvinceOrState PS in Return.ProvincesOrStates)
                    {
                        PS.Regions = DB.RegionsTable.GetListOfRegions(PS.ID.Value).ToList();
                        foreach (Region R in PS.Regions)
                        {
                            R.Districts = DB.DistrictsTable.GetListOfDistricts(R.ID.Value).ToList();
                            foreach (District D in R.Districts)
                            {
                                D.Zones = DB.DistrictZonesTable.GetListOfDistrictZones(D.ID.Value).ToList();
                                foreach (DistrictZone Z in D.Zones)
                                {
                                    Z.Areas = DB.ZoneAreasTable.GetListOfZoneAreas(Z.ID.Value).ToList();
                                    foreach (ZoneArea A in Z.Areas)
                                    {
                                        A.ClimbingWalls = DB.ClimbingWallsTable.GetListOfClimbingWalls(A.ID.Value).ToList();
                                        foreach (ClimbingWall CW in A.ClimbingWalls)
                                        {
                                            CW.RockClimbingRoutes = DB.RockClimbingRoutesTable.GetListOfRockClimbingRoutes(CW.ID.Value).ToList();
                                            foreach (RockClimbingRoute RCR in CW.RockClimbingRoutes)
                                            {
                                                RCR.RouteType = DB.ClimbingTypesTable.GetClimbingType(RCR.TypeID.Value);
                                                RCR.Difficulty = DB.RockClimbingDifficultiesTable.GetRockClimbingDifficulty(RCR.TypeID.Value);
                                                RCR.RoutesGear = DB.RouteGearTable.GetListOfRouteGear(RCR.ID.Value).ToList();
                                                foreach (RouteGear RG in RCR.RoutesGear)
                                                {
                                                    RG.Gear = DB.GearSizesTable.GetGearSize(RG.GearSizeID.Value);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return Return;
                }
            }
            else
                return Get(id);
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

        //public int Get(bool Test)
        //{
        //    using (DBContext DB = new DBContext())
        //        return DB.CountriesTable.InsertCountry(new List<Country> { new Country() { ID = 1, EnglishFullName = "Test", CountryCode = "CA" }, new Country() { ID = 2, EnglishFullName = "Test2", CountryCode = "CB" } });
        //}

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