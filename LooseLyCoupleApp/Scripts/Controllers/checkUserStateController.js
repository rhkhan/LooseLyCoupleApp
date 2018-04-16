app.controller('checkUserStateController', function (loginService, $scope) {
    $scope.$watch(function () {
        return loginService.logState;
    }, function (newValue) {
        $scope.userState = newValue;
    });
})