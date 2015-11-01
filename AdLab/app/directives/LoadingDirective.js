(function () {
    "use strict";

    angular.module('app.directives').directive('loader', LoadingDirective);
    LoadingDirective.$inject = ['$rootScope'];

    function LoadingDirective($rootScope) {
        return function ($scope, element, attrs) {
            $scope.$on("loader_show", function () {
                $scope.showEl = true;
                return;
            });
            return $scope.$on("loader_hide", function () {
                $scope.showEl = false;
                return;
            });
        };
    }
})();
