﻿(function (app) {
    app.controller('categoryEditController', categoryEditController);

    categoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function categoryEditController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.category = {

        }

        $scope.EditCategory = function () {
            apiService.put('api/category/update', $scope.category,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('categories');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        $scope.loadCategoryDetail = loadCategoryDetail;
        function loadCategoryDetail() {
            apiService.get('api/category/getbyid/' + $stateParams.id, null, function (result) {
                $scope.category = result.data;
            }), function (error) {
                notificationService.displayError(error.data);
            };
        }

        loadCategoryDetail();
    }
})(angular.module('VLMS.category'));