(function () {

    'use strict';

    angular.module('mainApp').factory('HomeService', HomeService);

    HomeService.$inject = ['$http', '$q'];

    function HomeService($http, $q) {

        var HomeService = {};

        HomeService.Login = function (model) {
            return $http({
                url: document.NavLink + '/GetAllNavLink',
                method: 'GET',
                data: JSON.stringify(model)
            });
        };
        return AppUserService;

    }
})();