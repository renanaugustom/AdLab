(function () {
    "use strict";

    angular.module('app.directives').directive('menu', menu);
    angular.module('app.controllers').controller('menuController', menuController);

    function menu() {
        return {
            restrict: 'E',
            replace: true,
            scope: {
                menus: '='
            },
            link: function ($scope, $element) {

            },
            templateUrl: 'templates/directives/menu.html'
        };
    }


    function menuController($scope, $state, UserService) {
        var nomeUsuario = UserService.getCurrentUser().user;

        function logout() {
            UserService.setCurrentUser(null);
            $state.go('login');
        }

        $scope.menus = {
            "itens": [
                {
                    link: "",
                    text: "Gerenciar",
                    submenu: [
                        { link: "#", text: "Equipamentos", iconClass: "fa fa-desktop" },
                        { link: "#", text: "Usuários", iconClass: "fa fa-users" }
                    ]
                },
                {
                    link: "#",
                    text: "Agendamento"
                },
            ],
            "opcoes": [
                {
                    link: "",
                    text: nomeUsuario,
                    submenu: [
                        { link: "#/perfil", text: "Perfil", iconClass: "fa fa-user" },
                        { link: "", text: "Logout", action: logout, iconClass:"fa fa-sign-out" },
                    ]
                }
            ]
        };
    }
})();

