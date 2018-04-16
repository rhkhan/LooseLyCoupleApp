// indexController.js

app.controller('indexController',
['$scope','$routeParams', '$location', 'loginService', '$cookieStore', 'viewModelHelper', function ($scope,$routeParams, $location, loginService, $cookieStore, viewModelHelper) {

    "use strict";

    var vm = this;
    //$scope.foo_list_selection = loginService.checkUserCookie();
    this.initializeController = function () {
        //vm.title = "Home Page";
        //alert("cookie");
        vm.userCookie = $cookieStore.get('uName');
        //alert("Logout " + $cookieStore.get('uName'));
    }

    vm.logout = function () {
        //alert("Logout " + $cookieStore.get('uName'));
        loginService.logout()
        .success(function () {
            $cookieStore.remove('uName');
            loginService.setLoginState("");
           // $scope.foo_list_selection = loginService.checkUserCookie();
            $location.path('/');
            return;
        })
    }

    this.login = function () {
        //alert(vm.user.username + " , " + vm.user.userpassword);
        //alert("dd " + vm.user);
        var user = {};
        user.Username = vm.user.Username;
        user.PasswordHash = vm.user.PasswordHash;

        loginService.loginData(user)
        .success(function (per) {
            vm.succesLogin = user.Username + " has Logged in successfully.";
            $cookieStore.put('uName', user.Username);
            //$scope.foo_list_selection = loginService.checkUserCookie();
            loginService.setLoginState(user.Username);
            viewModelHelper.navigateTo('Home/Index');
            //$location.path('/');
            return;
            //alert('login successfull' + per[0].Id + " " + per[0].PermissionDescription);
        })
        .error(function (error) {
            vm.succesLogin = "Login failed, please enter username and password correctly";
        })
    }

    //$scope.$watch(vm.userCookie, function () {
        //alert("v " + vm.userCookie);
        
       // loginService.checkUserCookie(vm.userCookie);
        //$scope.zzz = vm.userCookie;
   // })

}]);