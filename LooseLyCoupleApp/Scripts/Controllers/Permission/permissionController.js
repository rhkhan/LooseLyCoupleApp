//var app = angular.module('LooslyCoupleApp');
app.controller("permissionController", ['$scope', '$routeParams', 'permissionFactory', 'modalService', 'viewModelHelper', '$timeout', 'permissionValidator','models', function ($scope, $routeParams, permissionFactory, modalService, viewModelHelper, $timeout, permissionValidator,models) {

    var vm = this;
    vm.valResult = {};
    vm.permission = {};
    vm.permission = new models.permission(vm.permission);

    $scope.getPermissions = function () {
        permissionFactory.getPermissions()
            .success(function (p) {
                $scope.permissions = p;
            })
            .error(function () {
                $scope.status = 'Unable to load roles' + error.message;
            })
    }

    vm.submitForm = function () {
        var Permission = {};
        

        var unregisterValidatorWatch =
            $scope.$watch(
                            function () { return vm.permission; },
                            function () {
                                vm.valResult = permissionValidator.validate(vm.permission);
                            }, true);

                            if (vm.permission.$isValid) {
                                Permission.PermissionDescription = vm.permission.description;
                                var promisePost = permissionFactory.SavePermission(Permission);
                                promisePost.then(function (d) {
                                    viewModelHelper.navigateTo('Permission/List');
                                }, function (err) {
                                    alert("Some Error Occured ");
                                });
                                unregisterValidatorWatch();
                            }

    }

    $scope.initiateEditPermission = function () {
       init();
    }

    var init = function () {
        $scope.permission = {};
        permissionFactory.getPermissionbyId($routeParams.permissionId)
       .success(function (p) { 
           $scope.permission.Id = p.Id;
           $scope.permission.PermissionDescription = p.PermissionDescription;
      })
      .error(function (error) {
          $scope.status = "unable to load role: " + error.message;
      });
    }

    $scope.EditPermission = function () {
        var Permission = {};
        Permission.Id = $scope.permission.Id;
        Permission.PermissionDescription = $scope.permission.PermissionDescription;
        var promisePUT = permissionFactory.updatePermission(Permission)
        promisePUT.then(
                function(success){
                    viewModelHelper.navigateTo('Permission/List');
                },
                function(error){
                    alert("unable to edit");
                }
            );
    }

    $scope.deletePermission = function (id) {
      
        var modalOptions = {
            closeButtonText: 'Cancel',
            actionButtonText: 'Delete Permission',
            headerText: 'Delete ' + id + '?',
            bodyText: 'Are you sure you want to delete this Permission?'
        };

        $timeout(function () {
            modalService.showModal({}, modalOptions).then(function (result) {
                if (result === 'ok') {
                    var promiseDelete=  permissionFactory.deletePermission(id);
                    promiseDelete.then(function (success) {
                        $scope.getPermissions();
                        viewModelHelper.navigateTo('Permission/List');
                    }, function (error) {
                        $window.alert('Error deleting Permission: ' + error.message);
                    });
                }
            });
        });

    }

}]);