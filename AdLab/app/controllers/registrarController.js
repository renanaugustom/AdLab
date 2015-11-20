(function () {
    "use strict";

    angular.module('app.controllers').controller('registrarController', registrarController);

    function registrarController($scope) {

        /*jshint validthis:true */
        var vm = this;

        vm.Usuario = {
            nome: null,
            login: null,
            senha: null,
            confirmarSenha: null
        };



    }
})();