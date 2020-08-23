(function () {
    'use strict';
    angular.module('mainApp').controller('HomeController', HomeController);
    HomeController.$inject = ["$scope", "$http", "CommonService", 'NavLinkService', "$timeout","$window"];
    function HomeController($scope, $http, CommonService, NavLinkService, $timeout, $window) {

        this.$onInit = function () {
            getNavlinks();
        };

        $scope.IndexView = function (id) {
            $window.location.href = document.NavLink + "/IndexView/" + id;
        };

        function getNavlinks() {
            NavLinkService.GetAllNavLink({
            }).then(function (data) {
                var data = data.data;
                $scope.navLinks = data.data;
                console.log($scope.navLinks);
            }, function (error /*Error event should handle here*/) {
                console.log("Error");
            }, function (data /*Notify event should handle here*/) {
            });
        }
    }
})();