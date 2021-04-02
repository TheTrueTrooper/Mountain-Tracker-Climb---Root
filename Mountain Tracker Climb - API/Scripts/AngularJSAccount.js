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
    .controller("AccountCreationController", function ($window, $scope, MtnWebAPIServices, MtnWebAPIServicesHelper) {
        $scope.Submit = function () {
            MtnWebAPIServices.UserAccount.Add($scope.NewUser).then(function () {
                $window.location = '/Login';
            }, function (result) { MtnWebAPIServicesHelper.PrintErrorsWithClassMarkings(result, $scope); });
        };
    })
    .controller("AccountEditorController", function ($window, $scope, $sce, MtnWebAPIServices, MtnWebAPIServicesHelper) {

        function ContentURL(ItemPath) {
            return MtnWebAPIServicesHelper.ServerRoot + ItemPath;
        }

        $scope.Init = function (ID) {
            $scope.UserID = ID;
            $scope.ServerRoot = MtnWebAPIServicesHelper.ServerRoot;
            $scope.ProfilePicture = $scope.ServerRoot + '/Api/UserAccount/' + $scope.UserID + '/ProfilePicture';
            $scope.ProfilePicturePreview = $scope.ProfilePicture;
            $scope.Banner = $scope.ServerRoot + '/Api/UserAccount/' + $scope.UserID + '/BannerPicture';
            $scope.BannerPreview = $scope.Banner;
            MtnWebAPIServices.UserAccount.Get($scope.UserID).then(function (Result) {
                $scope.User = Result.data;
                if ($scope.User.Bio === null || $scope.User.length === 0)
                    $scope.User.Bio = "Nothing yet";
            }, function (Result) { console.log("Error Getting User: " + Result); });
        }

        $scope.LoadProfilePicturePreview = function () {
            var reader = new FileReader();

            reader.onload = function (e) {
                $scope.$apply(function () {
                    $scope.ProfilePicturePreview = e.target.result;
                });
            }
            var FileInput = document.getElementById('UploadProfilePictureFile');
            var Button = angular.element($('#UploadProfilePictureButton'));
            Button.attr('disabled', false);
            reader.readAsDataURL(FileInput.files[0]);
        }

        $scope.UploadProfilePicture = function () {
            var File = document.getElementById('UploadProfilePictureFile').files[0];
            MtnWebAPIServices.UserAccount.UploadProfilePicture($scope.UserID, File).then(function () {
                $scope.ProfilePicture = $scope.ServerRoot + '/Api/UserAccount/' + $scope.UserID + '/ProfilePicture?_=' + Math.floor(Math.random() * 9999);
            }, function (Result) { $window.alert("Upload failed due to " + Result.status + " Error!"); });
            //$scope.ProfilePicture = $scope.ServerRoot + '/Api/UserAccount/' + $scope.UserID + '/ProfilePicture';
            //send your binary data via $http or $resource or do anything else with it
        }

        $scope.LoadBannerPreview = function () {
            var reader = new FileReader();

            reader.onload = function (e) {
                $scope.$apply(function () {
                    $scope.BannerPreview = e.target.result;
                });
            }
            var FileInput = document.getElementById('UploadBannerFile');
            var Button = angular.element($('#UploadBannerButton'));
            Button.attr('disabled', false);
            reader.readAsDataURL(FileInput.files[0]);
        }

        $scope.EditProfilePicture = function () {
            $('#UploadProfilePictureModal').modal('show');
        }

        $scope.EditBanner = function () {
            $('#UploadBannerModal').modal('show');
        }

        $scope.UploadBanner = function () {
            var File = document.getElementById('UploadBannerFile').files[0];
            MtnWebAPIServices.UserAccount.UploadBannerPicture($scope.UserID, File).then(function () {
                $scope.Banner = $scope.ServerRoot + '/Api/UserAccount/' + $scope.UserID + '/BannerPicture?_=' + Math.floor(Math.random() * 9999);
            }, function (Result) { $window.alert("Upload failed due to " + Result.status + " Error!"); });
            //$scope.ProfilePicture = $scope.ServerRoot + '/Api/UserAccount/' + $scope.UserID + '/ProfilePicture';
            //send your binary data via $http or $resource or do anything else with it
        }

        $scope.EditFirstName = function () {
            $('#EditFirstNameModal').modal('show');
        }

        $scope.EditMiddleName = function () {
            $('#EditMiddleNameModal').modal('show');
        }

        $scope.EditLastName = function () {
            $('#EditLastNameModal').modal('show');
        }

        $scope.EditURL = function () {
            $('#EditURLModal').modal('show');
        }

        $scope.ChangeAccountType = function () {
            $window.alert("Comming Soon Paid subscription!");
        }

        $scope.EditKeepPrivate = function () {
            $('#EditKeepPrivateModal').modal('show');
        }

        $scope.EditBio = function () {
            $('#EditBioModal').modal('show');
        }

    });