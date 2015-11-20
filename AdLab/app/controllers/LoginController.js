(function () {
    "use strict";

    angular.module('app.controllers').controller('loginCtrl', loginCtrl);

    function loginCtrl($scope, $rootScope, $state, LoginService, UserService, AlertService) {
        $scope.User = {
            user: null,
            password: null
        };

        $scope.setOnLoginScreen(true);

        $scope.doLogin = function (user) {
            if (user !== null)
                UserService.setCurrentUser(null);

            if (validateUser(user)) {
                LoginService.login(user).success(function (data) {
                    user.access_token = data.access_token;
                    UserService.setCurrentUser(user);
                    $rootScope.$broadcast('authorized');
                    $rootScope.setOnLoginScreen(false);
                    $state.go('home');
                }).error(function (error) {
                    AlertService.addWarning(error.error_description);
                    $scope.User = {};
                });
            } else {
                AlertService.addWarning("Preencha os campos login e senha.");
            }
            
        };

        function validateUser(user)
        {
            if (user.user && user.password)
                return true;

            return false;
        }
    }
})();