(function () {
    'use strict';
    angular.module('mainApp').controller('AddOrUpdateStudentController', AddOrUpdateStudentController);
    AddOrUpdateStudentController.$inject = ["$scope", "$http", 'NavLinkService', "StudentService","CommonService", "$timeout", "$window", "NgTableParams", "$q", "$location"];
    function AddOrUpdateStudentController($scope, $http, NavLinkService, StudentService, CommonService, $timeout, $window, NgTableParams, $q, $location) {

        $scope.student = {
            StudentId: 0
        };

        $scope.isUpdate = $location.absUrl().includes('EditForm');

        this.$onInit = function () {
            getNavlinks();
            getStudentId();
        };

        $scope.cancel = function () {
            $window.location.href = document.Student;
        };

        $scope.IndexView = function (id) {
            $window.location.href = document.NavLink + "/IndexView/" + id;
        };

        $scope.saveChanges = function () {
            CommonService.saveChanges(function () {
                $scope.Submitted = true;
                if ($scope.studentForm.$valid) {
                    StudentService.AddStudent($scope.student).
                        then(function (data) {
                            var data = data.data;
                            if (data.success == true) {
                                data.message;
                                CommonService.successMessage(data.message)
                                $timeout(function () {
                                    $window.location.href = document.Student;
                                }, 1500);
                            }
                            else {
                                data.message;
                            }
                     });
                }
            });
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

        function getStudentDetails() {
            StudentService.GetStudentDetails({
                studentId: $scope.student.StudentId
            }).then(function (data) {
                var data = data.data;
                $scope.student = data.data;
            }, function (error /*Error event should handle here*/) {
                console.log("Error");
            }, function (data /*Notify event should handle here*/) {
            });
        }

        function getStudentId() {
            if ($scope.isUpdate) {
                var locationUrl = $location.absUrl().replace(/\//g, ".").split(".");
                $scope.student.StudentId = locationUrl[locationUrl.length - 1];
                getStudentDetails();
            }
        }
    }
})();