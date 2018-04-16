//(function () {

//    var app = angular.module('codeProject', ['ngRoute', 'ui.bootstrap', 'ngSanitize', 'blockUI']);

//    app.config(['$controllerProvider', '$provide', function ($controllerProvider, $provide) {

//        app.register =
//        {
//            controller: $controllerProvider.register,
//            service: $provide.service
//        };

//    }]);

//})();



//var commonModule = angular.module('common', ['ngRoute']);
//var angularMvcIntegration = angular.module('LooslyCoupleApp', ['common']);

//commonModule.factory('viewModelHelper', function ($http, $q, $window, $location) {
//    return LooslyCoupleApp.viewModelHelper($http, $q, $window, $location);
//});


//angularMvcIntegration.controller("indexViewModel", function ($scope) {

//    $scope.sessionName = "ASP.NET MVC with Angular JS";
//    $scope.speakerName = "Rashedul Hossain Khan";
//});

var app = angular.module('LooslyCoupleApp', ['ngRoute', 'ui.bootstrap', 'ngCookies', 'angularUtils.directives.dirPagination', 'ngFlash', 'ngFluentValidation', 'ngSanitize', '720kb.datepicker']);
app.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/Role/List', {
                        templateUrl: '/Htmls/Role/index.html',
                        controller: 'roleOperationController', // Controller will be initialized after promise has been resolved
                        resolve: {
                            roleList: function (roleService) {
                                return roleService.getRoleList();
                            }
                        }
                        }) // calling html template
                  .when('/Role/Create', {
                      templateUrl: '/Htmls/Role/create.html', controller: 'roleOperationController',
                      resolve: {
                          roleList: function () {
                              return "";
                          }
                      }
                  })
                  .when('/Role/edit/:aspRolesID', { templateUrl: '/Htmls/Role/edit.html', controller: 'roleEditGetController' })
                  .when('/Role/assignPermission/:aspRolesID', {templateUrl:'/Htmls/Role/assignPermission.html'})
                  .when('/Home/About', { templateUrl: '/Htmls/About/about.html' })
                  .when('/Home/Index', {templateUrl: '/Htmls/partials/index.html' })
                  .when('/Register/List', { templateUrl: '/Htmls/Register/list.html' })
                  .when('/Register/Create', { templateUrl: '/Htmls/Register/create.html' })
                  .when('/Register/Edit/:userID', { templateUrl: '/Htmls/Register/edit.html', controller: 'registerEditController' })
                  .when('/Permission/Create', { templateUrl: '/Htmls/Permission/create.html' })
                  .when('/Permission/List', { templateUrl: '/Htmls/Permission/list.html' })
                  .when('/Permission/Edit/:permissionId', { templateUrl: '/Htmls/Permission/edit.html' })
                  .when('/Product/List', { templateUrl: '/Htmls/Product/list.html' })
                  .when('/Product/Create', { templateUrl: '/Htmls/Product/create.html' })
                  .when('/Authorize/Error', { templateUrl: '/Htmls/Error/authorizeError.html' })
                  .when('/Login/user', { templateUrl: '/Htmls/partials/index.html' })
                  .when('/Appointment/List', { templateUrl: '/Htmls/Appointment/list.html' })
                  .when('/Appointment/Create', { templateUrl: '/Htmls/Appointment/create.html' })
                  .when('/Appointment/Edit/:appointID', {templateUrl:'/Htmls/Appointment/edit.html'})
                  .when('/', { templateUrl: '/Htmls/partials/index.html' }); //, controller: 'indexController' 
                   $locationProvider.html5Mode(true);
});

                app.run(['$rootScope', function ($root) {
                    $root.$on('$routeChangeStart', function (e, curr, prev) {
                        if (curr.$$route && curr.$$route.resolve) {
                            // Show a loading message until promises aren't resolved
                            $root.loadingView = true;
                        }
                    });
                    $root.$on('$routeChangeSuccess', function (e, curr, prev) {
                        // Hide loading message
                        $root.loadingView = false;
                    });
                }]);

//angular.module('LooslyCoupleApp')
    app.factory('viewModelHelper', function ($http, $q, $window, $location) { return LooslyCoupleApp.viewModelHelper($http, $q, $window, $location); });

(function (LooslyCoupleApp) {
    var viewModelHelper = function ($http, $q, $window, $location) {

        var self = this;

        self.modelIsValid = true;
        self.modelErrors = [];

        self.resetModelErrors = function () {
            self.modelErrors = [];
            self.modelIsValid = true;
        }

        self.apiGet = function (uri, data, success, failure, always) {
            self.modelIsValid = true;
            $http.get(LooslyCoupleApp.rootPath + uri, data)
                .then(function (result) {
                    success(result);
                    if (always != null)
                        always();
                }, function (result) {
                    if (failure != null) {
                        failure(result);
                    }
                    else {
                        var errorMessage = result.status + ':' + result.statusText;
                        if (result.data != null && result.data.Message != null)
                            errorMessage += ' - ' + result.data.Message;
                        self.modelErrors = [errorMessage];
                        self.modelIsValid = false;
                    }
                    if (always != null)
                        always();
                });
        }

        self.apiPost = function (uri, data, success, failure, always) {
            self.modelIsValid = true;
            $http.post(LooslyCoupleApp.rootPath + uri, data)
                .then(function (result) {
                    success(result);
                    if (always != null)
                        always();
                }, function (result) {
                    if (failure != null) {
                        failure(result);
                    }
                    else {
                        var errorMessage = result.status + ':' + result.statusText;
                        if (result.data != null && result.data.Message != null)
                            errorMessage += ' - ' + result.data.Message;
                        self.modelErrors = [errorMessage];
                        self.modelIsValid = false;
                    }
                    if (always != null)
                        always();
                });
        }

        self.goBack = function () {
            $window.history.back();
        }

        self.navigateTo = function (path) {
            $location.path(LooslyCoupleApp.rootPath + path);
        }

        self.refreshPage = function (path) {
            $window.location.href = LooslyCoupleApp.rootPath + path;
        }

        self.clone = function (obj) {
            return JSON.parse(JSON.stringify(obj))
        }

        return this;
    };
    LooslyCoupleApp.viewModelHelper = viewModelHelper;
}(window.LooslyCoupleApp));
