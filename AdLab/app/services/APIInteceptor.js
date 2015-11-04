(function () {
    "use strict";

    angular.module('app.services').service('APIInterceptor', APIInterceptor);

    function APIInterceptor($rootScope, $q, UserService) {

        var service = this;

        service.request = function (config) {
            var currentUser = UserService.getCurrentUser(),
                access_token = currentUser ? currentUser.access_token : null;

            if (access_token) {
                config.headers.authorization = 'Bearer ' + access_token;
            }
            return config;
        };

        service.responseError = function (response) {
            if (response.status === 401) {
                $rootScope.$broadcast('unauthorized');
            }
            return $q.reject(response);
        };

    }
})();