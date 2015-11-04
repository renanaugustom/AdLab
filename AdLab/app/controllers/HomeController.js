(function () {
    "use strict";

    angular.module('app.controllers').controller('HomeController', HomeController);

    function HomeController($scope) {
        $scope.setOnLoginScreen(false);
    }
})();