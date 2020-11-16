/*global angular, jQuery*/
(function ($) {
    angular
        .module('simplAdmin.paymentCreditCard')
        .controller('CreditCardConfigFormCtrl', ['paymentCreditCardService', 'translateService', CreditCardConfigFormCtrl]);

    function CreditCardConfigFormCtrl(paymentCreditCardService, translateService) {
        var vm = this;
        vm.translate = translateService;
        vm.creditcardConfig = {};

        vm.save = function save() {
            vm.validationErrors = [];
            paymentCreditCardService.updateSetting(vm.creditcardConfig)
                .then(function (result) {
                    toastr.success('Settings have been saved');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not save settings.');
                    }
                });
        };

        function init() {
            paymentCreditCardService.getSettings().then(function (result) {
                vm.creditcardConfig = result.data;
            });
        }

        init();
    }
})(jQuery);
