(function () {
    'use strict';

    angular
        .module('capp')
        .config(['$mdThemingProvider', themeConfig]);

    function themeConfig($mdThemingProvider) {
        $mdThemingProvider.theme('default')
            .primaryPalette('light-blue')
            .accentPalette('red');
    };
})();