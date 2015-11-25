
(function () {
    "use strict";

    angular.module('app.controllers').controller('perfilController', perfilController);

    function perfilController($scope, PerfilService) {
        
        /*jshint validthis:true */
        var vc = this;
        vc.vm = PerfilService;
        vc.vm.carregarPerfil();


        vc.atualizarPerfil = function (form) {
            form.submitted = true;
            if (validaForm(form))
                vc.vm.atualizarPerfil();
        };


        function validaForm(form) {
            if (form.$invalid)
                return false;
            
            return true;
        }
    }
})();