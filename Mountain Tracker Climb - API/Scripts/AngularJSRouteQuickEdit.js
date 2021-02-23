﻿/* WritersSigniture
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
                Edit: function (ID, EditedRegion) {
                    return $http.put(MailHostURL + RegionsController + "/" + ID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the Region to delete
                 * @returns {object} A object containing all of the data
                 */
                DeleteList: function (ID) {
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
                 * @param {any} ProvinceOrStateID The ID of the District to edit
                 * @returns {object} A object containing all of the data
                 */
                Edit: function (RegionID, EditedRegion) {
                    return $http.put(MailHostURL + DistrictsController + "/" + RegionID, EditedRegion, { responseType: "json" });
                },
                /**
                 * @param {any} ProvinceOrStateID The ID of the District to delete
                 * @returns {object} A object containing all of the data
                 */
                DeleteList: function (ID) {
                    return $http.delete(MailHostURL + DistrictsController + "/" + ID, { responseType: "json" });
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
            }
        };
        $scope.Districts = { SelectedID: "null" };
        $scope.DistrictZones = { SelectedID: "null" };
        $scope.ZoneAreas = { SelectedID: "null" };
        $scope.ClimbingWalls = { SelectedID: "null" };

        var ProvSelectEle = angular.element($("#SelectProvinceOrState")); 
        var RegionSelectEle = angular.element($("#SelectRegion"));
        var RegionAddEle = angular.element($("#AddRegion"));
        var RegionEditEle = angular.element($("#EditRegion"));
        var RegionDeleteEle = angular.element($("#DeleteRegion"));
        var DistrictSelectEle = angular.element($("#SelectDistrict"));
        var DistrictAddEle = angular.element($("#AddDistrict"));
        var DistrictEditEle = angular.element($("#EditDistrict"));
        var DistrictDeleteEle = angular.element($("#DeleteDistrict"));

        $scope.SelectedCountry = function (ID) {
            if (!isNaN(ID)) {
                //ID = parseInt(ID)
                WebAPIServices.ProvincesOrStates.GetList(ID).then(function (result) {
                    $scope.ProvincesOrStates.FullList = result.data;
                    $scope.ProvincesOrStates.SelectedID = "null"
                    ProvSelectEle.attr('disabled', false);
                });
            }
            else {
                $scope.ProvincesOrStates.FullList = []
                $scope.ProvincesOrStates.SelectedID = "null"
                $scope.Regions.FullList = []
                $scope.Regions.SelectedID = "null"
                ProvSelectEle.attr('disabled', true);
                RegionSelectEle.attr('disabled', true);
                RegionAddEle.attr('disabled', true);
                RegionEditEle.attr('disabled', true);
                RegionDeleteEle.attr('disabled', true);
            }
        };

        WebAPIServices.Countries.GetList().then(function (result) {
            $scope.Countries.FullList = result.data;
            $scope.Countries.SelectedID = "null"
        });

        $scope.SelectedProvinceOrState = function (ID) {
            if (!isNaN(ID)) {
                //ID = parseInt(ID)
                WebAPIServices.Regions.GetList(ID).then(function (result) {
                    $scope.Regions.FullList = result.data;
                    $scope.Regions.SelectedID = "null"
                    RegionSelectEle.attr('disabled', false);
                    RegionAddEle.attr('disabled', false);
                });
            }
            else {
                $scope.Regions.FullList = []
                $scope.Regions.SelectedID = "null"
                RegionSelectEle.attr('disabled', true);
                RegionAddEle.attr('disabled', true);
                RegionEditEle.attr('disabled', true);
                RegionDeleteEle.attr('disabled', true);
            }
        };

        $scope.SelectedRegion = function (ID) {
            if (!isNaN(ID)) {
                //ID = parseInt(ID)
                WebAPIServices.Districts.GetList(ID).then(function (result) {
                    $scope.Districts.FullList = result.data;
                    $scope.Districts.SelectedID = "null"
                    DistrictSelectEle.attr('disabled', false);
                    DistrictAddEle.attr('disabled', false);
                });
            }
            else {
                $scope.Districts.FullList = []
                $scope.Districts.SelectedID = "null"
            }
        }


        $scope.Regions.Add = function () {
            $scope.Regions.AddNew.ProvinceOrStateID = $scope.ProvincesOrStates.SelectedID;
            WebAPIServices.Regions.Add($scope.Regions.AddNew).then(function (result) {
                WebAPIServices.Regions.GetList($scope.ProvincesOrStates.SelectedID).then(function (result) {
                    $scope.Regions.FullList = result.data;
                });
            });
        }


    });
    //.filter('ArrayToBase64String', function () {
    //    return function (buffer) {
    //        //not used
    //    };
    //});