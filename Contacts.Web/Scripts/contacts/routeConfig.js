(function () {
    'use strict';

    angular
        .module('capp')
        .config(['$routeProvider', '$locationProvider', routeConfig]);

    function routeConfig($routeProvider) {
        $routeProvider
          .when('/', {
              controller: 'contactListController',
              templateUrl: 'Scripts/contacts/list/list.html',
              label: 'Contacts'
          })
          .when('/contacts/:id', {
              controller: 'contactFormController',
              templateUrl: 'Scripts/contacts/form/form.html',
              caseInsensitiveMatch: true
          })
          .otherwise({ redirectTo: '/' });

    };
})();

