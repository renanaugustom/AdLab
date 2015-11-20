(function () {
    "use strict";

    angular.module('app.controllers').controller('perfilController', perfilController);

    function perfilController($scope) {
        
        /*jshint validthis:true */
        var perfilCtrl = this;

        perfilCtrl.vm = {
            Login:"Renan"
        };

    }
})();