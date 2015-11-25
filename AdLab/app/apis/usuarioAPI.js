(function () {
    "use strict";

    angular.module('app.services').service('UsuarioAPI', UsuarioAPI);

    function UsuarioAPI($http, API_URI) {
        return {
            registrar: function (usuario, successCallback, errorCallback) {
                return $http.post(API_URI + 'usuario/registrar', usuario).success(successCallback).error(errorCallback);
            },
            buscarPeloLogin: function (login, successCallback, errorCallback) {
                return $http.get(API_URI + 'usuario?login=' + login).success(successCallback).error(errorCallback);
            },
            atualizarUsuario: function (usuario, successCallback, errorCallback) {
                return $http.put(API_URI + 'usuario/atualizar', usuario).success(successCallback).error(errorCallback);
            }
        };
    }
})();