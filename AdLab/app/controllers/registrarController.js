(function () {
    "use strict";

    angular.module('app.controllers').controller('registrarController', registrarController);

    function registrarController($scope, $state, AlertService, UsuarioAPI) {

        /*jshint validthis:true */
        var vm = this;

        function init() {
            vm.Usuario = {
                nome: null,
                email: null,
                login: null,
                senha: null,
                confirmarSenha: null
            };
        }

        vm.registrar = function (form) {
            if(validaUsuario(form))
            {
                UsuarioAPI.registrar(vm.Usuario, function () {
                    AlertService.addSuccess("Usuário registrado com sucesso! Você será redirecionado para o login.");
                    form.$setPristine();
                    init();
                    setTimeout(function () {
                        $state.go('login');
                    }, 5000);
                }, function (error) {
                    AlertService.addWarning(error.message);
                });
            }
        };

        function validaUsuario(form) {
            if (form.$invalid)
                return false;

            return true;
        }



    }
})();