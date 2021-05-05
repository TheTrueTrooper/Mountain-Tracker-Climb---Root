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

angular.module("NGAccount", ["NGMtnWebAPI", "ngRoute", "ngSanitize", "ngCookies"])
    //.factory('AccountHelper', function (MtnWebAPIServicesHelper) {
    //    var ServerRoot = MtnWebAPIServicesHelper.ServerRoot;
    //    //var ServerAPIRoot = MtnWebAPIServicesHelper.ServerRoot
    //    var APIAccountsRoot = MtnWebAPIServicesHelper.ServerRoot + '/Api/UserAccount/';
    //    var ViewAccountsRoot = MtnWebAPIServicesHelper.ServerRoot + '/Account/';
    //    return {
    //        ContentURL: function (ItemPath) {
    //            return ServerRoot + ItemPath;
    //        },
    //        GetProfilePictureURL: function (UsersID) {
    //            return APIAccountsRoot + UsersID + '/ProfilePicture'
    //        },
    //        GetBannerPictureURL: function (UsersID) {
    //            return APIAccountsRoot + UsersID + '/BannerPicture'
    //        },
    //        GetProfileURL: function (UsersID) {
    //            return ViewAccountsRoot + UsersID
    //        }
    //    };
    //})
    .controller("AccountPartnersController", function ($window, $scope, $sce, MtnWebAPIServices, MtnWebAPIServicesHelper, AccountHelper) {
        function GetData(ID) {
            MtnWebAPIServices.UserPartner.Get(ID).then(function (Result) {
                $scope.FriendData = Result.data;
                for (var i = 0; i < $scope.FriendData.Friends.length; i++) {
                    $scope.FriendData.Friends[i].ProfilePicture = AccountHelper.GetProfilePictureURL($scope.FriendData.Friends[i].ID);
                    $scope.FriendData.Friends[i].URL = AccountHelper.GetProfileURL($scope.FriendData.Friends[i].ID);

                    if ($scope.FriendData.Friends[i].Bio === null || $scope.FriendData.Friends[i].Bio.length === 0)
                        $scope.FriendData.Friends[i].Bio = "Nothing yet";
                }
                for (var i = 0; i < $scope.FriendData.FriendRequesteds.length; i++) {
                    $scope.FriendData.FriendRequesteds[i].ProfilePicture = AccountHelper.GetProfilePictureURL($scope.FriendData.FriendRequesteds[i].ID);
                    $scope.FriendData.FriendRequesteds[i].URL = AccountHelper.GetProfileURL($scope.FriendData.FriendRequesteds[i].ID);
                }
                for (var i = 0; i < $scope.FriendData.FriendRequests.length; i++) {
                    $scope.FriendData.FriendRequests[i].ProfilePicture = AccountHelper.GetProfilePictureURL($scope.FriendData.FriendRequests[i].ID);
                    $scope.FriendData.FriendRequests[i].URL = AccountHelper.GetProfileURL($scope.FriendData.FriendRequests[i].ID);
                }
            }, function (Result) { console.log("Error Getting Users: " + Result); });
        };

        $scope.Init = function (ID) {
            $scope.ID = ID;
            GetData(ID);
        };

        $scope.AcceptFriendRequest = function (UserFromID, UserToID) {
            var Request = { UserFromID: UserFromID, UserToID: UserToID };
            MtnWebAPIServices.UserPartner.Accept(Request).then(function (Result) {
                GetData($scope.ID);
            }, function (Result) {
            });
        };

        $scope.Remove = function (UserFromID, UserToID) {
            MtnWebAPIServices.UserPartner.Delete(UserFromID, UserToID).then(function (Result) {
                MtnWebAPIServices.UserPartner.Delete(UserToID,UserFromID).then(function (Result) {
                    GetData($scope.ID);
                }, function (Result) {
                });
            }, function (Result) {
            });
        };
    })
    .controller("AccountViewController", function ($window, $scope, $sce, MtnWebAPIServices, MtnWebAPIServicesHelper, AccountHelper) {

        $scope.ProvincesOrStates = [];
        $scope.Countries = [];

        $scope.Init = function (ID, ViewerID) {
            $scope.IsFriend = false;
            $scope.HasFriendRequest = false;
            MtnWebAPIServices.UserPartner.CheckForFriendRequest(ViewerID, ID).then(function (Result) {
                $scope.HasFriendRequest = Result.data.IsFriend;
            });
            MtnWebAPIServices.UserPartner.CheckFriendShip(ViewerID, ID).then(function (Result) {
                $scope.IsFriend = Result.data.IsFriend;
            });
            $scope.UserID = ID;
            $scope.ServerRoot = MtnWebAPIServicesHelper.ServerRoot;
            $scope.ProfilePicture = AccountHelper.GetProfilePictureURL($scope.UserID);
            $scope.Banner = AccountHelper.GetBannerPictureURL($scope.UserID);
            MtnWebAPIServices.UserAccount.Get($scope.UserID).then(function (Result) {
                $scope.User = Result.data;
                if ($scope.User.Bio === null || $scope.User.length === 0)
                    $scope.User.Bio = "Nothing yet";

                if ($scope.User.KeepPrivate)
                    $scope.User.Bio = "This user has their Bio set to private. You cannot see their bio untill they friend you.";

                if ($scope?.User?.CountryID !== null) {
                    MtnWebAPIServices.ProvincesOrStates.GetList($scope?.User?.CountryID).then(function (Result) {
                        $scope.ProvincesOrStates = Result.data;
                    });
                }
            }, function (Result) {
                if (Result.status === 404)
                        $window.location = "/Account/AccountNotFound"
                    console.log("Error Getting User: " + Result);
            });

            MtnWebAPIServices.Countries.GetList().then(function (Result) {
                $scope.Countries = Result.data;
            });
        };

        $scope.PrintUserCountry = function () {
            if ($scope.Countries.length === 0)
                return "";
            if ($scope?.User?.CountryID === null || $scope?.User?.ProvinceID === undefined)
                return "Unkown Location"
            else if ($scope?.User?.ProvinceID === null || $scope?.User?.ProvinceID === undefined || $scope.ProvincesOrStates.length === 0)
                return $scope.Countries[$scope.User.CountryID].EnglishFullName;
            return $scope.Countries[$scope.User.CountryID].EnglishFullName + ", " + $scope.ProvincesOrStates.find(x => x.ID === $scope.User.ProvinceID).EnglishFullName;
        };

        $scope.SendFriendRequest = function (UserFromID, UserToID) {
            var Request = { UserFromID: UserFromID, UserToID: UserToID };
            MtnWebAPIServices.UserPartner.Add(Request).then(function (Result) {
                $scope.HasFriendRequest = true;
            }, function (Result) {
            });
        };

        $scope.SendMessage = function (SendToID) {
            $window.location = "/Messages/DirectMessage/" + SendToID;
        };

    })
    .controller("AccountProfileSearchController", function ($window, $scope, MtnWebAPIServices, MtnWebAPIServicesHelper, AccountHelper) {
        $scope.Init = function (UserNameSearch) {
            if (UserNameSearch !== undefined) {
                $scope.SearchingName = UserNameSearch;

                MtnWebAPIServices.UserAccount.GetSearchList(UserNameSearch).then(function (Result) {
                    $scope.SearchResults = Result.data;
                    for (var i = 0; i < $scope.SearchResults.length; i++) {
                        $scope.SearchResults[i].ProfilePicture = AccountHelper.GetProfilePictureURL($scope.SearchResults[i].ID);
                        $scope.SearchResults[i].URL = AccountHelper.GetProfileURL($scope.SearchResults[i].ID);

                        if ($scope.SearchResults[i].Bio === undefined || $scope.SearchResults[i].Bio === null || $scope.SearchResults[i].Bio.length === 0)
                            $scope.SearchResults[i].Bio = "Nothing yet";

                        if ($scope.SearchResults[i].KeepPrivate)
                            $scope.SearchResults[i].Bio = "This user has their Bio set to private. You cannot see their bio untill they friend you.";
                    }
                }, function (Result) { console.log("Error Getting Users: " + Result); });

                MtnWebAPIServices.Countries.GetList().then(function (Result) {
                    $scope.Countries = Result.data;
                });

                MtnWebAPIServices.ProvincesOrStates.GetAll().then(function (Result) {
                    $scope.ProvincesOrStates = Result.data;
                });
            }
            else {
                $scope.SearchResults = []
            }
        };

        $scope.SearchName = function () {
            MtnWebAPIServices.UserAccount.GetSearchList($scope.SearchingName).then(function (Result) {
                $scope.SearchResults = Result.data;
                for (var i = 0; i < $scope.SearchResults.length; i++) {
                    $scope.SearchResults[i].ProfilePicture = AccountHelper.GetProfilePictureURL($scope.SearchResults[i].ID);
                    $scope.SearchResults[i].URL = AccountHelper.GetProfileURL($scope.SearchResults[i].ID);

                    if ($scope.SearchResults[i].Bio === null || $scope.SearchResults[i].Bio.length === 0)
                        $scope.SearchResults[i].Bio = "Nothing yet";
                    else if ($scope.SearchResults[i].Bio.length > 100)
                        $scope.SearchResults[i].Bio = $scope.SearchResults[i].Bio.substring(0, 100) + "...";

                    if ($scope.SearchResults[i].KeepPrivate)
                        $scope.SearchResults[i].Bio = "This user has their Bio set to private. You cannot see their bio untill they friend you.";
                }
            }, function (Result) { console.log("Error Getting Users: " + Result); });
        };

        $scope.ProvincesOrStates = [];
        $scope.Countries = [];

        $scope.PrintUserCountry = function (User) {
            if ($scope.Countries.length === 0)
                return "";
            if (User.CountryID === null || User.ProvinceID === undefined)
                return "Unkown Location"
            else if (User.ProvinceID === null || User.ProvinceID === undefined || $scope.ProvincesOrStates.length === 0)
                return $scope.Countries[User.CountryID].EnglishFullName;
            return $scope.Countries[User.CountryID].EnglishFullName + ", " + $scope.ProvincesOrStates.find(x => x.ID === User.ProvinceID).EnglishFullName;
        };
    })
    .controller("AccountEditorController", function ($window, $scope, $sce, MtnWebAPIServices, MtnWebAPIServicesHelper, AccountHelper) {
        function UpdateUser(Changes) {
            MtnWebAPIServices.UserAccount.Update($scope.UserID, Changes).then(function () {
                MtnWebAPIServices.UserAccount.Get($scope.UserID).then(function (Result) {
                    $scope.User = Result.data;
                    if ($scope.User.Bio === null || $scope.User.length === 0)
                        $scope.User.Bio = "Nothing yet";
                }, function (Result) { console.log("Error Getting User: " + Result); });
            }, function (Result) { $window.alert("Update failed due to " + Result.status + " Error!"); });
        }

        $scope.ProvincesOrStates = [];
        $scope.EditProvincesOrStates = [];
        $scope.Countries = [];

        $scope.Init = function (ID) {
            $scope.UserID = ID;
            $scope.ServerRoot = MtnWebAPIServicesHelper.ServerRoot;
            $scope.ProfilePicture = AccountHelper.GetProfilePictureURL($scope.UserID);
            $scope.ProfilePicturePreview = $scope.ProfilePicture;
            $scope.Banner = AccountHelper.GetBannerPictureURL($scope.UserID);
            $scope.BannerPreview = $scope.Banner;
            MtnWebAPIServices.UserAccount.Get($scope.UserID).then(function (Result) {
                $scope.User = Result.data;
                if ($scope.User.Bio === null || $scope.User.Bio.length === 0)
                    $scope.User.Bio = "Nothing yet";

                if ($scope?.User?.CountryID !== null) {
                    MtnWebAPIServices.ProvincesOrStates.GetList($scope?.User?.CountryID).then(function (Result) {
                        $scope.ProvincesOrStates = Result.data;
                        $scope.EditProvincesOrStates = $scope.ProvincesOrStates;
                    });
                }
            }, function (Result) { console.log("Error Getting User: " + Result); });

            MtnWebAPIServices.Countries.GetList().then(function (Result) {
                $scope.Countries = Result.data;
            });
        };

        $scope.CountrySelected = function (CountryID) {
            if (CountryID != 'null') {
                MtnWebAPIServices.ProvincesOrStates.GetList(CountryID).then(function (Result) {
                    $scope.Edit.ProvinceID = "null"
                    $scope.EditProvincesOrStates = Result.data;
                    angular.element($("#ProvinceSelect")).attr('disabled', false);
                });
            }
            else {
                $scope.Edit.ProvinceID = "null"
                $scope.ProvincesOrStates = [];
                angular.element($("#ProvinceSelect")).attr('disabled', true);
            }
        };

        
        $scope.PrintUserCountry = function () {
            if ($scope.Countries.length === 0)
                return "";
            if ($scope?.User?.CountryID === null || $scope?.User?.ProvinceID === undefined)
                return "Unkown Location"
            else if ($scope?.User?.ProvinceID === null || $scope?.User?.ProvinceID === undefined || $scope.ProvincesOrStates.length === 0)
                return $scope.Countries[$scope.User.CountryID].EnglishFullName;
            return $scope.Countries[$scope.User.CountryID].EnglishFullName + ", " + $scope.ProvincesOrStates.find(x=>x.ID === $scope.User.ProvinceID).EnglishFullName;
        };


        $scope.ThrowPerferedToTop = function (obj) {
            var Value = obj.EnglishFullName;
            if (obj.CountryCode === 'CA')
                Value = "__" + obj.EnglishFullName;
            else if (obj.CountryCode === 'US')
                Value = "_" + obj.EnglishFullName;
            return Value;
        };

        function Max(Num, Max) {
            if (Num > Max)
                return Max;
            return Num;
        }

        function Min(Num, Min) {
            if (Num < Min)
                return Min;
            return Num;
        }

        function Clamp(Num, Min, Max) {
            if (Num < Min)
                return Min;
            if (Num > Max)
                return Max;
            return Num;
        }

        function Abs(Num) {
            if (Num < 0)
                return Min * -1;
            return Num;
        }

        var LastX = 0;
        var LastY = 0;
        var ProfilePictureLocationX = 0
        var ProfilePictureLocationY = 0
        var ProfilePictureMaxX = 0
        var ProfilePictureMaxY = 0
        var SquareSize;

        var BannerLocationX = 0
        var BannerLocationY = 0
        var BannerMaxX = 0
        var BannerMaxY = 0

        var MouseDownProfilePicture = false;
        var MouseDownBanner = false;

        var ProfilePictureImageView = new Image();
        var BannerImageView = new Image();

        var ProfilePicturePreviewCanvas = document.getElementById("ProfilePicturePreviewGenerator");
        var BannerPreviewCanvas = document.getElementById("BannerPicturePreviewGenerator");

        BannerImageView.onload = function () {
            var Context = BannerPreviewCanvas.getContext('2d');
            BannerMaxY = Min(BannerPreviewCanvas.width - BannerImageView.width, 0);
            BannerMaxX = Min(BannerPreviewCanvas.height - BannerImageView.height, 0);
            Context.clearRect(0, 0, BannerPreviewCanvas.width, BannerPreviewCanvas.height)
            Context.drawImage(BannerImageView, BannerLocationX, BannerLocationY, BannerImageView.width - 20, BannerImageView.height - 20, 0, 0, BannerPreviewCanvas.width, BannerImageView.height);
        };

        ProfilePictureImageView.onload = function () {
            var Context = ProfilePicturePreviewCanvas.getContext('2d');
            SquareSize = Max(ProfilePictureImageView.height - 20, ProfilePictureImageView.width - 20);
            ProfilePictureMaxY = Min(ProfilePicturePreviewCanvas.width - ProfilePictureImageView.width, 0);
            ProfilePictureMaxX = Min(ProfilePicturePreviewCanvas.height - ProfilePictureImageView.height, 0);
            Context.clearRect(0, 0, ProfilePicturePreviewCanvas.width, ProfilePicturePreviewCanvas.height);
            Context.drawImage(ProfilePictureImageView, ProfilePictureLocationX, ProfilePictureLocationY, SquareSize, SquareSize, 0, 0, ProfilePicturePreviewCanvas.width, ProfilePicturePreviewCanvas.height);
        };

        $scope.OnMouseDownBanner = function () {
            MouseDownBanner = true;
        }

        $scope.OnMouseUpBanner = function () {
            MouseDownBanner = false;
        }

        $scope.OnMouseMoveBanner = function () {
            e = $window.event;
            var DeltaX = e.x - LastX;
            var DeltaY = e.y - LastY;
            LastX = e.x;
            LastY = e.y;

            if (MouseDownBanner) {
                var Context = BannerPreviewCanvas.getContext('2d');
                BannerLocationX = Clamp(BannerLocationX + DeltaX, 0, BannerMaxX);
                BannerLocationY = Clamp(BannerLocationY + DeltaY, 0, BannerMaxY);
                Context.clearRect(0, 0, BannerPreviewCanvas.width, BannerPreviewCanvas.height)
                Context.drawImage(BannerImageView, BannerLocationX, BannerLocationY, BannerImageView.width - 20, BannerImageView.height - 20, 0, 0, BannerPreviewCanvas.width, BannerImageView.height);
            }
        }

        $scope.OnMouseDownProfilePicture = function () {
            MouseDownProfilePicture = true;
        }

        $scope.OnMouseUpProfilePicture = function () {
            MouseDownProfilePicture = false;
        }

        $scope.OnMouseMoveProfilePicture = function () {
            e = $window.event;
            var DeltaX = e.x - LastX;
            var DeltaY = e.y - LastY;
            LastX = e.x;
            LastY = e.y;

            if (MouseDownProfilePicture) {
                var Context = ProfilePicturePreviewCanvas.getContext('2d');
                ProfilePictureLocationX = Clamp(ProfilePictureLocationX + DeltaX, 0, ProfilePictureMaxX);
                ProfilePictureLocationY = Clamp(ProfilePictureLocationY + DeltaY, 0, ProfilePictureMaxY);
                Context.clearRect(0, 0, ProfilePicturePreviewCanvas.width, ProfilePicturePreviewCanvas.height)
                Context.drawImage(ProfilePictureImageView, ProfilePictureLocationX, ProfilePictureLocationY, SquareSize, SquareSize, 0, 0, ProfilePicturePreviewCanvas.width, ProfilePicturePreviewCanvas.height);
            }
        }

        $scope.LoadProfilePicturePreview = function () {
            var reader = new FileReader();

            reader.onload = function (e) {
                ProfilePictureLocationX = 0;
                ProfilePictureLocationX = 0;
                ProfilePictureImageView.src = e.target.result;
            }
            var FileInput = document.getElementById('UploadProfilePictureFile');
            var Button = angular.element($('#UploadProfilePictureButton'));
            Button.attr('disabled', false);
            reader.readAsDataURL(FileInput.files[0]);
        };

        $scope.UploadProfilePicture = function () {
        /*var File = document.getElementById('UploadProfilePictureFile').files[0];*/
            ProfilePicturePreviewCanvas.toBlob(function (File) {
                MtnWebAPIServices.UserAccount.UploadProfilePicture($scope.UserID, File).then(function () {
                    $scope.ProfilePicture = AccountHelper.GetProfilePictureURL($scope.UserID) + '?_=' + Math.floor(Math.random() * 9999);
                }, function (Result) { $window.alert("Upload failed due to " + Result.status + " Error!"); });
            });
        };

        $scope.LoadBannerPreview = function () {
            var reader = new FileReader();

            reader.onload = function (e) {
                BannerLocationX = 0;
                BannerLocationX = 0;
                BannerImageView.src = e.target.result;
            }
            var FileInput = document.getElementById('UploadBannerFile');
            var Button = angular.element($('#UploadBannerButton'));
            Button.attr('disabled', false);
            reader.readAsDataURL(FileInput.files[0]);
        };

        $scope.EditProfilePicture = function () {
            $('#UploadProfilePictureModal').modal('show');
        };

        $scope.EditBanner = function () {
            $('#UploadBannerModal').modal('show');
        };

        $scope.UploadBanner = function () {
            BannerPreviewCanvas.toBlob(function (File) {
                MtnWebAPIServices.UserAccount.UploadBannerPicture($scope.UserID, File).then(function () {
                    $scope.Banner = AccountHelper.GetBannerPictureURL($scope.UserID) + '?_=' + Math.floor(Math.random() * 9999);
                }, function (Result) { $window.alert("Upload failed due to " + Result.status + " Error!"); });
            });
        };

        $scope.EditFirstName = function () {
            $scope.Edit = {
                FirstName: $scope.User.FirstName
            };
            $('#EditFirstNameModal').modal('show');
        };

        $scope.EditMiddleName = function () {
            $scope.Edit = {
                MiddleName: $scope.User.MiddleName
            };
            $('#EditMiddleNameModal').modal('show');
        };

        $scope.EditLastName = function () {
            $scope.Edit = {
                LastName: $scope.User.LastName
            };
            $('#EditLastNameModal').modal('show');
        };

        $scope.EditURL = function () {
            $scope.Edit = {
                ProfileURL: $scope.User.ProfileURL
            };
            $('#EditURLModal').modal('show');
        };

        $scope.ChangeAccountType = function () {
            $window.alert("Comming Soon Paid subscription with new features!");
        };

        $scope.EditAppSettings = function () {
            $scope.Edit = {
                KeepPrivate: $scope.User.KeepPrivate,
                MetricOverImperial: $scope.User.MetricOverImperial,
            };
            if ($scope.User.CountryID != null) {
                $scope.Edit.CountryID = $scope.User.CountryID.toString();
                angular.element($("#ProvinceSelect")).attr('disabled', false);
            }
            else {
                $scope.Edit.CountryID = "null"
                angular.element($("#ProvinceSelect")).attr('disabled', true);
            }
            if ($scope.User.ProvinceID != null)
                $scope.Edit.ProvinceID = $scope.User.ProvinceID.toString();
            else
                $scope.Edit.ProvinceID = "null"
            $('#EditAppSettingsModal').modal('show');

        };

        $scope.EditBio = function () {
            angular.element($("#BioEdit"))[0].value = $scope.User.Bio;
            $('#EditBioModal').modal('show');
        };

        $scope.SaveFirstNameEdit = function () {
            var Set = { FirstName: $scope.Edit.FirstName };
            UpdateUser(Set);
        };

        $scope.SaveMiddleNameEdit = function () {
            var Set = { MiddleName: $scope.Edit.MiddleName };
            UpdateUser(Set);
        };

        $scope.SaveProfileURLEdit = function () {
            var Set = { ProfileURL: $scope.Edit.ProfileURL };
            UpdateUser(Set);
        };

        $scope.SaveAppSettingsEdit = function () {
            var Set = {
                KeepPrivate: $scope.Edit.KeepPrivate,
                MetricOverImperial: $scope.Edit.MetricOverImperial,
                CountryID: $scope.Edit.CountryID,
                ProvinceID: $scope.Edit.ProvinceID
            };
            $scope.ProvincesOrStates = $scope.EditProvincesOrStates;
            if ($scope.Edit.CountryID !== "null")
                $scope.User.CountryID = parseInt($scope.Edit.CountryID);
            else
                $scope.Edit.CountryID = null;
            if ($scope.Edit.ProvinceID !== "null")
                $scope.User.ProvinceID = parseInt($scope.Edit.ProvinceID);
            else
                $scope.User.ProvinceID = null
            UpdateUser(Set);
        };

        $scope.SaveBioEdit = function () {
            var Set = { Bio: angular.element($("#BioEdit"))[0].value };
            UpdateUser(Set);
        };

        $scope.DeleteProfilePicture = function () {
            MtnWebAPIServices.UserAccount.DeleteProfilePicture($scope.UserID).then(function () {
                $scope.ProfilePicture = AccountHelper.GetProfilePictureURL($scope.UserID) + '?_=' + Math.floor(Math.random() * 9999);
            }, function (Result) { $window.alert("Upload failed due to " + Result.status + " Error!"); });
        };

        $scope.DeleteBanner = function () {
            MtnWebAPIServices.UserAccount.DeleteBannerPicture($scope.UserID).then(function () {
                $scope.Banner = AccountHelper.GetBannerPictureURL($scope.UserID) + '?_=' + Math.floor(Math.random() * 9999);
            }, function (Result) { $window.alert("Upload failed due to " + Result.status + " Error!"); });
        };
    })
    .controller("AccountCreationController", function ($window, $scope, MtnWebAPIServices, MtnWebAPIServicesHelper) {
        $scope.Submit = function () {
            MtnWebAPIServices.UserAccount.Add($scope.NewUser).then(function () {
                $window.location = '/Login';
            }, function (result) { MtnWebAPIServicesHelper.PrintErrorsWithClassMarkings(result, $scope); });
        };
    });