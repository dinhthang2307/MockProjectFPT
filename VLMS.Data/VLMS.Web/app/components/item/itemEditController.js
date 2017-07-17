(function (app) {
    app.controller('itemEditController', itemEditController);

    itemEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams'];

    function itemEditController(apiService, $scope, notificationService, $state, $stateParams) {
        $scope.item = {
          
        }

        $scope.EditItem = function () {
            apiService.put('api/item/update', $scope.item,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('items');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        $scope.loadItemDetail = loadItemDetail;
        function loadItemDetail() {
            apiService.get('api/item/getbyid/' + $stateParams.id, null, function (result) {
                $scope.item = result.data;
            }), function (error) {
                notificationService.displayError(error.data);
            };
        }

        loadItemDetail();
    }
})(angular.module('VLMS.item'));