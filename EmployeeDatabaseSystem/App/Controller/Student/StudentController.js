(function () {
    'use strict';
    angular.module('mainApp').controller('StudentController', StudentController);
    StudentController.$inject = ["$scope", "$http", 'NavLinkService', 'StudentService',"CommonService", "$timeout", "$window", "NgTableParams", "$q"];
    function StudentController($scope, $http, NavLinkService, StudentService, CommonService, $timeout, $window, NgTableParams, $q) {

        this.$onInit = function () {
            $scope.reset();
            getNavlinks();
        };

        $scope.reset = function () {
            $scope.sortOrder = "desc";
            $scope.sortColumn = "CreatedOn";
            $scope.studentNo = "";
            $scope.lastName = "";
            $scope.firstName = "";
            $scope.middleName = "";
            $scope.genderId = null;
            $scope.religionId = null;
            $scope.address = "";
            $scope.createdBy = "";
            $scope.search();
        };

        $scope.IndexView = function (id) {
            $window.location.href = document.NavLink + "/IndexView/" + id;
        };

        $scope.add = function () {
            $window.location.href = document.Student + "/AddForm";
        };

        $scope.edit = function (id) {
            $window.location.href = document.Student + "/EditForm/" + id;
        };

        $scope.delete = function (id) {
            CommonService.saveChanges(function () {
                CommonService.successMessage("Student record deleted successfully!")
                StudentService.Delete({ studentId: id }).then(function () {
                    $scope.search();
                });
            });
        };

        $scope.tagAsPaid = function (id) {
            CommonService.saveChanges(function () {
                CommonService.successMessage("Student record updated as paid!")
                StudentService.TagAsPaid({ studentId: id }).then(function () {
                    $scope.search();
                });
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
                    StudentService.SearchStudent({
                        Page: params.page(),
                        PageSize: params.count(),
                        SortDirection: $scope.sortOrder,
                        SortColumn: $scope.sortColumn,
                        LastName: $scope.lastName,
                        FirstName: $scope.firstName,
                        MiddleName: $scope.middleName,
                        StudentNo: $scope.studentNo,
                        GenderId: $scope.genderId,
                        ReligionId: $scope.religionId,
                        Address: $scope.address,
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