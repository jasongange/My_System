(function () {

    'use strict';

    angular.module('mainApp').factory('AppUserService', AppUserService);

    AppUserService.$inject = ['$http', '$q'];

    function AppUserService($http, $q) {

        var AppUserService = {};

        AppUserService.Login = function (model) {
            return $http({
                url: document.Account + '/Login',
                method: 'POST',
                data: JSON.stringify(model)
            });
        };

        AppUserService.SearchAppUser = function (params) {
            return $http({
                url: document.AppUser + '/SearchAppUser',
                method: 'GET',
                params: params
            });
        };

        AppUserService.AddAppUser = function (model) {
            return $http({
                url: document.AppUser + '/AddAppUser',
                method: 'POST',
                data: JSON.stringify(model)
            });
        };

        return AppUserService;

    }
})();