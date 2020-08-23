(function () {
    'use strict';
    angular.module('mainApp').controller('MainController', MainController);

    MainController.$inject = ["$scope"]

    function MainController($scope) {
        var vm = this;

        $scope.text = "";
        vm.headerText = "";

        var sample = "sample";

        console.log($scope);
        console.log(vm);
        console.log(sample);
    }
})();