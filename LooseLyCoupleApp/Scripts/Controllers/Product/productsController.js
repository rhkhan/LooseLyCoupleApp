app.controller("productsController", ['$scope', '$routeParams', 'modalService', 'viewModelHelper', 'productFactory', function ($scope, $routeParams, modalService, viewModelHelper, productFactory) {


    $scope.getProducts = function () {
        productFactory.getProducts()
            .success(function (p) {
                $scope.products = p;
            })
            .error(function () {
                $scope.status = 'Unable to load roles' + error.message;
            })
    }

}]);
