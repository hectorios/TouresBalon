/*global angular*/
(function () {
    angular
        .module('simplAdmin.paymentCreditCard')
        .factory('paymentCreditCardService', ['$http', paymentCreditCardService]);

    function paymentCreditCardService($http) {
        var service = {
            getSettings: getSettings,
            updateSetting: updateSetting
        };
        return service;

        function getSettings() {
            return $http.get('api/creditcard/config');
        }

        function updateSetting(settings) {
            return $http.put('api/creditcard/config', settings);
        }
    }
})();
