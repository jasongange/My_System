(function () {
    'use strict';
    angular.module('mainApp').controller('AddOrUpdateAppUserController', AddOrUpdateAppUserController);
    AddOrUpdateAppUserController.$inject = ["$scope", "$http", 'NavLinkService', "$timeout", "$window", "NgTableParams", "$q", "$location","AppUserService"];
    function AddOrUpdateAppUserController($scope, $http, NavLinkService, $timeout, $window, NgTableParams, $q, $location, AppUserService) {

        $scope.navLink = {
            NavLinkId: 0
        };

        $scope.isUpdate = $location.absUrl().includes('EditForm');

        this.$onInit = function () {
            getNavlinks();
            getNavLinkId();
        };

        $scope.cancel = function () {
            $window.location.href = document.AppUser;
        };

        $scope.IndexView = function (id) {
            $window.location.href = document.NavLink + "/IndexView/" + id;
        };

        $scope.saveChanges = function () {
            $scope.Submitted = true;
            console.log($scope.appUser);
            if ($scope.appUserForm.$valid) {
                AppUserService.AddAppUser($scope.appUser).
                    then(function (data) {
                        var data = data.data;
                        if (data.success == true) {
                            data.message;
                            $timeout(function () {
                                $window.location.href = document.AppUser;
                            }, 600);
                        }
                        else {
                            data.message;
                        }
                 });
            }
        };

        function getNavlinks() {
            NavLinkService.GetAllNavLink({
            }).then(function (data) {
                var data = data.data;
                $scope.navLinks = data.data;
            }, function (error /*Error event should handle here*/) {
                console.log("Error");
            }, function (data /*Notify event should handle here*/) {
            });
        }

        function getNavLinkDetails() {
            console.log($scope.navLink.NavLinkId);
            NavLinkService.GetNavLinkDetails({
                navLinkId: $scope.navLink.NavLinkId
            }).then(function (data) {
                var data = data.data;
                $scope.navLink = data.data;
                console.log(data);
            }, function (error /*Error event should handle here*/) {
                console.log("Error");
            }, function (data /*Notify event should handle here*/) {
            });
        }

        function getNavLinkId() {
            if ($scope.isUpdate) {
                var locationUrl = $location.absUrl().replace(/\//g, ".").split(".");
                $scope.navLink.NavLinkId = locationUrl[locationUrl.length - 1];
                getNavLinkDetails();
            }
        }
    }
})();