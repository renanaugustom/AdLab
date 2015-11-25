(function () {
    "use strict";

    angular.module('app.services').service('PerfilService', PerfilService);

    function PerfilService(AlertService, UserService, UsuarioAPI) {
        var vm = {
            init: init,
            carregarPerfil: carregarPerfil,
            atualizarPerfil: atualizarPerfil
        };

        function init() {
            vm.Perfil = {
                nome: null,
                login: null,
                email: null,
                senha: null,
                confirmarSenha: null,
                alterarSenha: false
            };
        }

        function carregarPerfil() {
            var usuarioLogado = UserService.getCurrentUser();

            UsuarioAPI.buscarPeloLogin(usuarioLogado.user, function (resposta) {
                vm.Perfil = angular.copy(resposta.data);
            }, function (error) {
                AlertService.addError(error.message);
            });
        }

        function atualizarPerfil() {
            if (validaPerfil()) {
                UsuarioAPI.atualizarUsuario(vm.Perfil, function (resposta) {
                    AlertService.addSuccess(resposta.mensagem);
                }, function (error) {
                    AlertService.addError(error.message);
                });
            }
        }

        function validaPerfil() {
            if (!vm.Perfil.login) {
                AlertService.addWarning("Preencha o login.");
                return false;
            }

            if (!vm.Perfil.nome) {
                AlertService.addWarning("Preencha o nome.");
                return false;
            }

            if (!vm.Perfil.email) {
                AlertService.addWarning("Preencha o e-mail.");
                return false;
            }

            if(vm.Perfil.alterarSenha)
                if(vm.Perfil.senha != vm.Perfil.confirmarSenha){
                    AlertService.addWarning("Senha e confirmar senha devem ser iguais.");
                    return false;
                }

            return true;
        }

        return vm;
        
    }
})();