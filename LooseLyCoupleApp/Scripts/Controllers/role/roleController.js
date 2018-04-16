/*
angularRoleLooslyCouple.controller("roleOperationController", function ($scope, roleService, viewModelHelper, modalService) {
    getRoles();

    function getRoles() {
        roleService.getRoleList()
            .success(function (roles) {
            $scope.roleList = roles;
            })
            .error(function () {
                $scope.status = 'Unable to load roles' + error.message;
            })
    }


    $scope.createRole = function () {
        //alert("Create role");
        viewModelHelper.navigateTo('Role/create');
    }


    $scope.editRole = function () {
        viewModelHelper.navigateTo('Role/edit/' + this.r.AspRolesID);
    }

    $scope.EditRoleForm = function () {
        var AspRoles = {};
        AspRoles.AspRolesID = this.vmr.roleId;
        AspRoles.Name = this.vmr.roleName;
        var promisePut = roleService.updateRole(AspRoles);
        promisePut.then(
            function (r) {
                alert("success");
                getRoles();
            },
            function (error) { alert("Unable to update");}
            );

    }

    $scope.submitForm = function () {
        alert("sss");
        var AspRolesFormViewModel = {};
        AspRolesFormViewModel.Name = this.role.name;
            
        var promisePost = roleService.saveRole(AspRolesFormViewModel);
            promisePost.then(function (d) {
                alert("Success");
                getRoles();
            }, function (err) {
                alert("Some Error Occured ");
            });
    };



    $scope.deleteRole = function () {
        var AspRoles = {};
        AspRoles.AspRolesID = this.r.AspRolesID;

        var modalOptions = {
            closeButtonText: 'Cancel',
            actionButtonText: 'Delete Role',
            headerText: 'Delete ' + this.r.AspRolesID + '?',
            bodyText: 'Are you sure you want to delete this role?'
        };

        modalService.showModal({}, modalOptions).then(function (result) {
            if (result === 'ok') {
                roleService.deleteRole(AspRoles).then(function (success) {
                    $window.alert("success");
                    getRoles();
                }, function (error) {
                    $window.alert('Error deleting role: ' + error.message);
                });
            }
        });


    }
});
*/

app.controller("roleOperationController", function ($scope, roleService, modalService, viewModelHelper, $timeout, models, RoleModelValidator, roleList) {
    getRoles();

    $scope.hasModelErrors = false;

    function getRoles() {
        //roleService.getRoleList()
        //    .success(function (roles) {
        //$scope.roleList = roles;

        $scope.roleList = roleList.data;
            //})
            //.error(function (error) {
            //    $scope.status = 'Unable to load roles' + error.message;
            //})
    }


    $scope.createRole = function () {
        //alert("Create role");
        viewModelHelper.navigateTo('Role/create');
    }


    $scope.editRole = function () {
        viewModelHelper.navigateTo('Role/edit/' + this.r.AspRolesID);
    }



    $scope.role = {};
    $scope.submitForm = function () {

        var AspRolesFormViewModel = {};
        $scope.hasModelErrors = false;

        AspRolesFormViewModel.Name = $scope.role.name;
        var role = new models.role(AspRolesFormViewModel);


        /* Angular Validator Code */
        var unregisterValidatorWatch =
       $scope.$watch(
                      function () {
                           return role;
                       },
                     function () {
                         $scope.valResult = RoleModelValidator.validate(role);
                            if (role.$isValid) {
                                roleService.saveRole(AspRolesFormViewModel)
                                .success(function (data) {
                                    //alert("abc");
                                    viewModelHelper.navigateTo('Role/List');
                                })
                                .error(function (error) {
                                    var strmsg = JSON.stringify(error.ModelState);
                                    
                                    /*spliting the errors*/
                                    var resSubstring = strmsg.substring(strmsg.indexOf("[") + 1, strmsg.indexOf("]"));
                                    var arrString = resSubstring.split(",");
                                    var g = "";
                                    for (var i = 0; i < arrString.length; i++)
                                        g += arrString[i] + "<br/>";
                                    $scope.error = g;
                                    /* End Spliting*/

                                    $scope.hasModelErrors = true;
                                });
                                //promisePost.then(function (success) {
                                //    $scope.hasModelErrors = false;
                                //    viewModelHelper.navigateTo('Role/List');

                                //}, function (error) {
                                //    $scope.error = JSON.stringify(error.ModelState);
                                //    $scope.hasModelErrors = true;
                                //});

                                unregisterValidatorWatch();
                            }
                        }, true);

        /* End Angular Validator Code*/

    };



    $scope.deleteRole = function () {
        var AspRoles = {};
        AspRoles.AspRolesID = this.r.AspRolesID;

        var modalOptions = {
            closeButtonText: 'Cancel',
            actionButtonText: 'Delete Role',
            headerText: 'Delete ' + this.r.AspRolesID + '?',
            bodyText: 'Are you sure you want to delete this role?'
        };

        $timeout(function () {
            modalService.showModal({}, modalOptions).then(function (result) {
                if (result === 'ok') {
                    roleService.deleteRole(AspRoles).then(function (success) {
                        viewModelHelper.navigateTo('Role/List');
                        //getRoles();
                    }, function (error) {
                        $window.alert('Error deleting role: ' + error.message);
                    });
                }
            });
        });

    }

    $scope.sort = function (keyname) {
        //alert("dd");
        $scope.sortKey = keyname;
        $scope.reverse = !$scope.reverse;
    }
});



app.controller('roleEditGetController', function ($scope, $routeParams, roleService, viewModelHelper) {
    $scope.roleId = $routeParams.aspRolesID;
    $scope.vmr = {};
    roleService.getRoleInfo($routeParams.aspRolesID)
    .success(function (role) {
        $scope.vmr.roleId = role.AspRolesID;
        $scope.vmr.roleName = role.Name;
    })
    .error(function (error) {
        $scope.status = "unable to load role: " + error.message;
    });


    $scope.EditRoleForm = function () {
        //alert("entered");
        var AspRoles = {};
        AspRoles.AspRolesID = this.vmr.roleId;
        AspRoles.Name = this.vmr.roleName;
        var promisePut = roleService.updateRole(AspRoles);
        promisePut.then(
            function (r) {
                //alert("success");
                //getRoles();
                viewModelHelper.navigateTo('Role/List');
            },
            function (error) { alert("Unable to update"); }
            );

    }

});