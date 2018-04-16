//var models = {};
//models.Role = function(){
//    this.Name = null;
//};
//return models;
app.factory('models', function(){
    var models = {};
    models.role = function (AspRolesFormViewModel) {
        //alert("a " + AspRolesFormViewModel.Name);
        this.name = AspRolesFormViewModel.Name;
    };

    models.register = function (reguser) {
        this.Firstname=reguser.Firstname;
        this.Lastname = reguser.Lastname;
        this.Email = reguser.Email;
        this.Username = reguser.Username;
        this.PasswordHash = reguser.PasswordHash;
        this.confirmPassword = reguser.confirmPassword;
        this.selectedRole = reguser.selectedRole;
    }

    models.permission = function (permission) {
        this.description = permission.description;
    }

    models.appointments = function (appoints) {
        this.PatientName = appoints.PatientName;
        this.Phone = appoints.Phone;
        this.appType = appoints.appType;
        this.appID = appoints.appID;
        this.SI = appoints.SI;
        this.appDate = appoints.appDate;
    }

    return models;
})