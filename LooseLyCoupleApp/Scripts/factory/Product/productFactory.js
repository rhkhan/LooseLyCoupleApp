app.factory("productFactory", function ($http) {
    var urlBase = '/api/products';
    var productFactory = {}


    productFactory.getProducts = function () {
        return $http.get(urlBase + "/GetAll");
    }


    return productFactory;

})