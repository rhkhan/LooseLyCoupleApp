app.factory("permissionFactory", function ($http) {
    var urlBase = '/api/permission';
    var permissionFactory = {}

    permissionFactory.SavePermission = function (p) {
        return $http.post(urlBase+"/add",p);
    }

    permissionFactory.getPermissions = function () {
        return $http.get(urlBase + "/GetAll");
    }

    permissionFactory.getPermissionbyId = function (id) {
        return $http.get(urlBase + "/edit/" + id);
    }

    permissionFactory.updatePermission = function (p) {
        return $http.put(urlBase + "/" + p.Id, p);
    }

    permissionFactory.deletePermission = function (id) {
        return $http.delete(urlBase+"/delete/"+id);
    }

    permissionFactory.getPermissionStat = function (id) {
        return $http.get(urlBase + "/permissionStat/" + id);
    }

    return permissionFactory;

})