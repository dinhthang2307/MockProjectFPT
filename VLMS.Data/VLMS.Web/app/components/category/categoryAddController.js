(function (app) {
    app.controller('categoryAddController', categoryAddController);

    categoryAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function categoryAddController(apiService, $scope, notificationService, $state) {
        $scope.category = {
            CreatedDateTime: new Date(),
            IsActive: true,

        }

        $scope.AddCategory = function () {
            apiService.post('api/category/create', $scope.category,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('categories');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
    }
})(angular.module('VLMS.category'));