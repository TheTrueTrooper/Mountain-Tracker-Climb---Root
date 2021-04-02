/// <reference path="AngularJSMtnAPI.js" />
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
angular.module("NGRouteQuickEdit", ["NGMtnWebAPI", "ngRoute", "ngSanitize", "ngCookies"])
    .controller("RouteQuickEditController", function ($window, $scope, $sce, MtnWebAPIServices, MtnWebAPIServicesHelper) {
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

        MtnWebAPIServices.Countries.GetList().then(function (result) {
            $scope.Countries.FullList = result.data;
            $scope.Countries.SelectedID = "null";
        });

        MtnWebAPIServices.RockClimbingDifficulties.GetList().then(function (result) {
            $scope.RockClimbingDifficulties = result.data;
            $scope.Routes.AddNew.TypeID = "null";
        });

        MtnWebAPIServices.ClimbingTypes.GetList().then(function (result) {
            $scope.ClimbingTypes = result.data;
            $scope.Routes.AddNew.DifficultyID = "null";
        });

        MtnWebAPIServices.Gear.GetList().then(function (result) {
            $scope.Gear.FullList = result.data;
            $scope.Gear.Add.GearID = "null";
            $scope.Gear.Add.GearSizeID = "null";
        });

        $scope.SelectedCountry = function (ID) {
            if (!isNaN(ID)) {
                MtnWebAPIServices.ProvincesOrStates.GetList(ID).then(function (result) {
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
                MtnWebAPIServices.Regions.GetList(ID).then(function (result) {
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
                MtnWebAPIServices.Districts.GetList(ID).then(function (result) {
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
                MtnWebAPIServices.DistrictZones.GetList(ID).then(function (result) {
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
                MtnWebAPIServices.ZoneAreas.GetList(ID).then(function (result) {
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
                MtnWebAPIServices.ClimbingWalls.GetList(ID).then(function (result) {
                    $scope.ClimbingWalls.FullList = result.data;
                    $scope.ClimbingWalls.SelectedID = "null";
                    $scope.Routes.FullList = [];
                    EnableButtons([ClimbingWallSelectEle, ClimbingWallAddEle, ZoneAreaEditEle, ZoneAreaDeleteEle]);
                    DisableButtons([ClimbingWallEditEle, ClimbingWallDeleteEle,
                        AddRockClimbingRouteEle]);
                    $scope.ZoneAreas.DeleteDisplay = $scope.ZoneAreas.FullList[$scope.ZoneAreas.FullList.findIndex(x => x.ID === parseInt(ID))];
                    $scope.ZoneAreas.EditChanges = JSON.parse(JSON.stringify($scope.ZoneAreas.DeleteDisplay));
                    $scope.ZoneAreas.EditChanges.AreaCode = $scope.ZoneAreas.EditChanges.AreaCode.substring(1);
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
                MtnWebAPIServices.RockClimbingRoutes.GetList(ID).then(function (result) {
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
            MtnWebAPIServices.Regions.Add($scope.Regions.AddNew).then(function (result) {
                MtnWebAPIServices.Regions.GetList($scope.ProvincesOrStates.SelectedID).then(function (result) {
                    $scope.Regions.FullList = result.data;
                });
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.Districts.Add = function () {
            $scope.Districts.AddNew.RegionID = $scope.Regions.SelectedID;
            MtnWebAPIServices.Districts.Add($scope.Districts.AddNew).then(function (result) {
                MtnWebAPIServices.Districts.GetList($scope.Regions.SelectedID).then(function (result) {
                    $scope.Districts.FullList = result.data;
                });
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.DistrictZones.Add = function () {
            $scope.DistrictZones.AddNew.DistrictID = $scope.Districts.SelectedID;
            MtnWebAPIServices.DistrictZones.Add($scope.DistrictZones.AddNew).then(function (result) {
                MtnWebAPIServices.DistrictZones.GetList($scope.Districts.SelectedID).then(function (result) {
                    $scope.DistrictZones.FullList = result.data;
                });
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.ZoneAreas.Add = function () {
            $scope.ZoneAreas.AddNew.DistrictZoneID = $scope.DistrictZones.SelectedID;
            $scope.ZoneAreas.AddNew.AreaCode = "W" + $scope.ZoneAreas.AddNew.AreaCode;
            MtnWebAPIServices.ZoneAreas.Add($scope.ZoneAreas.AddNew).then(function (result) {
                MtnWebAPIServices.ZoneAreas.GetList($scope.DistrictZones.SelectedID).then(function (result) {
                    $scope.ZoneAreas.FullList = result.data;
                    $scope.ZoneAreas.AddNew.AreaCode = $scope.ZoneAreas.AddNew.AreaCode.substring(1);
                });
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result); $scope.ZoneAreas.AddNew.AreaCode = $scope.ZoneAreas.AddNew.AreaCode.substring(1); });
        };

        $scope.ClimbingWalls.Add = function () {
            $scope.ClimbingWalls.AddNew.AreaID = $scope.ZoneAreas.SelectedID;
            MtnWebAPIServices.ClimbingWalls.Add($scope.ClimbingWalls.AddNew).then(function (result) {
                MtnWebAPIServices.ClimbingWalls.GetList($scope.ZoneAreas.SelectedID).then(function (result) {
                    $scope.ClimbingWalls.FullList = result.data;
                });
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.Regions.Edit = function () {
            MtnWebAPIServices.Regions.Update($scope.Regions.SelectedID, $scope.Regions.EditChanges).then(function (result) {
                $scope.SelectedProvinceOrState($scope.ProvincesOrStates.SelectedID);
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.Districts.Edit = function () {
            MtnWebAPIServices.Districts.Update($scope.Districts.SelectedID, $scope.Districts.EditChanges).then(function (result) {
                $scope.SelectedRegion($scope.Regions.SelectedID);
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.DistrictZones.Edit = function () {
            MtnWebAPIServices.DistrictZones.Update($scope.DistrictZones.SelectedID, $scope.DistrictZones.EditChanges).then(function (result) {
                $scope.SelectedDistrict($scope.Districts.SelectedID);
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.ZoneAreas.Edit = function () {
            $scope.ZoneAreas.EditChanges.AreaCode = "W" + $scope.ZoneAreas.EditChanges.AreaCode;
            MtnWebAPIServices.ZoneAreas.Update($scope.ZoneAreas.SelectedID, $scope.ZoneAreas.EditChanges).then(function (result) {
                $scope.SelectedDistrictZone($scope.DistrictZones.SelectedID);
                $scope.ZoneAreas.EditChanges.AreaCode = $scope.ZoneAreas.EditChanges.AreaCode.substring(1);
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result); $scope.ZoneAreas.EditChanges.AreaCode = $scope.ZoneAreas.EditChanges.AreaCode.substring(1); });
        };

        $scope.ClimbingWalls.Edit = function () {
            MtnWebAPIServices.ClimbingWalls.Update($scope.ClimbingWalls.SelectedID, $scope.ClimbingWalls.EditChanges).then(function (result) {
                $scope.SelectedZoneArea($scope.ZoneAreas.SelectedID);
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.Regions.Delete = function () {
            MtnWebAPIServices.Regions.Delete($scope.Regions.SelectedID).then(function (result) {
                $scope.SelectedProvinceOrState($scope.ProvincesOrStates.SelectedID);
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.Districts.Delete = function () {
            MtnWebAPIServices.Districts.Delete($scope.Districts.SelectedID).then(function (result) {
                $scope.SelectedRegion($scope.Regions.SelectedID);
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.DistrictZones.Delete = function () {
            MtnWebAPIServices.DistrictZones.Delete($scope.DistrictZones.SelectedID).then(function (result) {
                $scope.SelectedDistrict($scope.Districts.SelectedID);
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.ZoneAreas.Delete = function () {
            MtnWebAPIServices.ZoneAreas.Delete($scope.ZoneAreas.SelectedID).then(function (result) {
                $scope.SelectedDistrictZone($scope.DistrictZones.SelectedID);
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.ClimbingWalls.Delete = function () {
            MtnWebAPIServices.ClimbingWalls.Delete($scope.ClimbingWalls.SelectedID).then(function (result) {
                $scope.SelectedZoneArea($scope.ZoneAreas.SelectedID);
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.Routes.Add = function () {
            $scope.Routes.AddNew.ClimbingWallID = $scope.ClimbingWalls.SelectedID
            MtnWebAPIServices.RockClimbingRoutes.Add($scope.Routes.AddNew).then(function (result) {
                MtnWebAPIServices.RockClimbingRoutes.GetList($scope.ClimbingWalls.SelectedID).then(function (result) {
                    $scope.Routes.FullList = result.data;
                });
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.Routes.Edit = function (Route) {
            $scope.Routes.EditChanges = JSON.parse(JSON.stringify(Route));
        };

        $scope.Routes.Update = function () {
            MtnWebAPIServices.RockClimbingRoutes.Update($scope.Routes.EditChanges.ID, $scope.Routes.EditChanges).then(function (result) {
                MtnWebAPIServices.RockClimbingRoutes.GetList($scope.ClimbingWalls.SelectedID).then(function (result) {
                    $scope.Routes.FullList = result.data;
                });
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.Routes.Delete = function (ID) {
            MtnWebAPIServices.RockClimbingRoutes.Delete(ID).then(function (result) {
                MtnWebAPIServices.RockClimbingRoutes.GetList($scope.ClimbingWalls.SelectedID).then(function (result) {
                    $scope.Routes.FullList = result.data;
                });
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
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
            MtnWebAPIServices.RockClimbingRoutes.Update($scope.RouteInfo.ID, Info).then(function (result) {
                MtnWebAPIServices.RockClimbingRoutes.GetList($scope.ClimbingWalls.SelectedID).then(function (result) {
                    $scope.Routes.FullList = result.data;
                });
                DisableButtons([RouteInfoSaveEle, RouteInfoEditBoxEle]);
                EnableButtons([RouteInfoEditEle]);
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.Routes.ViewGear = function (Route) {
            $scope.Gear.RoutesID = Route.ID;
            $scope.Gear.Add.RockClimbingRoutesID = $scope.Gear.RoutesID;
            $scope.Gear.RoutesList = Route.RoutesGear;
            EnableButtons([RouteInfoEditEle]);;
        }

        $scope.SelectedGearType = function (ID) {
            if (!isNaN(ID)) {
                MtnWebAPIServices.GearSizes.GetList(ID).then(function (result) {
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
            MtnWebAPIServices.RouteGear.Add($scope.Gear.Add).then(function (result) {
                MtnWebAPIServices.RouteGear.GetList($scope.Gear.RoutesID).then(function (result) {
                    $scope.Gear.RoutesList = result.data
                    $scope.Routes.FullList[$scope.Routes.FullList.findIndex(x => x.ID === $scope.Gear.RoutesID)].RoutesGear = RoutesList;
                });
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };

        $scope.Gear.Delete = function (RockClimbingRoutesID, GearSizeID) {
            MtnWebAPIServices.RouteGear.Delete(RockClimbingRoutesID, GearSizeID).then(function (result) {
                MtnWebAPIServices.RouteGear.GetList($scope.Gear.RoutesID).then(function (result) {
                    $scope.Gear.RoutesList = result.data
                    $scope.Routes.FullList[$scope.Routes.FullList.findIndex(x => x.ID === $scope.Gear.RoutesID)].RoutesGear = $scope.Gear.RoutesList;
                });
            }, function (result) { MtnWebAPIServicesHelper.QuickErrorHandle(result) });
        };
    });
    //.filter('ArrayToBase64String', function () {
    //    return function (buffer) {
    //        //not used
    //    };
    //});