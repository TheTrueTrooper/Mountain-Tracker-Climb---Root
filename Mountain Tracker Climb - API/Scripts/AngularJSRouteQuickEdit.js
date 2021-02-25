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
        const MailHostURL = "http://localhost:12699/Api/";
        const CountriesController = "Counties";
        const ProvincesOrStatesController = "ProvincesOrStates";
        const RegionsController = "Regions";
        const DistrictsController = "Districts";
        const DistrictZonesController = "DistrictZones";
        const ZoneAreasController = "ZoneAreas";
        const ClimbingWallsController = "ClimbingWalls";
        const RockClimbingRoutesController = "RockClimbingRoutes";
        return {
            /**
             * The Calls for mail box operations
             */
            Countries: {
                /**
                 * @returns {object} A object containing all of the data
                 */
                GetList: function () {
                    return $http.get(MailHostURL + CountriesController, { responseType: "json" });
                }
            },
            ProvincesOrStates: {
                /**
                 * @param {any} CountryID The ID of the country
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (CountryID) {
                    return $http.get(MailHostURL + ProvincesOrStatesController + "?CountryID=" + CountryID, { responseType: "json" });
                }
            },
            Regions: {
                /**
                 * @param {any} ProvinceOrStateID The ID of the Province Or State
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (ProvinceOrStateID) {
                    return $http.get(MailHostURL + RegionsController + "?ProvinceOrStateID=" + ProvinceOrStateID, { responseType: "json" });
                },
                /**
                 * @param {object} NewRegion The data for the new region to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewRegion) {
                    return $http.post(MailHostURL + RegionsController, NewRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the Region to edit
                 * @returns {object} A object containing all of the data
                 */
                Update: function (ID, EditedRegion) {
                    return $http.put(MailHostURL + RegionsController + "/" + ID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the Region to delete
                 * @returns {object} A object containing all of the data
                 */
                Delete: function (ID) {
                    return $http.delete(MailHostURL + RegionsController + "/" + ID, { responseType: "json" });
                }
            },
            Districts: {
                /**
                 * @param {any} RegionID The ID of the Region
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (RegionID) {
                    return $http.get(MailHostURL + DistrictsController + "?RegionID=" + RegionID, { responseType: "json" });
                },
                /**
                 * @param {object} NewDistrict The data for the new District to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewDistrict) {
                    return $http.post(MailHostURL + DistrictsController, NewDistrict, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the District to edit
                 * @returns {object} A object containing all of the data
                 */
                Update: function (ID, EditedRegion) {
                    return $http.put(MailHostURL + DistrictsController + "/" + ID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ProvinceOrStateID The ID of the District to delete
                 * @returns {object} A object containing all of the data
                 */
                Delete: function (ID) {
                    return $http.delete(MailHostURL + DistrictsController + "/" + ID, { responseType: "json" });
                }
            },
            DistrictZones: {
                /**
                 * @param {any} DistrictID The ID of the District
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (DistrictID) {
                    return $http.get(MailHostURL + DistrictZonesController + "?DistrictID=" + DistrictID, { responseType: "json" });
                },
                /**
                 * @param {object} NewZone The data for the new Zone to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewZone) {
                    return $http.post(MailHostURL + DistrictZonesController, NewZone, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID to edit
                 * @returns {object} A object containing all of the data
                 */
                Update: function (ID, EditedRegion) {
                    return $http.put(MailHostURL + DistrictZonesController + "/" + ID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ProvinceOrStateID The ID of the District to delete
                 * @returns {object} A object containing all of the data
                 */
                Delete: function (ID) {
                    return $http.delete(MailHostURL + DistrictZonesController + "/" + ID, { responseType: "json" });
                }
            },
            ZoneAreas: {
                /**
                 * @param {any} ZoneID The ID of the Zone
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (ZoneID) {
                    return $http.get(MailHostURL + ZoneAreasController + "?ZoneID=" + ZoneID, { responseType: "json" });
                },
                /**
                 * @param {object} NewArea The data for the new Area to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewArea) {
                    return $http.post(MailHostURL + ZoneAreasController, NewArea, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID to edit
                 * @returns {object} A object containing all of the data
                 */
                Update: function (ID, EditedRegion) {
                    return $http.put(MailHostURL + ZoneAreasController + "/" + ID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ProvinceOrStateID The ID of the District to delete
                 * @returns {object} A object containing all of the data
                 */
                Delete: function (ID) {
                    return $http.delete(MailHostURL + ZoneAreasController + "/" + ID, { responseType: "json" });
                }
            },
            ClimbingWalls: {
                /**
                 * @param {any} AreaID The ID of the Area
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (AreaID) {
                    return $http.get(MailHostURL + ClimbingWallsController + "?AreaID=" + AreaID, { responseType: "json" });
                },
                /**
                 * @param {object} NewClimbingWall The data for the new ClimbingWall to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewClimbingWall) {
                    return $http.post(MailHostURL + ClimbingWallsController, NewClimbingWall, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID to edit
                 * @returns {object} A object containing all of the data
                 */
                Update: function (ID, EditedRegion) {
                    return $http.put(MailHostURL + ClimbingWallsController + "/" + ID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ProvinceOrStateID The ID of the District to delete
                 * @returns {object} A object containing all of the data
                 */
                Delete: function (ID) {
                    return $http.delete(MailHostURL + ClimbingWallsController + "/" + ID, { responseType: "json" });
                }
            },
            RockClimbingRoutes: {
                /**
                 * @param {any} AreaID The ID of the Area
                 * @returns {object} A object containing all of the data
                 */
                GetList: function (AreaID) {
                    return $http.get(MailHostURL + RockClimbingRoutesController + "?AreaID=" + AreaID, { responseType: "json" });
                },
                /**
                 * @param {object} NewRockClimbingRoute The data for the new RockClimbingRoute to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewRockClimbingRoute) {
                    return $http.post(MailHostURL + RockClimbingRoutesController, NewRockClimbingRoute, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID to edit
                 * @returns {object} A object containing all of the data
                 */
                Update: function (ID, EditedRegion) {
                    return $http.put(MailHostURL + RockClimbingRoutesController + "/" + ID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ProvinceOrStateID The ID of the District to delete
                 * @returns {object} A object containing all of the data
                 */
                Delete: function (ID) {
                    return $http.delete(MailHostURL + RockClimbingRoutesController + "/" + ID, { responseType: "json" });
                }
            },
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
        $scope.Routes = {};

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
            $window.alert("Status: " + (result.status || "Error") + "\nMessage: " + (result.data.Message || 'Request failed for unknow reason.') + "\nExceptionMessage: " + (result.data.ExceptionMessage || 'Request failed for unknow reason.'));
        };

        DisableButtons([ProvSelectEle,
            RegionSelectEle, RegionAddEle, RegionAddEle, RegionEditEle, RegionDeleteEle,
            DistrictSelectEle, DistrictAddEle, DistrictEditEle, DistrictDeleteEle,
            DistrictZoneSelectEle, DistrictZoneAddEle, DistrictZoneEditEle, DistrictZoneDeleteEle,
            ZoneAreaSelectEle, ZoneAreaAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle,
            ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
            AddRockClimbingRouteEle]);

        WebAPIServices.Countries.GetList().then(function (result) {
            $scope.Countries.FullList = result.data;
            $scope.Countries.SelectedID = "null"
        });

        $scope.SelectedCountry = function (ID) {
            if (!isNaN(ID)) {
                WebAPIServices.ProvincesOrStates.GetList(ID).then(function (result) {
                    $scope.ProvincesOrStates.FullList = result.data;
                    $scope.ProvincesOrStates.SelectedID = "null"
                    $scope.Regions.FullList = []
                    $scope.Regions.SelectedID = "null"
                    $scope.Districts.FullList = []
                    $scope.Districts.SelectedID = "null"
                    $scope.DistrictZones.FullList = []
                    $scope.DistrictZones.SelectedID = "null"
                    $scope.ZoneAreas.FullList = []
                    $scope.ZoneAreas.SelectedID = "null"
                    $scope.ClimbingWalls.FullList = []
                    $scope.ClimbingWalls.SelectedID = "null"
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
                $scope.ProvincesOrStates.FullList = []
                $scope.ProvincesOrStates.SelectedID = "null"
                $scope.Regions.FullList = []
                $scope.Regions.SelectedID = "null"
                $scope.Districts.FullList = []
                $scope.Districts.SelectedID = "null"
                $scope.DistrictZones.FullList = []
                $scope.DistrictZones.SelectedID = "null"
                $scope.ZoneAreas.FullList = []
                $scope.ZoneAreas.SelectedID = "null"
                $scope.ClimbingWalls.FullList = []
                $scope.ClimbingWalls.SelectedID = "null"
                $scope.Routes.FullList = []
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
                    $scope.Regions.SelectedID = "null"
                    $scope.Districts.FullList = []
                    $scope.Districts.SelectedID = "null"
                    $scope.DistrictZones.FullList = []
                    $scope.DistrictZones.SelectedID = "null"
                    $scope.ZoneAreas.FullList = []
                    $scope.ZoneAreas.SelectedID = "null"
                    $scope.ClimbingWalls.FullList = []
                    $scope.ClimbingWalls.SelectedID = "null"
                    $scope.Routes.FullList = []
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
                $scope.Regions.FullList = []
                $scope.Regions.SelectedID = "null"
                $scope.Districts.FullList = []
                $scope.Districts.SelectedID = "null"
                $scope.DistrictZones.FullList = []
                $scope.DistrictZones.SelectedID = "null"
                $scope.ZoneAreas.FullList = []
                $scope.ZoneAreas.SelectedID = "null"
                $scope.ClimbingWalls.FullList = []
                $scope.ClimbingWalls.SelectedID = "null"
                $scope.Routes.FullList = []
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
                    $scope.Districts.SelectedID = "null"
                    $scope.DistrictZones.FullList = []
                    $scope.DistrictZones.SelectedID = "null"
                    $scope.ZoneAreas.FullList = []
                    $scope.ZoneAreas.SelectedID = "null"
                    $scope.ClimbingWalls.FullList = []
                    $scope.ClimbingWalls.SelectedID = "null"
                    $scope.Routes.FullList = []
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
                $scope.Districts.FullList = []
                $scope.Districts.SelectedID = "null"
                $scope.DistrictZones.FullList = []
                $scope.DistrictZones.SelectedID = "null"
                $scope.ZoneAreas.FullList = []
                $scope.ZoneAreas.SelectedID = "null"
                $scope.ClimbingWalls.FullList = []
                $scope.ClimbingWalls.SelectedID = "null"
                $scope.Routes.FullList = []
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
                    $scope.DistrictZones.SelectedID = "null"
                    $scope.ZoneAreas.FullList = []
                    $scope.ZoneAreas.SelectedID = "null"
                    $scope.ClimbingWalls.FullList = []
                    $scope.ClimbingWalls.SelectedID = "null"
                    $scope.Routes.FullList = []
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
                $scope.DistrictZones.FullList = []
                $scope.DistrictZones.SelectedID = "null"
                $scope.ZoneAreas.FullList = []
                $scope.ZoneAreas.SelectedID = "null"
                $scope.ClimbingWalls.FullList = []
                $scope.ClimbingWalls.SelectedID = "null"
                $scope.Routes.FullList = []
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
                    $scope.ZoneAreas.SelectedID = "null"
                    $scope.ClimbingWalls.FullList = []
                    $scope.ClimbingWalls.SelectedID = "null"
                    $scope.Routes.FullList = []
                    EnableButtons([ZoneAreaSelectEle, ZoneAreaAddEle, DistrictZoneEditEle, DistrictZoneDeleteEle]);
                    DisableButtons([ZoneAreaEditEle, ZoneAreaDeleteEle,
                        ClimbingWallSelectEle, ClimbingWallAddEle, ClimbingWallEditEle, ClimbingWallDeleteEle,
                        AddRockClimbingRouteEle]);
                    $scope.DistrictZones.DeleteDisplay = $scope.DistrictZones.FullList[$scope.DistrictZones.FullList.findIndex(x => x.ID === parseInt(ID))];
                    $scope.DistrictZones.EditChanges = JSON.parse(JSON.stringify($scope.DistrictZones.DeleteDisplay));
                });
            }
            else {
                $scope.ZoneAreas.FullList = []
                $scope.ZoneAreas.SelectedID = "null"
                $scope.ClimbingWalls.FullList = []
                $scope.ClimbingWalls.SelectedID = "null"
                $scope.Routes.FullList = []
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
                    $scope.ClimbingWalls.SelectedID = "null"
                    $scope.Routes.FullList = []
                    EnableButtons([ClimbingWallSelectEle, ClimbingWallAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle]);
                    DisableButtons([ClimbingWallEditEle, ClimbingWallDeleteEle,
                        AddRockClimbingRouteEle]);
                    $scope.ZoneAreas.DeleteDisplay = $scope.ZoneAreas.FullList[$scope.ZoneAreas.FullList.findIndex(x => x.ID === parseInt(ID))];
                    $scope.ZoneAreas.EditChanges = JSON.parse(JSON.stringify($scope.ZoneAreas.DeleteDisplay));
                });
            }
            else {
                $scope.ClimbingWalls.FullList = []
                $scope.ClimbingWalls.SelectedID = "null"
                $scope.Routes.FullList = []
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
                $scope.Routes.FullList = []
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

    });
    //.filter('ArrayToBase64String', function () {
    //    return function (buffer) {
    //        //not used
    //    };
    //});