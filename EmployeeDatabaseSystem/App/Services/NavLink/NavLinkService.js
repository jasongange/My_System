(function () {

    'use strict';

    angular.module('mainApp').factory('NavLinkService', NavLinkService);

    NavLinkService.$inject = ['$http', '$q'];

    function NavLinkService($http, $q) {

        var NavLinkService = {};

        NavLinkService.GetAllNavLink = function (model) {
            return $http({
                url: document.NavLink + '/GetAllNavLink',
                method: 'GET',
                data: JSON.stringify(model)
            });
        };

        NavLinkService.IndexView = function (model) {
            return $http({
                url: document.NavLink + '/IndexView',
                method: 'GET',
                data: JSON.stringify(model)
            });
        };

        NavLinkService.SearchNavLink = function (params) {
            return $http({
                url: document.NavLink + '/SearchNavLink',
                method: 'GET',
                params: params
            });
        };

        NavLinkService.AddNavLink = function (model) {
            return $http({
                url: document.NavLink + '/AddNavLink',
                method: 'POST',
                data: JSON.stringify(model)
            });
        };

        NavLinkService.GetNavLinkDetails = function (params) {
            return $http({
                url: document.NavLink + '/GetNavLinkDetails',
                method: 'GET',
                params: params
            });
        };

        NavLinkService.Delete = function (params) {
            return $http({
                url: document.NavLink + '/Delete',
                method: 'POST',
                params: params
            });
        };

        return NavLinkService;

    }
})();