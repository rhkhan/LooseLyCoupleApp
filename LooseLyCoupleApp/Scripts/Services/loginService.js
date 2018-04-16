app.service("loginService", function ($http,$cookieStore) {

    var urlBase='/api/account'

    this.loginData = function (user) {
        //alert(user.Username + " " + user.PasswordHash);
        //RoleId=" + pr.RoleId + "&PermissionId=" + pr.PermissionId
        return $http.get(urlBase + "/getLoginData?Username=" + user.Username + "&PasswordHash=" + user.PasswordHash);
    }

    this.logout = function () {
        return $http.get(urlBase + "/logout");
    }


    this.logState = null;
    this.setLoginState = function (s) {
        this.logState = $cookieStore.get('uName');
        return this.logState;
    }

});