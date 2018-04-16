app.factory('userValidator', function (validator) {
    var userValidator = s = new validator();
    s.ruleFor('Firstname').notEmpty();
    s.ruleFor('Lastname').notEmpty();
    s.ruleFor('Email').notEmpty();
    s.ruleFor('Email').emailAddress();
    s.ruleFor('PasswordHash').notEmpty().withMessage("Password is required.");
    s.ruleFor('confirmPassword').notEmpty().withMessage("Confirm password is required");
    s.ruleFor('confirmPassword').equal(checkPandConfirmP).withMessage("password and confirm password should be the same");
    s.ruleFor('selectedRole').greaterThan(0).when(SelectedRolesCount).withMessage("At least one role needs to be selected");

    function checkPandConfirmP(u) {
        return u.PasswordHash;
    }

    function SelectedRolesCount(ur) {
        return ur.selectedRole == undefined;
    }

    return userValidator;
});