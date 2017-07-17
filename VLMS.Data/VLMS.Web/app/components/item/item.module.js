/// <reference path="D:\FPTGST\VLMS\Database1\VLMS.Web\Assert/Admin/libs/angular/angular.js" />

(function () {
    angular.module('VLMS.item', ['VLMS.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouteProvider) {
        $stateProvider.state('items', {
            url: "/items",
            templateUrl: "/app/components/item/itemListView.html",
            controller: "itemListController"
        }).state('add_item', {
            url: "/add_item",
            templateUrl: "/app/components/item/itemAddView.html",
            controller: "itemAddController"
        }).state('edit_item',{
            url: "/edit_item/:id",
            templateUrl: "/app/components/item/itemEditView.html",
            controller: "itemEditController"

        });
    }
})();