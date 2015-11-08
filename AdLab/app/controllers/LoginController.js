(function () {
    "use strict";

    angular.module('app.controllers').controller('loginCtrl', loginCtrl);

    function loginCtrl($scope, $rootScope, $state, LoginService, UserService, AlertService) {
        $scope.User = {};

        $scope.setOnLoginScreen(true);

        $scope.doLogin = function (user) {
            if (user !== null)
                UserService.setCurrentUser(null);

            LoginService.login(user).success(function (data) {
                user.access_token = data.access_token;
                UserService.setCurrentUser(user);
                $rootScope.$broadcast('authorized');
                $rootScope.setOnLoginScreen(false);
                $state.go('home');
            }).error(function (error) {
                AlertService.addError(error.error_description);
                $scope.User = {};
            });
        };
    }
})();