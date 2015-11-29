(function () {
    'use strict';

    angular
         .module('capp')
         .controller('contactListController', [
            'contactService', '$scope', '$location', '$mdToast', '$mdDialog', 'notificationService',
            contactListController
         ]);

    function contactListController(contactService, $scope, $location, notificationService) {
        $scope.contacts = [];

        contactService.getAll().then(function (data, errors) {
            data.forEach(function (contact) {
                contact.birthdateParsed = moment(contact.birthdate).format('LLL');
            });
            $scope.contacts = data;
        }, function (errors) {
            notificationService.show('There was an error, couldn\'t fetch contacts.');
        });

        $scope.goToContact = function (contact, e) {
            $location.path('/contacts/' + contact.id);
        }

        $scope.newMeal = function () {
            $location.path('/contacts/new');
        }

    }

})();