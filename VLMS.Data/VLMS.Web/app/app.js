/// <reference path="D:\FPTGST\VLMS\Database1\VLMS.Web\Assert/Admin/libs/angular/angular.js" />
(function () {
    angular.module('VLMS',
        ['VLMS.item',
        'VLMS.category',
        'VLMS.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('libraryadmin', {
            url: "/libraryadmin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/libraryadmin');
    }
})();