(function () {
    'use strict';

    angular
         .module('capp')
         .controller('contactFormController', [
            'contactService', '$scope', '$location', '$mdToast', '$mdDialog', '$window', '$routeParams',
            contactFormController
         ]);

    function contactFormController(contactService, $scope, $location, $mdToast, $mdDialog, $window, $routeParams) {
        $scope.contact = {};

        if ($routeParams.id != "new") {
            contactService.getById($routeParams.id).then(function (data, errors) {
                $scope.contact = data;
                $scope.contact.birthdate = moment($scope.contact.birthdate).toDate();
            }, function (errors) {
                showSimpleToast('There was an error, couldn\'t fetch contact.');
            });
        }

        $scope.save = function () {
            if ($scope.contactForm.$valid) {
                var contact = $scope.contact;
                contact.birthdate = moment(contact.birthdate).format().split('+')[0];
                (contact.id ? contactService.edit(contact, contact.id) : contactService.save(contact)).then(function (data, errors) {
                    showSimpleToast('You have successfully saved the changes.');
                }), function (errors) {
                    showSimpleToast('There was an error while saving changes.');
                }
            } else {
                showSimpleToast('Please enter all the required data and in valid format.');
            }
        }

        $scope.cancel = function () {
            $window.history.back();
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