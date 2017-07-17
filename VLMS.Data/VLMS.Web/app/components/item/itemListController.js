(function (app) {
    app.controller('itemListController', itemListController);

    itemListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function itemListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.Item = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getItem = getItem;
        $scope.keyWord = '';

        $scope.search = search; 
        function search() {
            getItem();
        }
        $scope.deleteItem = function (id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }

                apiService.del('api/item/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }),
                function () {
                    notificationService.displayError('Xóa không thành công');
                }
            });
        }
        function getItem(page) {
            page = page || 0;
            var config = {
                params: {
                    keyWord: $scope.keyWord,
                    page: page,
                    pageSize:6
                }
            }
            apiService.get('/api/item/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi');

                }
                $scope.Item = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load item failed.');
            });
        }

        $scope.getItem();
    }
})(angular.module('VLMS.item'));