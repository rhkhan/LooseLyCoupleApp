app.controller('rolePermissionController', function ($scope, permissionFactory, $routeParams, roleService, $parse, Flash) {
 
    $scope.Status = null;
    $scope.currentPage = 1;

    $scope.loadPermissionsGrid = function () {
        permissionFactory.getPermissions()
            .success(function (p) {
                $scope.permissions = p;
                //$scope.myVar = p.Status;
            })
            .error(function () {
                $scope.status = 'Unable to load permissions' + error.message;
            })
    }

    $scope.loadPermissionsWithStatusGrid = function () {
        permissionFactory.getPermissionStat($routeParams.aspRolesID)
        .success(function (data) {
            $scope.permissions = data;
        })
        .error(function () {
            $scope.status = 'Unable to load permissions' + error.message;
        })
    }



    $scope.SavePermission = function (id,rowIndex,checkVal,pDes) {
  
        var pr = {};
        pr.RoleId = $routeParams.aspRolesID;
        pr.PermissionId = id;
 
        if (checkVal == true) {
                roleService.addPermissionToRole(pr)
                .success(function () {
                    $scope.Status = pDes + " has been added ";
                    //var id = Flash.create('success', $scope.Status, 0, { class: 'custom-class', id: 'custom-id' }, true);
                    Flash.create('success', $scope.Status);
                })
                .error(function () {
                    alert("Can't add permission");
                })
        }else {
            
                 roleService.removePermissionFromRole(pr)
                .success(function () {
                    $scope.Status = pDes + " has been removed ";
                    //var id = Flash.create('danger', $scope.Status, 0, { class: 'custom-class', id: 'custom-id' }, true);
                    Flash.create('danger', $scope.Status);
                })
                .error(function () {
                    alert("Can't remove permission");
                })
        }
        


    }

    //$scope.RemovePermission = function (id, rowIndex, PermissionDescription) {
    //    var pr = {};
    //    pr.RoleId = $routeParams.aspRolesID;
    //    pr.PermissionId = id;
    //    roleService.removePermissionFromRole(pr)
    //    .success(function () {
    //        alert("Permission Removed");
    //    })
    //    .error(function () {
    //        alert("Can't remove permission");
    //    })
    //}

    
    $scope.$watch('Status', function () {


    })


    $scope.ngRepeatIndex = function (index, currentPage) {
        $scope.number = (index) + (currentPage - 1) * 5;
        //alert($scope.number+" s "+index+" d "+currentPage)
    }


    $scope.pageChanged = function (curPage) {
        alert("DD: " + curPage);
    }
});


//app.controller("ngRepeatIndexController", function ($scope) {
//    alert("ee");
//    $scope.number = ($scope.$index + 1) + ($scope.currentPage - 1) * $scope.pageSize;
//})