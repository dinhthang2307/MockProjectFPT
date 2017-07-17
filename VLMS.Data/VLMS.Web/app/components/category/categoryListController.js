(function (app) {
    app.controller('categoryListController', categoryListController);

    categoryListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];

    function categoryListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.Categories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getCategory = getCategory;
        $scope.keyWord = '';

        $scope.search = search;
        function search() {
            getCategory();
        }
        $scope.deleteCategory = function (id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }

                apiService.del('api/category/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }),
                function () {
                    notificationService.displayError('Xóa không thành công');
                }
            });
        }
        function getCategory(page) {
            page = page || 0;
            var config = {
                params: {
                    keyWord: $scope.keyWord,
                    page: page,
                    pageSize: 6
                }
            }
            apiService.get('/api/category/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi');

                }
                $scope.Categories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load item failed.');
            });
        }

        $scope.getCategory();
    }
})(angular.module('VLMS.category'));