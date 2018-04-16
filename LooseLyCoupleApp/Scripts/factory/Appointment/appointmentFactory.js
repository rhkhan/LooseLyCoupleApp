app.factory("appointmentFactory", function ($http) {
    var urlBase = '/api/appointment';
    var appointmentFactory = {};

    appointmentFactory.saveAppointment = function (mAppoint) {
        alert("ss" + mAppoint.PatientName);
        return $http.post(urlBase, mAppoint);
    }

    appointmentFactory.getAppointments = function () {
        return $http.get(urlBase);
    }

    appointmentFactory.getAppointmentById = function (id) {
        return $http.get(urlBase+"/info/"+id);
    }

    appointmentFactory.updateApp = function (appoints) {
        var appointInfo = {
            Id: appoints.Id,
            PatientName: appoints.PatientName,
            Phone: appoints.Phone,
            appType:appoints.appType,
            appID: appoints.appID,
            SI: appoints.SI,
            appDate:appoints.appDate
        }
        return $http.put(urlBase, appointInfo);
    }

    return appointmentFactory;
});