(function () {
    "use strict";

    angular.module('app.services').service('UsuarioAPI', UsuarioAPI);

    function UsuarioAPI($http, API_URI) {
        return {
            registrar: function (usuario, successCallback, errorCallback) {
                return $http.post(API_URI + 'usuario/registrar', usuario).success(successCallback).error(errorCallback);
            }
        };
    }
})();