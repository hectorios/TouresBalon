/*global angular*/
(function () {
    'use strict';

    angular
        .module('simplAdmin.paymentCreditCard', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('payments-creditcard-config', {
                        url: '/payments/creditcard/config',
                        templateUrl: '_content/SimplCommerce.Module.PaymentCreditCard/admin/config/config-form.html',
                        controller: 'CreditCardConfigFormCtrl as vm'
                    })
                    ;
            }
        ]);
})();
