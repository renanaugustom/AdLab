(function () {
    "use strict";

    angular.module('app.controllers').controller('accessDeniedController', accessDeniedController);

    function accessDeniedController($rootScope, $state) {

        function load()
        {
            setTimeout(function () {
                $state.go("login");
            }, 5000);
        }

        load();
    }
})();