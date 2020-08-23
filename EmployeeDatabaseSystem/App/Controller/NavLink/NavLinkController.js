(function () {
    'use strict';
    angular.module('mainApp').controller('NavLinkController', NavLinkController);
    NavLinkController.$inject = ["$scope", "$http", 'NavLinkService', "$timeout", "$window", "NgTableParams","$q"];
    function NavLinkController($scope, $http, NavLinkService, $timeout, $window, NgTableParams, $q) {

        this.$onInit = function () {
            $scope.reset();
            getNavlinks();
        };

        $scope.reset = function () {
            $scope.sortOrder = "desc";
            $scope.sortColumn = "CreatedOn";
            $scope.name = "";
            $scope.createdBy = "";
            $scope.search();
        };

        $scope.IndexView = function (id) {
            $window.location.href = document.NavLink + "/IndexView/" + id;
        };

        $scope.add = function () {
            $window.location.href = document.NavLink + "/AddForm";
        };

        $scope.edit = function (id) {
            $window.location.href = document.NavLink + "/EditForm/" + id;
        };
        $scope.delete = function (id) {
            NavLinkService.Delete({ navLinkId: id }).then(function () {
                $scope.search();
            });
        };
        $scope.search = function () {
            var initialSettings = {
                getData: function (params) {
                    for (var i in params.sorting()) {
                        $scope.sortColumn = i;
                        $scope.sortOrder = params.sorting()[i];
                    }
                    
                    var d = $q.defer();
                    NavLinkService.SearchNavLink({
                        Page: params.page(),
                        PageSize: params.count(),
                        SortDirection: $scope.sortOrder,
                        SortColumn: $scope.sortColumn,
                        Name: $scope.name,
                        CreatedBy: $scope.createdBy
                    }).then(function (data) {
                        var data = data.data;
                        $scope.resultsLength = data.totalRecordCount;
                        params.total($scope.resultsLength);
                        d.resolve(data.data);
                    });
                    return d.promise;
                }
            };

            $scope.tableParams = new NgTableParams(10, initialSettings);
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
    }
})();