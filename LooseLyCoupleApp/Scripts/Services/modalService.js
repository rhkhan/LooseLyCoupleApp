/// <reference path="E:\Rubel_Necessaries\learning\LooseLyCoupleApp\LooseLyCoupleApp\Htmls/partials/modal.html" />
(function () {

    // var injectParams = ['$modal'];
    var injectParams = ['$uibModal']

   // var modalService = function ($modal) {
    var modalService = function ($uibModal) {
        var modalDefaults = {
            backdrop: true,
            keyboard: true,
            modalFade: true,
            templateUrl: '/Htmls/partials/modal.html'
        };

        var modalOptions = {
            closeButtonText: 'Close',
            actionButtonText: 'OK',
            headerText: 'Proceed?',
            bodyText: 'Perform this action?'
        };

        this.showModal = function (customModalDefaults, customModalOptions) {
            if (!customModalDefaults) customModalDefaults = {};
            customModalDefaults.backdrop = 'static';
            return this.show(customModalDefaults, customModalOptions);
        };

        this.show = function (customModalDefaults, customModalOptions) {
            //Create temp objects to work with since we're in a singleton service
            var tempModalDefaults = {};
            var tempModalOptions = {};

            //Map angular-ui modal custom defaults to modal defaults defined in this service
            angular.extend(tempModalDefaults, modalDefaults, customModalDefaults);

            //Map modal.html $scope custom properties to defaults defined in this service
            angular.extend(tempModalOptions, modalOptions, customModalOptions);

            if (!tempModalDefaults.controller) {
                //tempModalDefaults.controller = function ($scope, $modalInstance) {
                tempModalDefaults.controller = function ($scope, $uibModalInstance) {
                    $scope.modalOptions = tempModalOptions;
                    $scope.modalOptions.ok = function (result) {
                        // $modalInstance.close('ok');
                        $uibModalInstance.close('ok')
                    };
                    $scope.modalOptions.close = function (result) {
                        //$modalInstance.close('cancel');
                        $uibModalInstance.close('cancel')
                    };
                };

                //tempModalDefaults.controller.$inject = ['$scope', '$modalInstance'];
                tempModalDefaults.controller.$inject = ['$scope', '$uibModalInstance'];
            }

            //return $modal.open(tempModalDefaults).result;
            return $uibModal.open(tempModalDefaults).result;
        };
    };

    modalService.$inject = injectParams;

    //angularRoleLooslyCouple.service('modalService', modalService);
    angular.module('LooslyCoupleApp').service('modalService', modalService);

}());