/* WritersSigniture
//Writer: Angelo Sanches (BitSan)(Git:TheTrueTrooper)
//Date Writen: Dec 1,2020
//Project Goal: Make a cloud based app to aid in project management 
//File Goal: to create a angularjs Contoller system to streamline work with APIs
//Link: https://github.com/TheTrueTrooper/AngelASPExtentions
//Sources: 
//  {
//  Name: NA
//  Writer/Publisher: NA
//  Link: NA
//  }
*/
angular.module("NGRouteQuickEdit", ["ngRoute", "ngSanitize", "ngCookies"])
    //.value("$", $)//import 
    //.run(function () {
    //    //not used init set up here
    //})
    //.config(["$routeProvider", function ($routeProvider) {
    //not used yet
    //    $routeProvider
    //        .when("/OverView",
    //            {
    //                templateUrl: "http://localhost:62740/Project/IndexSubPage?AngularView=OverView",
    //                controller: "OverViewController"
    //            });
    //}])
    //.factory("socketService", function ($, $rootScope) {
    //    //Not used
    //})
    .service("WebAPIServices", function ($http) {
        //const HostURL = "http://mtntracker.com/Api/";
        const HostURL = "http://localhost:12699/Api/";
        const CountriesController = "Counties";
        const ProvincesOrStatesController = "ProvincesOrStates";
        const RegionsController = "Regions";
        const DistrictsController = "Districts";
        const DistrictZonesController = "DistrictZones";
        const ZoneAreasController = "ZoneAreas";
        const ClimbingWallsController = "ClimbingWalls";
        const RockClimbingRoutesController = "RockClimbingRoutes";
        const ClimbingTypesController = "ClimbingTypes";
        const RockClimbingDifficultiesController = "RockClimbingDifficulties";
        const GearController = "Gear";
        const GearSizesController = "GearSizes";
        const RouteGearController = "RouteGear";
        return {
            /**
             * The Calls for mail box operations
             */
            Countries: {
                /**
                 * @returns {object} A object containing all of the data
                 */
                GetList: function () {
                    return $http.get(HostURL + CountriesController, { responseType: "json" });
                }
            },
            ProvincesOrStates: {
                /**
                 * @param {any} CountryID The ID of the country
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (CountryID) {
                    return $http.get(HostURL + ProvincesOrStatesController + "?CountryID=" + CountryID, { responseType: "json" });
                }
            },
            Regions: {
                /**
                 * @param {any} ProvinceOrStateID The ID of the Province Or State
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (ProvinceOrStateID) {
                    return $http.get(HostURL + RegionsController + "?ProvinceOrStateID=" + ProvinceOrStateID, { responseType: "json" });
                },
                /**
                 * @param {object} NewRegion The data for the new region to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewRegion) {
                    return $http.post(HostURL + RegionsController, NewRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the Region to edit
                 * @returns {object} A object containing all of the data
                 */
                Update: function (ID, EditedRegion) {
                    return $http.put(HostURL + RegionsController + "/" + ID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the Region to delete
                 * @returns {object} A object containing all of the data
                 */
                Delete: function (ID) {
                    return $http.delete(HostURL + RegionsController + "/" + ID, { responseType: "json" });
                }
            },
            Districts: {
                /**
                 * @param {any} RegionID The ID of the Region
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (RegionID) {
                    return $http.get(HostURL + DistrictsController + "?RegionID=" + RegionID, { responseType: "json" });
                },
                /**
                 * @param {object} NewDistrict The data for the new District to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewDistrict) {
                    return $http.post(HostURL + DistrictsController, NewDistrict, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the District to edit
                 * @returns {object} A object containing all of the data
                 */
                Update: function (ID, EditedRegion) {
                    return $http.put(HostURL + DistrictsController + "/" + ID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the District to delete
                 * @returns {object} A object containing all of the data
                 */
                Delete: function (ID) {
                    return $http.delete(HostURL + DistrictsController + "/" + ID, { responseType: "json" });
                }
            },
            DistrictZones: {
                /**
                 * @param {any} DistrictID The ID of the District
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (DistrictID) {
                    return $http.get(HostURL + DistrictZonesController + "?DistrictID=" + DistrictID, { responseType: "json" });
                },
                /**
                 * @param {object} NewZone The data for the new Zone to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewZone) {
                    return $http.post(HostURL + DistrictZonesController, NewZone, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID to edit
                 * @returns {object} A object containing all of the data
                 */
                Update: function (ID, EditedRegion) {
                    return $http.put(HostURL + DistrictZonesController + "/" + ID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the District to delete
                 * @returns {object} A object containing all of the data
                 */
                Delete: function (ID) {
                    return $http.delete(HostURL + DistrictZonesController + "/" + ID, { responseType: "json" });
                }
            },
            ZoneAreas: {
                /**
                 * @param {any} ZoneID The ID of the Zone
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (ZoneID) {
                    return $http.get(HostURL + ZoneAreasController + "?ZoneID=" + ZoneID, { responseType: "json" });
                },
                /**
                 * @param {object} NewArea The data for the new Area to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewArea) {
                    return $http.post(HostURL + ZoneAreasController, NewArea, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID to edit
                 * @returns {object} A object containing all of the data
                 */
                Update: function (ID, EditedRegion) {
                    return $http.put(HostURL + ZoneAreasController + "/" + ID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the District to delete
                 * @returns {object} A object containing all of the data
                 */
                Delete: function (ID) {
                    return $http.delete(HostURL + ZoneAreasController + "/" + ID, { responseType: "json" });
                }
            },
            ClimbingWalls: {
                /**
                 * @param {any} AreaID The ID of the Area
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (AreaID) {
                    return $http.get(HostURL + ClimbingWallsController + "?AreaID=" + AreaID, { responseType: "json" });
                },
                /**
                 * @param {object} NewClimbingWall The data for the new ClimbingWall to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewClimbingWall) {
                    return $http.post(HostURL + ClimbingWallsController, NewClimbingWall, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID to edit
                 * @returns {object} A object containing all of the data
                 */
                Update: function (ID, EditedRegion) {
                    return $http.put(HostURL + ClimbingWallsController + "/" + ID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the District to delete
                 * @returns {object} A object containing all of the data
                 */
                Delete: function (ID) {
                    return $http.delete(HostURL + ClimbingWallsController + "/" + ID, { responseType: "json" });
                }
            },
            RockClimbingRoutes: {
                /**
                 * @param {any} WallID The ID of the Wall
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (WallID) {
                    return $http.get(HostURL + RockClimbingRoutesController + "?WallID=" + WallID, { responseType: "json" });
                },
                /**
                 * @param {object} NewRockClimbingRoute The data for the new RockClimbingRoute to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewRockClimbingRoute) {
                    return $http.post(HostURL + RockClimbingRoutesController, NewRockClimbingRoute, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID to edit
                 * @returns {object} A object containing all of the data
                 */
                Update: function (ID, EditedRegion) {
                    return $http.put(HostURL + RockClimbingRoutesController + "/" + ID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the District to delete
                 * @returns {object} A object containing all of the data
                 */
                Delete: function (ID) {
                    return $http.delete(HostURL + RockClimbingRoutesController + "/" + ID, { responseType: "json" });
                }
            },
            ClimbingTypes: {
                /**
                 * @returns {object} A object containing all of the data
                 */
                GetList: function () {
                    return $http.get(HostURL + ClimbingTypesController, { responseType: "json" });
                }
            },
            RockClimbingDifficulties: {
                /**
                 * @returns {object} A object containing all of the data
                 */
                GetList: function () {
                    return $http.get(HostURL + RockClimbingDifficultiesController, { responseType: "json" });
                }
            },
            RockClimbingDifficulties: {
                /**
                 * @returns {object} A object containing all of the data
                 */
                GetList: function () {
                    return $http.get(HostURL + RockClimbingDifficultiesController, { responseType: "json" });
                }
            },
            Gear: {
                /**
                 * @returns {object} A object containing all of the data
                 */
                GetList: function () {
                    return $http.get(HostURL + GearController, { responseType: "json" });
                }
            },
            GearSizes: {
                /**
                 * @param {any} GearID The ID of the District to delete
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (GearID) {
                    return $http.get(HostURL + GearSizesController + "?GearID=" + GearID, { responseType: "json" });
                }
            },
            RouteGear: {
                /**
                 * @param {any} RockClimbingRoutesID The ID of the Route
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (RockClimbingRoutesID) {
                    return $http.get(HostURL + RouteGearController + "?RockClimbingRoutesID=" + RockClimbingRoutesID, { responseType: "json" });
                },
                /**
                 * @param {object} NewRouteGear The data for the new RouteGear to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewRouteGear) {
                    return $http.post(HostURL + RouteGearController, NewRouteGear, { responseType: "json" });
                },
                /**
                 * @param {any} RockClimbingRoutesID The ID of the Route to delete
                 * @param {any} GearSizeID The ID of the Gear Size to delete
                 * @returns {object} A object containing all of the data
                 */
                Update: function (RockClimbingRoutesID, GearSizeID, EditedRouteGear) {
                    return $http.put(HostURL + RouteGearController + "?RockClimbingRoutesID=" + RockClimbingRoutesID + "&GearSizeID=" + GearSizeID, EditedRouteGear, { responseType: "json" });
                },
                /**
                 * @param {any} RockClimbingRoutesID The ID of the Route to delete
                 * @param {any} GearSizeID The ID of the Gear Size to delete
                 * @returns {object} A object containing all of the data
                 */
                Delete: function (RockClimbingRoutesID, GearSizeID) {
                    return $http.delete(HostURL + RouteGearController + "?RockClimbingRoutesID=" + RockClimbingRoutesID + "&GearSizeID=" + GearSizeID, { responseType: "json" });
                }
            }
        };
    })
    .controller("RouteQuickEditController", function ($window, $scope, $sce, WebAPIServices) {
        $scope.Countries = { SelectedID: "null" };
        $scope.ProvincesOrStates = { SelectedID: "null" };
        $scope.Regions =
        {
            SelectedID: "null",
            AddNew: {
                EnglishFullName: "",
                RegionCode: ""
            },
            EditChanges: {
                EnglishFullName: "",
                RegionCode: ""
            },
            DeleteDisplay: {
                EnglishFullName: "",
                RegionCode: ""
            }
        };
        $scope.Districts =
        {
            SelectedID: "null",
            AddNew: {
                EnglishFullName: "",
                DistrictCode: ""
            },
            EditChanges: {
                EnglishFullName: "",
                DistrictCode: ""
            },
            DeleteDisplay: {
                EnglishFullName: "",
                RegionCode: ""
            }
        };
        $scope.DistrictZones =
        {
            SelectedID: "null",
            AddNew: {
                EnglishFullName: "",
                ZoneCode: ""
            },
            EditChanges: {
                EnglishFullName: "",
                ZoneCode: ""
            },
            DeleteDisplay: {
                EnglishFullName: "",
                RegionCode: ""
            }
        };
        $scope.ZoneAreas =
        {
            SelectedID: "null",
            AddNew: {
                EnglishFullName: "",
                AreaCode: ""
            },
            EditChanges: {
                EnglishFullName: "",
                AreaCode: ""
            },
            DeleteDisplay: {
                EnglishFullName: "",
                RegionCode: ""
            }
        };
        $scope.ClimbingWalls =
        {
            SelectedID: "null",
            AddNew: {
                EnglishFullName: "",
                WallCode: ""
            },
            EditChanges: {
                EnglishFullName: "",
                WallCode: ""
            },
            DeleteDisplay: {
                EnglishFullName: "",
                RegionCode: ""
            }
        };
        $scope.Routes = {
            AddNew: {
                FirstAscent: "Unknown",
                FirstFreeAscent: "Unknown",
                SunAM: false,
                SunPM: false,
                Filtered: false,
                Sunny: false,
                Shady: false,
                DriesFast: false,
                DryInRain: false,
                Windy: false,
                ClimbAnglesHaveSlabs: false,
                ClimbAnglesHaveVerticals: false,
                ClimbAnglesHaveOverHangs: false,
                ClimbAnglesHaveRoofs: false,
                RockFalls: false,
                Seepage: false,
                StickClip: false,
                Runout: false,
                Reachy: false,
                Dyno: false,
                Pumpy: false,
                Techy: false,
                Power: false,
                PockSlashHole: false,
                Crimpy: false,
                SeatStart: false
            }
        };
        $scope.Gear = {
            Add: {
                GearID: "null",
                GearSizeID: "null",
            }
        };
        $scope.RouteInfo = {
            ID: null,
            RouteInfo: ""
        };

        var ProvSelectEle = angular.element($("#SelectProvinceOrState"));
        var RegionSelectEle = angular.element($("#SelectRegion"));
        var RegionAddEle = angular.element($("#AddRegion"));
        var RegionEditEle = angular.element($("#EditRegion"));
        var RegionDeleteEle = angular.element($("#DeleteRegion"));
        var DistrictSelectEle = angular.element($("#SelectDistrict"));
        var DistrictAddEle = angular.element($("#AddDistrict"));
        var DistrictEditEle = angular.element($("#EditDistrict"));
        var DistrictDeleteEle = angular.element($("#DeleteDistrict"));
        var DistrictZoneSelectEle = angular.element($("#SelectDistrictZone"));
        var DistrictZoneAddEle = angular.element($("#AddDistrictZone"));
        var DistrictZoneEditEle = angular.element($("#EditDistrictZone"));
        var DistrictZoneDeleteEle = angular.element($("#DeleteDistrictZone"));
        var ZoneAreaSelectEle = angular.element($("#SelectZoneArea"));
        var ZoneAreaAddEle = angular.element($("#AddZoneArea"));
        var ZoneAreaEditEle = angular.element($("#EditZoneArea"));
        var ZoneAreaDeleteEle = angular.element($("#DeleteZoneArea"));
        var ClimbingWallSelectEle = angular.element($("#SelectClimbingWall"));
        var ClimbingWallAddEle = angular.element($("#AddClimbingWall"));
        var ClimbingWallEditEle = angular.element($("#EditClimbingWall"));
        var ClimbingWallDeleteEle = angular.element($("#DeleteClimbingWall"));
        var AddRockClimbingRouteEle = angular.element($("#AddRockClimbingRoute"));
        var RouteInfoEditEle = angular.element($("#RouteInfoEdit"));
        var RouteInfoSaveEle = angular.element($("#RouteInfoSave"));
        var RouteInfoEditBoxEle = angular.element($("#RouteInfoEditBox"));
        var SelectGearSizeEle = angular.element($("#SelectGearSize"));


        function DisableButtons(Eles) {
            for (i = 0; i < Eles.length; i++) {
                Eles[i].attr('disabled', true);
            }
        };

        function EnableButtons(Eles) {
            for (i = 0; i < Eles.length; i++) {
                Eles[i].attr('disabled', false);
            }
        };

        function ErrorCallBack(result) {
            $window.alert("Status: " + (result.status || "Error") + "\nMessage: " + (result.statusText || 'Request failed for unknow reason.'));
        };

        $scope.ThrowPerferedToTop = function (obj) {
            var Value = obj.EnglishFullName;
            if (obj.CountryCode === 'CA')
                Value = "__" + obj.EnglishFullName;
            else if (obj.CountryCode === 'US')
                Value = "_" + obj.EnglishFullName;
            return Value;
        };

        DisableButtons([ProvSelectEle,
            RegionSelectEle, RegionAddEle, RegionAddEle, RegionEditEle, RegionDeleteEle,
            DistrictSelectEle, DistrictAddEle, DistrictEditEle, DistrictDeleteEle,
            DistrictZoneSelectEle, DistrictZoneAddEle, DistrictZoneEditEle, DistrictZoneDeleteEle,
            ZoneAreaSelectEle, ZoneAreaAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle,
            ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
            AddRockClimbingRouteEle,
            RouteInfoSaveEle, RouteInfoEditBoxEle]);
        EnableButtons([RouteInfoEditEle]);;

        WebAPIServices.Countries.GetList().then(function (result) {
            $scope.Countries.FullList = result.data;
            $scope.Countries.SelectedID = "null";
        });

        WebAPIServices.RockClimbingDifficulties.GetList().then(function (result) {
            $scope.RockClimbingDifficulties = result.data;
            $scope.Routes.AddNew.TypeID = "null";
        });

        WebAPIServices.ClimbingTypes.GetList().then(function (result) {
            $scope.ClimbingTypes = result.data;
            $scope.Routes.AddNew.DifficultyID = "null";
        });

        WebAPIServices.Gear.GetList().then(function (result) {
            $scope.Gear.FullList = result.data;
            $scope.Gear.Add.GearID = "null";
            $scope.Gear.Add.GearSizeID = "null";
        });

        $scope.SelectedCountry = function (ID) {
            if (!isNaN(ID)) {
                WebAPIServices.ProvincesOrStates.GetList(ID).then(function (result) {
                    $scope.ProvincesOrStates.FullList = result.data;
                    $scope.ProvincesOrStates.SelectedID = "null";
                    $scope.Regions.FullList = [];
                    $scope.Regions.SelectedID = "null";
                    $scope.Districts.FullList = [];
                    $scope.Districts.SelectedID = "null";
                    $scope.DistrictZones.FullList = [];
                    $scope.DistrictZones.SelectedID = "null";
                    $scope.ZoneAreas.FullList = [];
                    $scope.ZoneAreas.SelectedID = "null";
                    $scope.ClimbingWalls.FullList = [];
                    $scope.ClimbingWalls.SelectedID = "null";
                    EnableButtons([ProvSelectEle]);
                    DisableButtons([RegionSelectEle, RegionAddEle, RegionEditEle, RegionDeleteEle,
                        DistrictSelectEle, DistrictAddEle, DistrictEditEle, DistrictDeleteEle,
                        DistrictZoneSelectEle, DistrictZoneAddEle, DistrictZoneEditEle, DistrictZoneDeleteEle,
                        ZoneAreaSelectEle, ZoneAreaAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle,
                        ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
                        AddRockClimbingRouteEle]);
                });
            }
            else {
                $scope.ProvincesOrStates.FullList = [];
                $scope.ProvincesOrStates.SelectedID = "null";
                $scope.Regions.FullList = [];
                $scope.Regions.SelectedID = "null";
                $scope.Districts.FullList = [];
                $scope.Districts.SelectedID = "null";
                $scope.DistrictZones.FullList = [];
                $scope.DistrictZones.SelectedID = "null";
                $scope.ZoneAreas.FullList = [];
                $scope.ZoneAreas.SelectedID = "null";
                $scope.ClimbingWalls.FullList = [];
                $scope.ClimbingWalls.SelectedID = "null";
                $scope.Routes.FullList = [];
                DisableButtons([ProvSelectEle,
                    RegionSelectEle, RegionAddEle, RegionEditEle, RegionDeleteEle,
                    DistrictSelectEle, DistrictAddEle, DistrictEditEle, DistrictDeleteEle,
                    DistrictZoneSelectEle, DistrictZoneAddEle, DistrictZoneEditEle, DistrictZoneDeleteEle,
                    ZoneAreaSelectEle, ZoneAreaAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle,
                    ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
                    AddRockClimbingRouteEle]);
            }
        };

        $scope.SelectedProvinceOrState = function (ID) {
            if (!isNaN(ID)) {
                WebAPIServices.Regions.GetList(ID).then(function (result) {
                    $scope.Regions.FullList = result.data;
                    $scope.Regions.SelectedID = "null";
                    $scope.Districts.FullList = [];
                    $scope.Districts.SelectedID = "null";
                    $scope.DistrictZones.FullList = [];
                    $scope.DistrictZones.SelectedID = "null";
                    $scope.ZoneAreas.FullList = [];
                    $scope.ZoneAreas.SelectedID = "null";
                    $scope.ClimbingWalls.FullList = [];
                    $scope.ClimbingWalls.SelectedID = "null";
                    $scope.Routes.FullList = [];
                    EnableButtons([RegionSelectEle, RegionAddEle]);
                    DisableButtons([RegionEditEle, RegionDeleteEle,
                        DistrictSelectEle, DistrictAddEle, DistrictEditEle, DistrictDeleteEle,
                        DistrictZoneSelectEle, DistrictZoneAddEle, DistrictZoneEditEle, DistrictZoneDeleteEle,
                        ZoneAreaSelectEle, ZoneAreaAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle,
                        ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
                        AddRockClimbingRouteEle]);
                });
            }
            else {
                $scope.Regions.FullList = [];
                $scope.Regions.SelectedID = "null";
                $scope.Districts.FullList = [];
                $scope.Districts.SelectedID = "null";
                $scope.DistrictZones.FullList = [];
                $scope.DistrictZones.SelectedID = "null";
                $scope.ZoneAreas.FullList = [];
                $scope.ZoneAreas.SelectedID = "null";
                $scope.ClimbingWalls.FullList = [];
                $scope.ClimbingWalls.SelectedID = "null";
                $scope.Routes.FullList = [];
                DisableButtons([RegionSelectEle, RegionAddEle, RegionEditEle, RegionDeleteEle,
                    DistrictSelectEle, DistrictAddEle, DistrictEditEle, DistrictDeleteEle,
                    DistrictZoneSelectEle, DistrictZoneAddEle, DistrictZoneEditEle, DistrictZoneDeleteEle,
                    ZoneAreaSelectEle, ZoneAreaAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle,
                    ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
                    AddRockClimbingRouteEle]);
            }
        };

        $scope.SelectedRegion = function (ID) {
            if (!isNaN(ID)) {
                WebAPIServices.Districts.GetList(ID).then(function (result) {
                    $scope.Districts.FullList = result.data;
                    $scope.Districts.SelectedID = "null";
                    $scope.DistrictZones.FullList = [];
                    $scope.DistrictZones.SelectedID = "null";
                    $scope.ZoneAreas.FullList = [];
                    $scope.ZoneAreas.SelectedID = "null";
                    $scope.ClimbingWalls.FullList = [];
                    $scope.ClimbingWalls.SelectedID = "null";
                    $scope.Routes.FullList = [];
                    EnableButtons([DistrictSelectEle, DistrictAddEle, RegionEditEle, RegionDeleteEle]);
                    DisableButtons([DistrictEditEle, DistrictDeleteEle,
                        DistrictZoneSelectEle, DistrictZoneAddEle, DistrictZoneEditEle, DistrictZoneDeleteEle,
                        ZoneAreaSelectEle, ZoneAreaAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle,
                        ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
                        AddRockClimbingRouteEle]);
                    $scope.Regions.DeleteDisplay = $scope.Regions.FullList[$scope.Regions.FullList.findIndex(x => x.ID === parseInt(ID))];
                    $scope.Regions.EditChanges = JSON.parse(JSON.stringify($scope.Regions.DeleteDisplay));
                });
            }
            else {
                $scope.Districts.FullList = [];
                $scope.Districts.SelectedID = "null";
                $scope.DistrictZones.FullList = [];
                $scope.DistrictZones.SelectedID = "null";
                $scope.ZoneAreas.FullList = [];
                $scope.ZoneAreas.SelectedID = "null";
                $scope.ClimbingWalls.FullList = [];
                $scope.ClimbingWalls.SelectedID = "null";
                $scope.Routes.FullList = [];
                DisableButtons([RegionEditEle, RegionDeleteEle,
                    DistrictSelectEle, DistrictAddEle, DistrictEditEle, DistrictDeleteEle,
                    DistrictZoneSelectEle, DistrictZoneAddEle, DistrictZoneEditEle, DistrictZoneDeleteEle,
                    ZoneAreaSelectEle, ZoneAreaAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle,
                    ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
                    AddRockClimbingRouteEle]);
            }
        };

        $scope.SelectedDistrict = function (ID) {
            if (!isNaN(ID)) {
                WebAPIServices.DistrictZones.GetList(ID).then(function (result) {
                    $scope.DistrictZones.FullList = result.data;
                    $scope.DistrictZones.SelectedID = "null";
                    $scope.ZoneAreas.FullList = [];
                    $scope.ZoneAreas.SelectedID = "null";
                    $scope.ClimbingWalls.FullList = [];
                    $scope.ClimbingWalls.SelectedID = "null";
                    $scope.Routes.FullList = [];
                    EnableButtons([DistrictZoneSelectEle, DistrictZoneAddEle, DistrictEditEle, DistrictDeleteEle]);
                    DisableButtons([DistrictZoneEditEle, DistrictZoneDeleteEle,
                        ZoneAreaSelectEle, ZoneAreaAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle,
                        ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
                        AddRockClimbingRouteEle]);
                    $scope.Districts.DeleteDisplay = $scope.Districts.FullList[$scope.Districts.FullList.findIndex(x => x.ID === parseInt(ID))];
                    $scope.Districts.EditChanges = JSON.parse(JSON.stringify($scope.Districts.DeleteDisplay));
                });
            }
            else {
                $scope.DistrictZones.FullList = [];
                $scope.DistrictZones.SelectedID = "null";
                $scope.ZoneAreas.FullList = [];
                $scope.ZoneAreas.SelectedID = "null";
                $scope.ClimbingWalls.FullList = [];
                $scope.ClimbingWalls.SelectedID = "null";
                $scope.Routes.FullList = [];
                DisableButtons([DistrictEditEle, DistrictDeleteEle,
                    DistrictZoneSelectEle, DistrictZoneAddEle, DistrictZoneEditEle, DistrictZoneDeleteEle,
                    ZoneAreaSelectEle, ZoneAreaAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle,
                    ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
                    AddRockClimbingRouteEle]);
            }
        };

        $scope.SelectedDistrictZone = function (ID) {
            if (!isNaN(ID)) {
                WebAPIServices.ZoneAreas.GetList(ID).then(function (result) {
                    $scope.ZoneAreas.FullList = result.data;
                    $scope.ZoneAreas.SelectedID = "null";
                    $scope.ClimbingWalls.FullList = [];
                    $scope.ClimbingWalls.SelectedID = "null";
                    $scope.Routes.FullList = [];
                    EnableButtons([ZoneAreaSelectEle, ZoneAreaAddEle, DistrictZoneEditEle, DistrictZoneDeleteEle]);
                    DisableButtons([ZoneAreaEditEle, ZoneAreaDeleteEle,
                        ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
                        AddRockClimbingRouteEle]);
                    $scope.DistrictZones.DeleteDisplay = $scope.DistrictZones.FullList[$scope.DistrictZones.FullList.findIndex(x => x.ID === parseInt(ID))];
                    $scope.DistrictZones.EditChanges = JSON.parse(JSON.stringify($scope.DistrictZones.DeleteDisplay));
                });
            }
            else {
                $scope.ZoneAreas.FullList = [];
                $scope.ZoneAreas.SelectedID = "null";
                $scope.ClimbingWalls.FullList = [];
                $scope.ClimbingWalls.SelectedID = "null";
                $scope.Routes.FullList = [];
                DisableButtons([DistrictZoneEditEle, DistrictZoneDeleteEle,
                    ZoneAreaSelectEle, ZoneAreaAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle,
                    ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
                    AddRockClimbingRouteEle]);
            }
        };

        $scope.SelectedZoneArea = function (ID) {
            if (!isNaN(ID)) {
                WebAPIServices.ClimbingWalls.GetList(ID).then(function (result) {
                    $scope.ClimbingWalls.FullList = result.data;
                    $scope.ClimbingWalls.SelectedID = "null";
                    $scope.Routes.FullList = [];
                    EnableButtons([ClimbingWallSelectEle, ClimbingWallAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle]);
                    DisableButtons([ClimbingWallEditEle, ClimbingWallDeleteEle,
                        AddRockClimbingRouteEle]);
                    $scope.ZoneAreas.DeleteDisplay = $scope.ZoneAreas.FullList[$scope.ZoneAreas.FullList.findIndex(x => x.ID === parseInt(ID))];
                    $scope.ZoneAreas.EditChanges = JSON.parse(JSON.stringify($scope.ZoneAreas.DeleteDisplay));
                });
            }
            else {
                $scope.ClimbingWalls.FullList = [];
                $scope.ClimbingWalls.SelectedID = "null";
                $scope.Routes.FullList = [];
                DisableButtons([ZoneAreaEditEle, ZoneAreaDeleteEle,
                    ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
                    AddRockClimbingRouteEle]);
            }
        };

        $scope.SelectedClimbingWall = function (ID) {
            if (!isNaN(ID)) {
                WebAPIServices.RockClimbingRoutes.GetList(ID).then(function (result) {
                    $scope.Routes.FullList = result.data;
                    EnableButtons([ClimbingWallEditEle, ClimbingWallDeleteEle,
                        AddRockClimbingRouteEle]);
                    $scope.ClimbingWalls.DeleteDisplay = $scope.ClimbingWalls.FullList[$scope.ClimbingWalls.FullList.findIndex(x => x.ID === parseInt(ID))];
                    $scope.ClimbingWalls.EditChanges = JSON.parse(JSON.stringify($scope.ClimbingWalls.DeleteDisplay));
                });
            }
            else {
                $scope.Routes.FullList = [];
                DisableButtons([ClimbingWallEditEle, ClimbingWallDeleteEle,
                    AddRockClimbingRouteEle]);
            }
        };

        $scope.Regions.Add = function () {
            $scope.Regions.AddNew.ProvinceOrStateID = $scope.ProvincesOrStates.SelectedID;
            WebAPIServices.Regions.Add($scope.Regions.AddNew).then(function (result) {
                WebAPIServices.Regions.GetList($scope.ProvincesOrStates.SelectedID).then(function (result) {
                    $scope.Regions.FullList = result.data;
                });
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.Districts.Add = function () {
            $scope.Districts.AddNew.RegionID = $scope.Regions.SelectedID;
            WebAPIServices.Districts.Add($scope.Districts.AddNew).then(function (result) {
                WebAPIServices.Districts.GetList($scope.Regions.SelectedID).then(function (result) {
                    $scope.Districts.FullList = result.data;
                });
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.DistrictZones.Add = function () {
            $scope.DistrictZones.AddNew.DistrictID = $scope.Districts.SelectedID;
            WebAPIServices.DistrictZones.Add($scope.DistrictZones.AddNew).then(function (result) {
                WebAPIServices.DistrictZones.GetList($scope.Districts.SelectedID).then(function (result) {
                    $scope.DistrictZones.FullList = result.data;
                });
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.ZoneAreas.Add = function () {
            $scope.ZoneAreas.AddNew.DistrictZoneID = $scope.DistrictZones.SelectedID;
            WebAPIServices.ZoneAreas.Add($scope.ZoneAreas.AddNew).then(function (result) {
                WebAPIServices.ZoneAreas.GetList($scope.DistrictZones.SelectedID).then(function (result) {
                    $scope.ZoneAreas.FullList = result.data;
                });
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.ClimbingWalls.Add = function () {
            $scope.ClimbingWalls.AddNew.AreaID = $scope.ZoneAreas.SelectedID;
            WebAPIServices.ClimbingWalls.Add($scope.ClimbingWalls.AddNew).then(function (result) {
                WebAPIServices.ClimbingWalls.GetList($scope.ZoneAreas.SelectedID).then(function (result) {
                    $scope.ClimbingWalls.FullList = result.data;
                });
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.Regions.Edit = function () {
            WebAPIServices.Regions.Update($scope.Regions.SelectedID, $scope.Regions.EditChanges).then(function (result) {
                $scope.SelectedProvinceOrState($scope.ProvincesOrStates.SelectedID);
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.Districts.Edit = function () {
            WebAPIServices.Districts.Update($scope.Districts.SelectedID, $scope.Districts.EditChanges).then(function (result) {
                $scope.SelectedRegion($scope.Regions.SelectedID);
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.DistrictZones.Edit = function () {
            WebAPIServices.DistrictZones.Update($scope.DistrictZones.SelectedID, $scope.DistrictZones.EditChanges).then(function (result) {
                $scope.SelectedDistrict($scope.Districts.SelectedID);
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.ZoneAreas.Edit = function () {
            WebAPIServices.ZoneAreas.Update($scope.ZoneAreas.SelectedID, $scope.ZoneAreas.EditChanges).then(function (result) {
                $scope.SelectedDistrictZone($scope.DistrictZones.SelectedID);
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.ClimbingWalls.Edit = function () {
            WebAPIServices.ClimbingWalls.Update($scope.ClimbingWalls.SelectedID, $scope.ClimbingWalls.EditChanges).then(function (result) {
                $scope.SelectedZoneArea($scope.ZoneAreas.SelectedID);
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.Regions.Delete = function () {
            WebAPIServices.Regions.Delete($scope.Regions.SelectedID).then(function (result) {
                $scope.SelectedProvinceOrState($scope.ProvincesOrStates.SelectedID);
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.Districts.Delete = function () {
            WebAPIServices.Districts.Delete($scope.Districts.SelectedID).then(function (result) {
                $scope.SelectedRegion($scope.Regions.SelectedID);
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.DistrictZones.Delete = function () {
            WebAPIServices.DistrictZones.Delete($scope.DistrictZones.SelectedID).then(function (result) {
                $scope.SelectedDistrict($scope.Districts.SelectedID);
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.ZoneAreas.Delete = function () {
            WebAPIServices.ZoneAreas.Delete($scope.ZoneAreas.SelectedID).then(function (result) {
                $scope.SelectedDistrictZone($scope.DistrictZones.SelectedID);
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.ClimbingWalls.Delete = function () {
            WebAPIServices.ClimbingWalls.Delete($scope.ClimbingWalls.SelectedID).then(function (result) {
                $scope.SelectedZoneArea($scope.ZoneAreas.SelectedID);
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.Routes.Add = function () {
            $scope.Routes.AddNew.ClimbingWallID = $scope.ClimbingWalls.SelectedID
            WebAPIServices.RockClimbingRoutes.Add($scope.Routes.AddNew).then(function (result) {
                WebAPIServices.RockClimbingRoutes.GetList($scope.ClimbingWalls.SelectedID).then(function (result) {
                    $scope.Routes.FullList = result.data;
                });
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.Routes.Edit = function (Route) {
            $scope.Routes.EditChanges = JSON.parse(JSON.stringify(Route));
        };

        $scope.Routes.Update = function () {
            WebAPIServices.RockClimbingRoutes.Update($scope.Routes.EditChanges.ID, $scope.Routes.EditChanges).then(function (result) {
                WebAPIServices.RockClimbingRoutes.GetList($scope.ClimbingWalls.SelectedID).then(function (result) {
                    $scope.Routes.FullList = result.data;
                });
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.Routes.Delete = function (ID) {
            WebAPIServices.RockClimbingRoutes.Delete(ID).then(function (result) {
                WebAPIServices.RockClimbingRoutes.GetList($scope.ClimbingWalls.SelectedID).then(function (result) {
                    $scope.Routes.FullList = result.data;
                });
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.Routes.ViewInfo = function (Route) {
            $scope.RouteInfo.ID = Route.ID;
            RouteInfoEditBoxEle[0].value = Route.RouteInfo;
        };

        $scope.RouteInfo.Edit = function () {
            DisableButtons([RouteInfoEditEle]);
            EnableButtons([RouteInfoSaveEle, RouteInfoEditBoxEle]);
        };

        $scope.RouteInfo.Update = function () {
            var Info = { RouteInfo: RouteInfoEditBoxEle[0].value };
            WebAPIServices.RockClimbingRoutes.Update($scope.RouteInfo.ID, Info).then(function (result) {
                WebAPIServices.RockClimbingRoutes.GetList($scope.ClimbingWalls.SelectedID).then(function (result) {
                    $scope.Routes.FullList = result.data;
                });
                DisableButtons([RouteInfoSaveEle, RouteInfoEditBoxEle]);
                EnableButtons([RouteInfoEditEle]);
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.Routes.ViewGear = function (Route) {
            $scope.Gear.RoutesID = Route.ID;
            $scope.Gear.Add.RockClimbingRoutesID = $scope.Gear.RoutesID;
            $scope.Gear.RoutesList = Route.RoutesGear;
            EnableButtons([RouteInfoEditEle]);;
        }

        $scope.SelectedGearType = function (ID) {
            if (!isNaN(ID)) {
                WebAPIServices.GearSizes.GetList(ID).then(function (result) {
                    $scope.Gear.TypeList = result.data;
                    EnableButtons([SelectGearSizeEle]);
                });
            }
            else {
                $scope.Gear.TypeList = [];
                $scope.Gear.Add.GearSizeID = "null";
                DisableButtons([RouteInfoSaveEle]);
                EnableButtons([RouteInfoEditBoxEle]);
            }
        };

        $scope.Gear.AddItem = function () {
            WebAPIServices.RouteGear.Add($scope.Gear.Add).then(function (result) {
                WebAPIServices.RouteGear.GetList($scope.Gear.RoutesID).then(function (result) {
                    $scope.Gear.RoutesList = result.data
                    $scope.Routes.FullList[$scope.Routes.FullList.findIndex(x => x.ID === $scope.Gear.RoutesID)].RoutesGear = RoutesList;
                });
            }, function (result) { ErrorCallBack(result) });
        };

        $scope.Gear.Delete = function (RockClimbingRoutesID, GearSizeID) {
            WebAPIServices.RouteGear.Delete(RockClimbingRoutesID, GearSizeID).then(function (result) {
                WebAPIServices.RouteGear.GetList($scope.Gear.RoutesID).then(function (result) {
                    $scope.Gear.RoutesList = result.data
                    $scope.Routes.FullList[$scope.Routes.FullList.findIndex(x => x.ID === $scope.Gear.RoutesID)].RoutesGear = $scope.Gear.RoutesList;
                });
            }, function (result) { ErrorCallBack(result) });
        };
    });
    //.filter('ArrayToBase64String', function () {
    //    return function (buffer) {
    //        //not used
    //    };
    //});