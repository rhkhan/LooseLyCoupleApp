angular.module('LooslyCoupleApp').service('userRoleService', function () {
    
    var userRoleArr = [];

    this.setUserRole = function (value) {
        this.userRoleArr = value;
    }

    this.getUserRole = function () {
        return this.userRoleArr;
    }

});


//angular.module('start.services').factory('bluetoothFactory', ['$q', '$window', '$rootScope', function($q, $window, $rootScope) {

//    return {
//        connectedDevice : null,       
//        connectedDeviceSet:  function(device)
//        {
//            this.connectedDevice = device;
//        },
//        connectedDeviceGet: function()
//        {
//            return this.connectedDevice;
//        },
//    }
//}]);