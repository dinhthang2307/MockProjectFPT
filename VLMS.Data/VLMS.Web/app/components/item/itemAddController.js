(function (app) {
    app.controller('itemAddController', itemAddController);

    itemAddController.$inject = ['apiService', '$scope', 'notificationService', '$state'];

    function itemAddController(apiService, $scope, notificationService, $state) {
        $scope.item = {
            CreatedDateTime: new Date(),
            IsActive: true,

        }

        $scope.AddItem = function () {
            apiService.post('api/item/create', $scope.item,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('items');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
    }
})(angular.module('VLMS.item'));