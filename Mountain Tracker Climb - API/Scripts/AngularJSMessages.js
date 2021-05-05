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

angular.module("NGMessages", ["NGMtnWebAPI", "ngRoute", "ngSanitize", "ngCookies"])
    .factory('MessagesHelper', function (MtnWebAPIServicesHelper) {
        //var ServerAPIRoot = MtnWebAPIServicesHelper.ServerRoot
        var ViewMessagesRoot = MtnWebAPIServicesHelper.ServerRoot + '/Messages';
        var ViewDMRoot = ViewMessagesRoot + '/DirectMessage/';
        var ViewGMRoot = ViewMessagesRoot + '/GroupMessage/';
        return {
            GetDMsLink: function (ID) {
                return ViewDMRoot + ID
            },
            GetGMsLink: function (ID) {
                return ViewGMRoot + ID
            }
        };
    })
    .controller("MessagesListController", function ($window, $scope, $sce, MtnWebAPIServices, MessagesHelper, AccountHelper) {
        function GetData(ID) {
            MtnWebAPIServices.UserDMs.GetAll(ID).then(function (Result) {
                $scope.DirectMessages = Result.data;
                Object.keys($scope.DirectMessages.MessagesBetweenUser).forEach(function (Key) {
                    $scope.DirectMessages.MessagesBetweenUser[Key].User.URL = MessagesHelper.GetDMsLink(Key);
                    $scope.DirectMessages.MessagesBetweenUser[Key].User.ProfilePicture = AccountHelper.GetProfilePictureURL(Key);
                    $scope.DirectMessages.MessagesBetweenUser[Key].HasUnseen = $scope.DirectMessages.MessagesBetweenUser[Key].AllMessages.some(x => !x.Seen);
                    $scope.DirectMessages.MessagesBetweenUser[Key].AllMessages.forEach(x=> {
                        x.Time = new Date(x.Time);
                    })
                    $scope.DirectMessages.MessagesBetweenUser[Key].LastMessage = $scope.DirectMessages.MessagesBetweenUser[Key].AllMessages.find(x => x.Time.toUTCString() === new Date(Math.max.apply(null, $scope.DirectMessages.MessagesBetweenUser[Key].AllMessages.map(y => y.Time))).toUTCString());
                    console.log(Key, $scope.DirectMessages.MessagesBetweenUser[Key]);
                });
            }, function (Result) { console.log("Error Getting Users: " + Result); });
        }

        $scope.Init = function (ID) {
            $scope.ID = ID;
            GetData(ID);
        };

        $scope.DMFriend = function () {
            MtnWebAPIServices.UserPartner.Get($scope.ID).then(function (Result) {
                $scope.FriendData = Result.data;
                for (var i = 0; i < $scope.FriendData.Friends.length; i++) {
                    $scope.FriendData.Friends[i].ProfilePicture = AccountHelper.GetProfilePictureURL($scope.FriendData.Friends[i].ID);
                    $scope.FriendData.Friends[i].URL = MessagesHelper.GetDMsLink($scope.FriendData.Friends[i].ID);

                    if ($scope.FriendData.Friends[i].Bio === null || $scope.FriendData.Friends[i].Bio.length === 0)
                        $scope.FriendData.Friends[i].Bio = "Nothing yet";
                }

                $('#NewDirectMessage').modal('show');
            }, function (Result) { console.log("Error Getting Users: " + Result); });
        };
    })
    .controller("DirectMessagesController", function ($timeout, $window, $scope, $sce, MtnWebAPIServices, MessagesHelper, AccountHelper) {

        function GetData(ID, OtherUserID) {
            MtnWebAPIServices.UserDMs.Get(ID, OtherUserID).then(function (Result) {
                $scope.DirectMessages = Result.data;
                $scope.DirectMessages.User.ProfilePicture = AccountHelper.GetProfilePictureURL($scope.DirectMessages.User.ID);
                //$scope.DirectMessages.HasUnseen = $scope.DirectMessages.AllMessages.some(x => !x.Seen);
                $scope.DirectMessages.AllMessages.forEach(x => {
                    x.Time = new Date(x.Time);
                });
                //let time out kill time untill after full render.
                $timeout(function () {
                    var View = angular.element($("#MessageScrollBox"));
                    View[0].scrollTop = View[0].scrollHeight;
                });
            }, function (Result) { console.log("Error Getting Users: " + Result); });
        };

        //buggy height not updated yet so you get back to just shy of the last message
        //$scope.$watch('Rendered', function (newValue, oldValue) {
        //    var View = angular.element($("#MessageScrollBox"));
        //    View[0].scrollTop = View[0].scrollHeight;
        //});

        $scope.Init = function (ID, OtherUserID) {
            $scope.ID = ID;
            $scope.OtherUserID = OtherUserID;
            MtnWebAPIServices.UserAccount.Get(ID).then(function (Result) {
                $scope.User = Result.data;
                $scope.User.ProfilePicture = AccountHelper.GetProfilePictureURL($scope.User.ID);
            }, function (Result) { console.log("Error Getting User: " + Result); });
            GetData(ID, OtherUserID);
        };

        $scope.NewMessage = "";

        $scope.OnNewMessageChange = function () {
            $scope.NewMessage = angular.element($("#NewMessageBox"))[0].value;
            if ($scope.NewMessage.length > 0)
                angular.element($("#NewMessageButton")).attr('disabled', false);
            else
                angular.element($("#NewMessageButton")).attr('disabled', true);
        };

        $scope.SendNewMessage = function () {
            var Add = { UserFromID: $scope.ID, UserToID: $scope.OtherUserID, Message: $scope.NewMessage }
            MtnWebAPIServices.UserDMs.Add(Add).then(function (Result) {
                GetData($scope.ID, $scope.OtherUserID);
                $scope.NewMessage = "";
                angular.element($("#NewMessageBox"))[0].value = "";
                angular.element($("#NewMessageButton")).attr('disabled', true);
            }, function (Result) { console.log("Error Getting Users: " + Result); });
        }
    });