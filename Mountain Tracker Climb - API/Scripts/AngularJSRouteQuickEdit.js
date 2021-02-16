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
        return {
            /**
             * The Calls for mail box operations
             */
            Countries: {
                /**
                 * @returns {object} A object containing all of the data for the mail boxes
                 */
                GetCountries: function () {
                    return $http.get(MailHostURL + CountriesController, { responseType: "json" });
                }
            },
            ProvincesOrStates: {
                /**
                 * @param {any} CountryID The ID of the country
                 * @returns {object} A object containing all of the data for the mail boxes
                 */
                GetCountries: function (CountryID) {
                    return $http.get(MailHostURL + ProvincesOrStatesController + "?CountryID=" + CountryID, { responseType: "json" });
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

        $scope.SelectedCountry = function (ID) {
            if (!isNaN(ID)) {
                //ID = parseInt(ID)
                WebAPIServices.ProvincesOrStates.GetCountries(ID).then(function (result) {
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

        WebAPIServices.Countries.GetCountries().then(function (result) {
            $scope.Countries.FullList = result.data;
            $scope.Countries.SelectedID = "null"
        });

        $scope.SelectedProvinceOrState = function (ID) {
            if (!isNaN(ID)) {
                //ID = parseInt(ID)
                WebAPIServices.ProvincesOrStates.GetCountries(ID).then(function (result) {
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

    });
    //.filter('ArrayToBase64String', function () {
    //    return function (buffer) {
    //        //not used
    //    };
    //});