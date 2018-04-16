app.factory('appointmentValidator', function (validator) {
    var appointmentValidator = s = new validator();
    s.ruleFor('PatientName').notEmpty();
    s.ruleFor('Phone').notEmpty();
    s.ruleFor('appType').equal(0).when(checkAppointmentType).withMessage("select appointment type");
    s.ruleFor('appID').notEmpty();
    s.ruleFor('SI').notEmpty();
    s.ruleFor('appDate').notEmpty();

    function checkAppointmentType(v) {
        if (v.appType == "0")
            return true;
        return false;
    }

    return appointmentValidator;
});