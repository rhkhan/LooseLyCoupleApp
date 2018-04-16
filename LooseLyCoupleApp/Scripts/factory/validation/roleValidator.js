app.factory('RoleModelValidator', function (validator) {
    //var models = {};
    //models.Role = function(){
    //    this.Name = null;
    //};
    //return models;

    var RoleModelValidator = s = new validator();
    s.ruleFor('name').notEmpty();
    s.ruleFor('name').length(3);

    return RoleModelValidator;
});