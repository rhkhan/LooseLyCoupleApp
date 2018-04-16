//angular.module('LooslyCoupleApp').value('RolesOfUser', []);

app.controller("registerController", function ($scope, viewModelHelper, registerService, userRoleService, $uibModal, models, userValidator) {

    loadRoles();
    $scope.animationsEnabled = true;

    function loadRoles() {
        registerService.getRoles()
        .success(function (roleData) {
            $scope.roleList = roleData;
        })
          .error(function () {
              $scope.status = 'Unable to load roles' + error.message;
          })
    
    }

    $scope.AssignedRoles = function (id) {
        registerService.getRolesOfUser(id)
        .success(function (roledata) {
            //$scope.urole = roledata;
            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'myModalContent.html',
                controller: 'ModalInstanceCtrl',
                size: 'lg',
                resolve: {
                    items: function () {
                        return roledata;
                    }
                }
            });
        })
        .error(function(){$scope.status='No role is found for this user'})
    }

    $scope.open = function (size) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent.html',
            controller: 'ModalInstanceCtrl',
            size: size,
            resolve: {
                items: function () {
                    return $scope.items;
                }
            }
        });
    }


    $scope.initUsers = function () {
        registerService.getUsers()
        .success(function (userData) {
            $scope.userList = userData;
        })
        .error(function () {
            $scope.status = 'Unable to load users' + error.message;
        })
    }

    $scope.user = {};
    $scope.submitForm=function() {
        
        var reguser = new models.register($scope.user);
        $scope.valResult = {};
        var unregisterValidatorWatch =
            $scope.$watch(
                function () {
                    return reguser;
                },
                function () {
                    //alert("dd");
                    $scope.valResult = userValidator.validate(reguser);
                    
                    if (reguser.$isValid) {
                        var promisePost = registerService.saveUser($scope.user);
                        viewModelHelper.navigateTo('Register/List');
                        unregisterValidatorWatch();
                    }
                },true);
    }

    // Modal Dialog Close section
    $scope.ok = function () {
        $scope.showModal = false;
    };

    $scope.cancel = function () {
        $scope.showModal = false;
    };
    // Modal Dialog Close

});

app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, items) {
    $scope.items = items;
    $scope.ok = function () {
        $uibModalInstance.close('close');
    };
    //$scope.cancel = function () {
    //    $uibModalInstance.dismiss('cancel');
    //};
});


app.controller("registerEditController", function ($scope, $routeParams, registerService, userRoleService, viewModelHelper) {

    $scope.userId = $routeParams.userID;
    $scope.user = {};
    registerService.getUserInfo($routeParams.userID)
    .success(function (user) {
        $scope.user.Id = user.Id;
        $scope.user.Firstname = user.Firstname;
        $scope.user.Lastname = user.Lastname;
        $scope.user.Username = user.Username;
        $scope.user.PasswordHash = user.PasswordHash;
    })
    .error(function (error) {
        $scope.status = "unable to load role: " + error.message;
    });

    $scope.loadSelect = function () {
        registerService.getRoles()
         .success(function (roleData) {
             var objRolesArray = [];
             for (var i = 0; i < roleData.length; i++)
                 objRolesArray.push({ id: roleData[i].AspRolesID, name: roleData[i].Name });

             $scope.roles = objRolesArray;
         })

        var uroleArr = [];
        registerService.getRolesOfUser($routeParams.userID)
        .success(function (urdata) {
            for (var i = 0; i < urdata.length; i++)
                uroleArr.push({ id: urdata[i].Id, name: urdata[i].Name });
        })

        $scope.user = {};
        $scope.user.selectedRole = uroleArr
        //$scope.user.roles = [{ id: 3, name: "hello" }, { id: 2, name: 'Student' }]; 
    }


    $scope.EditRegisterForm = function () {
        var promisePost = registerService.updateUser($scope.user);
        viewModelHelper.navigateTo('Register/List');
    }

});