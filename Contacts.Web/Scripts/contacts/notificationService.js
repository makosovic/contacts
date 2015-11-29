(function () {
    'use strict';

    angular
        .module('capp')
        .service('notificationService', [
            '$mdToast',
            notificationService
        ]);

    function notificationService($mdToast) {


        var show = function (message) {
            $mdToast.show(
              $mdToast.simple()
                .content(message)
                .position('bottom left')
                .hideDelay(5000)
            );
        };

        return {
            show: show,
        };
    }
})();