/// <reference path="D:\FrontEnd\FPTMock\G3_Thăng\Database1\VLMS.Web\Assert/Admin/libs/angular/angular.js" />
(function () {
    angular.module('VLMS.category', ['VLMS.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('categories', {
            url: "/categories",
            templateUrl: "/app/components/category/categoryListView.html",
            controller: "categoryListController"
        }).state('add_category', {
            url: "/add_category",
            templateUrl: "/app/components/category/categoryAddView.html",
            controller: "categoryAddController"
        }).state('edit_category', {
            url: "/edit_category/:id",
            templateUrl: "/app/components/category/categoryEditView.html",
            controller: "categoryEditController"

        });
    }
})();