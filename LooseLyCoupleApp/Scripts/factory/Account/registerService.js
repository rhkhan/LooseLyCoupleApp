app.factory("registerService", function ($http) {

    var urlBase = '/api/account';
    var registerService = {}

    registerService.getRoles = function () {
        return $http.get(urlBase + "/roles");
    }

    registerService.saveUser = function (registerUser) {
        return $http.post(urlBase, registerUser);
    }

    registerService.getUsers = function () {
        return $http.get(urlBase);
    }

    registerService.getRolesOfUser = function (id) {
        return $http.get(urlBase+"/"+id)
    }

    registerService.getUserInfo = function (id) {
        return $http.get(urlBase + "/info/" + id)
    }

    registerService.updateUser = function (registerUser) {
        //alert(registerUser.selectedRole[0].name);

        var arr=[];
        for(var i=0;i<registerUser.selectedRole.length;i++)
            arr.push(registerUser.selectedRole[i].id);

        var userInfo = {
            Id: registerUser.Id,
            Firstname: registerUser.Firstname,
            Lastname: registerUser.Lastname,
            selectedRole:arr
        }
        return $http.put(urlBase, userInfo);
     
    }

    return registerService;
});