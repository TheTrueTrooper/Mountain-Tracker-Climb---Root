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
angular.module("NGMtnWebAPI", [])
    //.value("$", $)//import 
    //.run(function ($http) {
    //    try { is slower to run here
    //        const TokenID = "IDToken";
    //        var TokenStorage = document.getElementById(TokenID);
    //        $http.defaults.headers.common['Authorization'] = "Bearer " + TokenStorage.value;
    //        TokenStorage.parentNode.removeChild(TokenStorage);
    //    }
    //    catch(e)
    //    {
    //        console.log("NGMtnWebAPI failed to locate API Security Token");
    //    }
    //})
    .service("MtnWebAPIServices", function ($http) {
        //const HostURL = "http://mtntracker.com/Api/";
        //const HostURL = "http://localhost:12699/Api/";
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
        const UserAccountController = "UserAccount";
        const UserPartnerController = "UserPartner";
        const UserDMsController = "UserDMs";

        function GetRoot(URL) {
            var Index = URL.indexOf("/");
            Index = URL.indexOf("/", Index + 1);
            Index = URL.indexOf("/", Index + 1);
            return URL.substring(0, Index)
        }

        var HostURL = GetRoot(document.URL) + "/Api/"; //"http://localhost:12699/Api/";


        try {
            const TokenID = "IDToken";
            var TokenStorage = document.getElementById(TokenID);
            $http.defaults.headers.common['Authorization'] = "Bearer " + TokenStorage.value;
            TokenStorage.parentNode.removeChild(TokenStorage);
        }
        catch
        {
            console.warn("No Token key on this page. Some API features may require token.")
        }
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
                GetAll: function () {
                    return $http.get(HostURL + ProvincesOrStatesController, { responseType: "json" });
                },
                /**
                 * @param {any} CountryID The ID of the country
                 * @returns {object} A object containing all of the data
                */
                GetList: function (CountryID) {
                    return $http.get(HostURL + ProvincesOrStatesController + "?CountryID=" + CountryID, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the Prov
                 * @returns {object} A object containing all of the data
                 */
                Get: function (ID) {
                    return $http.get(HostURL + ProvincesOrStatesController + "/" + ID, { responseType: "json" });
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
            },
            UserAccount: {
                /**
                 * @param {any} ID The ID of the User
                 * @returns {object} A object containing all of the data
                 */
                Get: function (ID) {
                    return $http.get(HostURL + UserAccountController + "/" + ID, { responseType: "json" });
                },
                /**
                 * @param {any} NameSearch The name you are searching for
                 * @returns {object} A object containing all of the data
                 */
                GetSearchList: function (NameSearch) {
                    return $http.get(HostURL + UserAccountController + "?NameSearch=" + NameSearch, { responseType: "json" });
                },
                /**
                 * @param {object} NewUser The data for the new User to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewUser) {
                    return $http.post(HostURL + UserAccountController, NewUser, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the User to update
                 * @param {any} GearSizeID The ID of the Gear Size to delete
                 * @returns {object} A object containing all of the data
                 */
                Update: function (ID, EditedUser) {
                    return $http.put(HostURL + UserAccountController + "/" + ID, EditedUser, { responseType: "json" });
                },
                /**
                 * @param {any} RockClimbingRoutesID The ID of the User to delete
                 * @param {any} GearSizeID The ID of the Gear Size to delete
                 * @returns {object} A object containing all of the data
                 */
                UploadProfilePicture: function (ID, File) {
                    var Data = new FormData();
                    Data.append('data', {});
                    Data.append('file', File);
                    return $http.put(HostURL + UserAccountController + "/" + ID + "/ProfilePicture", Data, { transformRequest: angular.identity, headers: { 'Content-Type': undefined }, responseType: "json" });
                },
                GetProfilePicture: function (ID) {
                    return $http.get(HostURL + UserAccountController + "/" + ID + "/ProfilePicture", {});
                },
                DeleteProfilePicture: function (ID) {
                    return $http.delete(HostURL + UserAccountController + "/" + ID + "/ProfilePicture", { responseType: "json" });
                },
                UploadBannerPicture: function (ID, File) {
                    var Data = new FormData();
                    Data.append('data', {});
                    Data.append('file', File);
                    return $http.put(HostURL + UserAccountController + "/" + ID + "/BannerPicture", Data, { transformRequest: angular.identity, headers: { 'Content-Type': undefined }, responseType: "json" });
                },
                GetBannerPicture: function (ID) {
                    return $http.get(HostURL + UserAccountController + "/" + ID + "/BannerPicture", { responseType: "json"});
                },
                DeleteBannerPicture: function (ID) {
                    return $http.delete(HostURL + UserAccountController + "/" + ID + "/BannerPicture", {});
                },
                Delete: function (ID) {
                    return $http.delete(HostURL + UserAccountController + "/" + ID, { responseType: "json" });
                }
            },
            UserPartner: {
                /**
                 * @param {any} ID The ID of the User
                 * @returns {object} A object containing all of the data
                 */
                Get: function (ID) {
                    return $http.get(HostURL + UserPartnerController + "/" + ID, { responseType: "json" });
                },
                /**
                 * @param {any} UserID 
                 * @param {any} FriendID
                 * @returns {object} A object containing all of the data
                 */
                CheckFriendShip: function (UserID, FriendID) {
                    return $http.get(HostURL + UserPartnerController + "?UserID=" + UserID + "&FriendID=" + FriendID, { responseType: "json" });
                },
                /**
                 * @param {any} UserID 
                 * @param {any} FriendID
                 * @returns {object} A object containing all of the data
                 */
                CheckForFriendRequest: function (UserID, FriendID) {
                    return $http.get(HostURL + UserPartnerController + "?UserID=" + UserID + "&FriendID=" + FriendID + "&Requests", { responseType: "json" });
                },
                /**
                 * @param {object} NewUser The data for the new User to add
                 * @returns {object} A object containing all of the data
                 */
                Accept: function (NewUser) {
                    return $http.put(HostURL + UserPartnerController, NewUser, { responseType: "json" });
                },
                /**
                 * @param {object} NewUser The data for the new User to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewUser) {
                    return $http.post(HostURL + UserPartnerController, NewUser, { responseType: "json" });
                },
                Delete: function (UserFromID, UserToID) {
                    return $http.delete(HostURL + UserPartnerController + "?UserFromID=" + UserFromID + "&UserToID=" + UserToID, { responseType: "json" });
                }
            },
            UserDMs: {
                /**
                 * @param {any} ID The ID of the User
                 * @returns {object} A object containing all of the data
                 */
                GetAll: function (ID) {
                    return $http.get(HostURL + UserDMsController + "/" + ID, { responseType: "json" });
                },
                /**
                 * @param {any} ID The ID of the User
                 * @returns {object} A object containing all of the data
                 */
                Get: function (ID, WithUserID) {
                    return $http.get(HostURL + UserDMsController + "/" + ID + "?WithUserID=" + WithUserID, { responseType: "json" });
                },
                /**
                 * @param {any} MessageID The ID of the Message to update
                 * @param {any} GearSizeID The ID of the Gear Size to delete
                 * @returns {object} A object containing all of the data
                 */
                Update: function (MessageID, EditedUser) {
                    return $http.put(HostURL + UserAccountController + "/" + MessageID, EditedUser, { responseType: "json" });
                },
                /**
                 * @param {object} NewMessage The data for the new Message to add
                 * @returns {object} A object containing all of the data
                 */
                Add: function (NewMessage) {
                    return $http.post(HostURL + UserDMsController, NewMessage, { responseType: "json" });
                },
                Delete: function (MessageID, UserFromID) {
                    return $http.delete(HostURL + UserPartnerController + "?MessageID=" + MessageID + "&UserFromID=" + UserFromID, { responseType: "json" });
                }
            }
        };
    })
    .factory('AccountHelper', function (MtnWebAPIServicesHelper) {
        var ServerRoot = MtnWebAPIServicesHelper.ServerRoot;
        //var ServerAPIRoot = MtnWebAPIServicesHelper.ServerRoot
        var APIAccountsRoot = MtnWebAPIServicesHelper.ServerRoot + '/Api/UserAccount/';
        var ViewAccountsRoot = MtnWebAPIServicesHelper.ServerRoot + '/Account/';
        return {
            ContentURL: function (ItemPath) {
                return ServerRoot + ItemPath;
            },
            GetProfilePictureURL: function (UsersID) {
                return APIAccountsRoot + UsersID + '/ProfilePicture'
            },
            GetBannerPictureURL: function (UsersID) {
                return APIAccountsRoot + UsersID + '/BannerPicture'
            },
            GetProfileURL: function (UsersID) {
                return ViewAccountsRoot + UsersID
            }
        };
    })
    .factory('MtnWebAPIServicesHelper', function ($window, $compile) {
        function GetRoot(URL) {
            var Index = URL.indexOf("/");
            Index = URL.indexOf("/", Index + 1);
            Index = URL.indexOf("/", Index + 1);
            return URL.substring(0, Index)
        }
        var Root = GetRoot(document.URL);

        return {
            APIRoot: Root + "/Api/",
            ServerRoot: Root,
            ContentURL: function (ItemPath) {
                return ServerRoot + ItemPath;
            },
            QuickErrorHandle: function (result) {
                $window.alert("Status: " + (result.status || "Error") + "\nMessage: " + (result.statusText || 'Request failed for unknow reason.'));
            },
            PrintErrorsWithClassMarkings: function (result, scope) {
                var ErrorsEles = angular.element($(".ErrorMessagePrint"));
                for (var i = 0; i < ErrorsEles.length; i++) {
                    ErrorsEles[i].remove();
                }
                var Error = result.statusText;
                var Errors = Error.substring(35).split(";");
                if (Errors != null && Errors.length !== 1)
                {
                    for (var i = 0; i < Errors.length-1; i++) {
                        var Split = Errors[i].split(":");
                        var Param = Split[0];
                        var ErrorStr = Split[1];
                        angular.element($(".Error" + Param)).append($compile("<p class=\"ErrorMessagePrint\">"+ErrorStr+"</p>")(scope));
                    }
                }
                else
                {
                    angular.element($(".ErrorRoot")).append($compile("<p class=\"ErrorMessagePrint\">"+Error+"</p>")(scope));
                }
            }
        };
    });
    //.filter('ArrayToBase64String', function () {
    //    return function (buffer) {
    //        //not used
    //    };
    //});