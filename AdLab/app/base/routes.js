﻿var routes = angular.module('app.routes', []);

routes.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
    $stateProvider
        .state('login', {
            url: '/login',
            templateUrl: 'templates/login.html',
            controller: 'loginCtrl',
            controllerAs: 'login'
        })
        .state('home', {
            url: '/home',
            templateUrl: 'templates/home.html',
            controller: 'homeController',
            controllerAs: 'home'
        })
        .state('perfil', {
            url: '/perfil',
            templateUrl: 'templates/usuario/perfil.html',
            controller: 'perfilController',
            controllerAs: 'vc'
        })
        .state('registrar', {
            url: '/registrar',
            templateUrl: 'templates/registrar.html',
            controller: 'registrarController',
            controllerAs: 'vm'
        })
        .state('accessdenied', {
            url: '/accessdenied',
            templateUrl: 'templates/accessDenied.html',
            controller: 'accessDeniedController',
            controllerAs: 'accessdenied'
        });

    $urlRouterProvider.otherwise('/home');
}]);

routes.run(function ($rootScope, $state, UserService, AlertService) {
    //TODO: Verify if user has permission to access the next route

    $rootScope.$on('$stateChangeStart', function (event, next, nextParams, fromState) {
        AlertService.cleanAlerts();
        if (!UserService.isAuthenticated()) {
            if (next.name !== 'login' && next.name !== 'accessdenied' && next.name !== 'registrar') {
                event.preventDefault();
                $state.go('accessdenied');
            }
        }
    });
});