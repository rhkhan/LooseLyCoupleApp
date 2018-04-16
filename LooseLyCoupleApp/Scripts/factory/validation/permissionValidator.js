app.factory('permissionValidator', function (validator) {
    var permissionValidator = s = new validator();
    s.ruleFor('description').notEmpty();
    s.ruleFor('description').equal(0).when(descriptionFormat).withMessage("Permission Format will be MenuText-MethodText"); // works if function returns true.

    function descriptionFormat(p) {
        //alert(!(/^[a-zA-Z0-9]*-[a-zA-Z0-9]*$/.test(p.description)));
        return !(/^[a-zA-Z0-9]+-[a-zA-Z0-9]+$/.test(p.description)); // Convert the incorrect(false) formatted result to opposite value.
    }

    return permissionValidator;
});