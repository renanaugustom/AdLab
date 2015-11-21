
(function () {
    "use strict";

    angular.module('app.controllers').controller('perfilController', perfilController);

    function perfilController($scope, AlertService, UserService, UsuarioAPI) {
        
        /*jshint validthis:true */
        var vm = this;

        function init() {
            vm.Perfil = {
                Nome: null,
                Login: null,
                Email: null,
                Senha: null,
                ConfirmarSenha: null,
                AlterarSenha: false
            };
        }
        init();

        function load() {
            var usuarioLogado = service.getCurrentUser();

            UsuarioAPI.buscaPeloLogin(usuarioLogado.user, function (resposta) {
                vm.Perfil = angular.copy(resposta.data);
            }, function (error) {
                AlertService.addError(error.message);
            });
        }
        load();

    }
})();