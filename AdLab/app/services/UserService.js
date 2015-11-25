(function () {
    "use strict";

    angular.module('app.services').service('UserService', UserService);

    function UserService(store) {

        var service = this,
        currentUser = null;

        service.setCurrentUser = function (user) {
            currentUser = user;

            if(user !== null)
                delete user.password;

            store.set('user', user);
            return currentUser;
        };

        service.getCurrentUser = function () {
            if (!currentUser) {
                currentUser = store.get('user');
            }
            return currentUser;
        };

        service.isAuthenticated = function () {
            return !!service.getCurrentUser();
        };
    }
})();