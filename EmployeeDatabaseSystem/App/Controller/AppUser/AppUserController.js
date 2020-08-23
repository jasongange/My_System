(function () {
    'use strict';
    angular.module('mainApp').controller('AppUserController', AppUserController)
    AppUserController.$inject = ["$scope", "$http", "CommonService", 'AppUserService', "$timeout", "$window", "NgTableParams", "NavLinkService", "$q"]
    function AppUserController($scope, $http, CommonService, AppUserService, $timeout, $window, NgTableParams, NavLinkService, $q) {

        this.$onInit = function () {
            $scope.reset();
            getNavlinks();
        };

        $scope.reset = function () {
            $scope.sortOrder = "desc";
            $scope.sortColumn = "CreatedOn";
            $scope.lastName = "";
            $scope.firstName = "";
            $scope.middleName = "";
            $scope.userName = "";
            $scope.createdBy = "";
            $scope.search();
        };
        $scope.add = function () {
            $window.location.href = document.AppUser + "/AddForm";
        };

        $scope.IndexView = function (id) {
            $window.location.href = document.NavLink + "/IndexView/" + id;
        };

        $scope.LoginData = {
            username: '',
            password: ''
        };

        $scope.Submitted = false;
        var self = this;

        $scope.search = function () {
            var initialSettings = {
                getData: function (params) {
                    for (var i in params.sorting()) {
                        $scope.sortColumn = i;
                        $scope.sortOrder = params.sorting()[i];
                    }
                    var d = $q.defer();
                    AppUserService.SearchAppUser({
                        Page: params.page(),
                        PageSize: params.count(),
                        SortDirection: $scope.sortOrder,
                        SortColumn: $scope.sortColumn,
                        LastName: $scope.lastName,
                        FirstName: $scope.firstName,
                        MiddleName: $scope.middleName,
                        UserName: $scope.userName,
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

        //Log in
        $scope.saveChanges = function () {
            $scope.Submitted = true;
            if ($scope.appUserForm.$valid) {
                AppUserService.Login($scope.LoginData).
                    then(function (data) {
                        var data = data.data;
                        console.log(data.success);
                        if (data.success == true) {
                            $scope.isSuccess = true;
                            $scope.isFailed = false;
                            CommonService.successMessage(data.message)
                            $timeout(function () {
                                $window.location.href = document.Home;
                            }, 1500);
                        }
                        else {
                            $scope.isFailed = true;
                            $scope.isSuccess = false;
                            $scope.message = data.message;
                            console.log($scope.message);
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
    };
})();