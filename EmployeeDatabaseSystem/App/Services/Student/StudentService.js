(function () {

    'use strict';

    angular.module('mainApp').factory('StudentService', StudentService);

    StudentService.$inject = ['$http', '$q'];

    function StudentService($http, $q) {

        var StudentService = {};

        StudentService.SearchStudent = function (params) {
            return $http({
                url: document.Student + '/SearchStudent',
                method: 'GET',
                params: params
            });
        };

        StudentService.AddStudent = function (model) {
            return $http({
                url: document.Student + '/AddStudent',
                method: 'POST',
                data: JSON.stringify(model)
            });
        };

        StudentService.GetStudentDetails = function (params) {
            return $http({
                url: document.Student + '/GetStudentDetails',
                method: 'GET',
                params: params
            });
        };

        StudentService.Delete = function (params) {
            return $http({
                url: document.Student + '/Delete',
                method: 'POST',
                params: params
            });
        };

        StudentService.TagAsPaid = function (params) {
            return $http({
                url: document.Student + '/TagAsPaid',
                method: 'POST',
                params: params
            });
        };

        return StudentService;
    }
})();