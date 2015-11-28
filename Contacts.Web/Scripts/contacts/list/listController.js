(function () {
    'use strict';

    angular
         .module('capp')
         .controller('contactListController', [
            'contactService', '$scope', '$location', '$mdToast', '$mdDialog',
            contactListController
         ]);

    function contactListController(contactService, $scope, $location, $mdToast, $mdDialog) {
        $scope.contacts = [];

        var getContacts = function () {
            contactService.getAll().then(function (data, errors) {
                data.forEach(function (contact) {
                    contact.birthdateParsed = moment(contact.birthdate).format('LLL');
                });
                $scope.contacts = data;
            }, function (errors) {
                showSimpleToast('There was an error, couldn\'t fetch contacts.');
            });
        };
        getContacts();

        $scope.search = function (filter) {
        }

        $scope.goToContact = function (contact, e) {
            $location.path('/contacts/' + contact.id);
        }

        $scope.newMeal = function () {
            $location.path('/contacts/new');
        }

        $scope.delete = function (contact, e) {
            var confirm = $mdDialog.confirm()
                .parent(angular.element(document.body))
                .title('Delete contact')
                .content('Are you sure you want to delete this contact?')
                .ariaLabel('Delete contact')
                .ok('Delete')
                .cancel('Cancel')
                .targetEvent(e);
            $mdDialog.show(confirm).then(function () {
                contactService.delete(contact.id).then(function (data, errors) {
                    showSimpleToast('Successfully deleted contact.');
                    getContacts();
                }, function (errors) {
                    showSimpleToast('There was an error, couldn\'t delete contact.');
                });
            });
        }

        var showSimpleToast = function (message) {
            $mdToast.show(
              $mdToast.simple()
                .content(message)
                .position('top right')
                .hideDelay(5000)
            );
        };

    }

})();