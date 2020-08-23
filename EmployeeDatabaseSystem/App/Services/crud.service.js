(function () {

    'use strict';

    angular.module('mainApp').factory('CRUDService', CRUDService);

    CRUDService.$inject = ['$http'];

    function CRUDService($http) {

        //======private variables=========
        var config = {
            headers: {
                'Content-Type': 'application/json'
            }
        };
        //======private variables=========

        //Function/Variables to return
        var CRUDService = {
            createEmployee: createEmployee,
            updateEmployee: updateEmployee,
            deleteEmployee: deleteEmployee

        };
        return CRUDService;

        function createEmployee(employee) {

            return $http.post('http://localhost:46853/api/DemoApp/InsertEmployeeDTO', employee);

        }
        function updateEmployee(employee) {

            return $http.post('http://localhost:46853/api/DemoApp/UpdateEmployeeDTO', employee);
        }
        function deleteEmployee(employee) {

            return $http.post('http://localhost:46853/api/DemoApp/DeleteEmployeeDTO', employee);
        }
    }
})();