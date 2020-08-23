(function () {
    'use strict';
    angular.module('mainApp').controller('AddOrUpdateNavlinkController', AddOrUpdateNavlinkController);
    AddOrUpdateNavlinkController.$inject = ["$scope", "$http", 'NavLinkService', "$timeout", "$window", "NgTableParams", "$q", "$location"];
    function AddOrUpdateNavlinkController($scope, $http, NavLinkService, $timeout, $window, NgTableParams, $q, $location) {

        $scope.navLink = {
            NavLinkId: 0
        };
        //var navLinkId = $location.search().NavlinkId;
        //console.log($scope.navLink);
        //var navLinksDetails = angular.copy($scope.navLink);

        $scope.isUpdate = $location.absUrl().includes('EditForm');

        this.$onInit = function () {
            getNavlinks();
            getNavLinkId();
            //if ($scope.isUpdate) {
            //    getNavLinkDetails();
            //}
        };

        $scope.cancel = function () {
            $window.location.href = document.NavLink;
        };

        $scope.IndexView = function (id) {
            $window.location.href = document.NavLink + "/IndexView/" + id;
        };
       
        $scope.saveChanges = function () {
            $scope.Submitted = true;
            if ($scope.appUserForm.$valid) {
                NavLinkService.AddNavLink($scope.navLink).
                    then(function (data) {
                        var data = data.data;
                        if (data.success == true) {
                            data.message;
                            $timeout(function () {
                                $window.location.href = document.NavLink;
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
                //console.log(locationUrl);
                $scope.navLink.NavLinkId = locationUrl[locationUrl.length - 1];
                //console.log($scope.navLink.NavLinkId);
                getNavLinkDetails();
            }
        }
    }
})();