(function () {
    'use strict';
    angular.module('mainApp').controller('IndexController', IndexController)
    IndexController.$inject = ["$scope", "$http", "CustomService", 'DemoService', 'CRUDService', 'TASKService', "$timeout"]

    function IndexController($scope, $http, CustomService, DemoService, CRUDService, TASKService, $timeout) {
        $scope.employee = {};
        $scope.employeeT = {};


        var config = {
            headers: {
                'Content-Type': 'application/json'
            }
        };
        this.$onInit = function () {
            displayListOfEmployee();
            displayListOfTask();
            //console.log($scope.employee);
            //console.log(CustomService.sample);
        };
        $(document).ready(function () {
            $("#myModal").on('show.bs.modal', function (event) {
                var button = $(event.relatedTarget);  // Button that triggered the modal
                var titleData = button.data('title'); // Extract value from data-* attributes
                $(this).find('.modal-title').text(titleData + ' Form');
            });
        });

  /////////////////////////////////////////////// Display List /////////////////////////////////////////////////////////////////

        function displayListOfEmployee() {
            $http.get("http://localhost:46853/api/DemoApp/Get")
           .then(function (response) {
               $scope.employees = response.data;
           });
        }

        function displayListOfTask() {
            $http.get("http://localhost:46853/api/DemoApp/GetEmployeeTask")
            .then(function (response) {
                $scope.employeeTask = response.data;
            });
        }

   ///////////////////////////////////////////// Get Row ///////////////////////////////////////////////////////////////////////


        $scope.getEmployeeTaskRow = function (employee) {
            $scope.employeeT.EmployeeId = employee.EmployeeId;
        };
        $scope.getEmployeeRow = function (employee) {

            $scope.employee = angular.copy(employee);
        };
        $scope.getTaskRow = function (employeeT) {

            $scope.employeeT = angular.copy(employeeT);
        };

/////////////////////////////////////////////// Add Data //////////////////////////////////////////////////////////////////////

        $scope.addEmployee = function () {

            CRUDService.createEmployee($scope.employee).then(function (response) {
                if (response)
                $scope.messagebool = true;
                $scope.msg = "Employee Data Submited Successfully!";
                CustomService.clearInputText("#regForm", 'text');
                displayListOfEmployee();

                $timeout(function(){
                    $scope.employee = {};
                    $scope.messagebool = false;
                    $scope.Submitted = true;
                }, 2000);
            },
                function (response) {
                    console.log(response);
                    $scope.msg = "Employee not exist";
                });
        };

        $scope.addEmployeeTask = function () {

            TASKService.createTask($scope.employeeT).then(function (response) {

                    $scope.messagebool = true;
                    $scope.msg = "EmployeeTask Data Submited Successfully!";
                    CustomService.clearInputText("#taskForm", 'text');

                $timeout(function () {
                    displayListOfTask();
                    $scope.employeeT = {};
                    $scope.messagebool = false;
                }, 2000);

            }, function (response) {
                    console.log(response);
                $scope.msg = "EmployeeTask not exist";
            });
        };

 ////////////////////////////////////////////////// Update Data /////////////////////////////////////////////////////////////////

        $scope.updateEmployee = function () {
            CRUDService.updateEmployee($scope.employee).then(function (response) {
                if (response.data)
                $scope.messagebool = true;
                $scope.msg = "Employee Data Updated Successfully!";
                CustomService.clearInputText("#regForm", 'text');

                $timeout(function () {
                    displayListOfEmployee();
                    $scope.messagebool = false;
                    $scope.employee = {};
                }, 2000);

            }, function (response) {
                    console.log(response);
               
                $scope.msg = "Employee not exist";
            });
        };


        $scope.updateEmployeeTask = function () {

            TASKService.updateTask($scope.employeeT).then(function (response) {
                if (response.data)
                    $scope.messagebool = true;
                    $scope.msg = "EmployeeTask Data Updated Successfully!";
                CustomService.clearInputText("#regForm", 'text');

                $timeout(function () {
                    displayListOfTask();
                    $scope.employeeT = {};
                    $scope.messagebool = false;
                }, 2000);

            }, function (response) {
                    console.log(response);
                $scope.msg = "EmployeeTask not exist";
            });
        };

///////////////////////////////////////////// Delete Data ///////////////////////////////////////////////////////////////////////


        $scope.deleteEmployee = function () {
            CRUDService.deleteEmployee($scope.employee).then(function (response) {
                if (response.data)
                    $scope.messagebool = true;
                $scope.msg = "Employee Data Deleted Successfully!";
                CustomService.clearInputText("#regForm", 'text');

                $timeout(function () {
                    displayListOfEmployee();
                    $scope.employee = {};
                    $scope.messagebool = false;
                }, 2000);

            }, function (response) {
                    console.log(response);
                $scope.msg = "Employee not exist";
            });
        };

        $scope.deleteEmployeeTask = function () {
            TASKService.deleteTask($scope.employeeT).then(function (response) {
                if (response.data)
                    $scope.messagebool = true;
                $scope.msg = "EmployeeTasks Data Deleted Successfully!";
                CustomService.clearInputText("#regForm", 'text');

                $timeout(function () {
                    displayListOfTask();
                    $scope.employeeT = {};
                    $scope.messagebool = false;
                }, 2000);

            }, function (response) {
                    console.log(response);
                $scope.msg = "EmployeeTasks not exist";
            });
        };
    };
}
)();
