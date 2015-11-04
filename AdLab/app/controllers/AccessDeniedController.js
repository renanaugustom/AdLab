(function () {
    "use strict";

    angular.module('app.controllers').controller('AccessDeniedController', AccessDeniedController);

    function AccessDeniedController($rootScope, $state) {

        function load()
        {
            setTimeout(function () {
                $state.go("login");
            }, 5000);
        }

        load();
    }
})();