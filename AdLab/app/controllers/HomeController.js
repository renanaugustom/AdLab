(function () {
    "use strict";

    angular.module('app.controllers').controller('homeController', homeController);

    function homeController($scope) {
        $scope.setOnLoginScreen(false);
    }
})();