(function () {

    'use strict';

    angular.module('mainApp').factory('TASKService', TASKService);

    TASKService.$inject = ['$http'];

    function TASKService($http) {

        //======private variables=========
        var config = {
            headers: {
                'Content-Type': 'application/json'
            }
        }
        //======private variables=========

        //Function/Variables to return
        var TASKService = {
            createTask: createTask,
            updateTask: updateTask,
            deleteTask: deleteTask
        };
        return TASKService;


        function createTask(employeeT) {

            return $http.post('http://localhost:46853/api/DemoApp/InsertEmployeeTaskDTO', employeeT, config);

        }
        function updateTask(employeeT) {

            return $http.post('http://localhost:46853/api/DemoApp/UpdateEmployeeTask', employeeT, config);
        }
        function deleteTask(employeeT) {

            return $http.post('http://localhost:46853/api/DemoApp/DeleteEmployeeTaskDTO', employeeT, config);
        }
    }
})();