
/*
angularRoleLooslyCouple.factory("roleService", function ($http, viewModelHelper) {
    var urlBase = '/api/roles';
    var roleService = {}

    roleService.getRoleList = function () {
        return $http.get(urlBase);
    }

    roleService.saveRole = function (role) {
        return $http.post(urlBase, role);
    }

    roleService.getRoleInfo = function (id) {
        var req = $http.get(urlBase+'/' + id);
        return req;
    }

    roleService.updateRole = function (role) {
        var req = $http.put(urlBase + "/" + role.AspRolesID, role);
        return req;
    }

    roleService.deleteRole = function (role) {
        var req = $http.delete(urlBase + "/" + role.AspRolesID);
        return req;
    }

    return roleService;

});

*/

app.factory("roleService", function ($http) {
    var urlBase = '/api/roles';
    var roleService = {}

    roleService.getRoleList = function () {
        var promise = $http.get(urlBase);
        return promise;
    }

    roleService.saveRole = function (role) {
        return $http.post(urlBase, role);
    }

    roleService.getRoleInfo = function (id) {
        var req = $http.get(urlBase + '/' + id);
        return req;
    }

    roleService.updateRole = function (role) {
        var req = $http.put(urlBase + "/" + role.AspRolesID, role);
        return req;
    }

    roleService.deleteRole = function (role) {
        return $http.delete(urlBase + "/" + role.AspRolesID);
    }

    roleService.addPermissionToRole = function (pr) {
        return $http.post(urlBase + "/AddPermissionToRole",pr);
    }

    roleService.removePermissionFromRole = function (pr) {
        //alert(pr.PermissionId + " ssddd " + pr.RoleId)
        //var p =new Object();
        //p.RoleId = pr.RoleId;
        //p.PermissionId = pr.PermissionId;
        return $http.delete(urlBase + "/RemovePermissionFromRole?RoleId=" + pr.RoleId + "&PermissionId=" + pr.PermissionId);
    }

    return roleService;

});