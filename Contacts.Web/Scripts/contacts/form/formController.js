(function () {
    'use strict';

    angular
         .module('capp')
         .controller('contactFormController', [
            'contactService', '$scope', '$location', '$mdToast', '$mdDialog', '$window', '$routeParams', 'notificationService',
            contactFormController
         ]);

    function contactFormController(contactService, $scope, $location, $mdToast, $mdDialog, $window, $routeParams, notificationService) {
        $scope.contactInfoTypes = ["home", "work", "mobile", "other"];
        $scope.email = { isDeleted: false };
        $scope.phone = { isDeleted: false };

        $scope.contact = {
            tags: [],
            contactInfos: []
        };

        if ($routeParams.id != "new") {
            contactService.getById($routeParams.id).then(function (data, errors) {
                $scope.contact = data;
                if ($scope.contact.birthDate) {
                    $scope.contact.birthDate = moment($scope.contact.birthDate).toDate();
                }
            }, function (errors) {
                notificationService.show('There was an error, couldn\'t fetch contact.');
            });
        }

        $scope.save = function () {
            if ($scope.contactForm.$valid) {
                var contact = $scope.contact;
                if (contact.birthDate) {
                    contact.birthDate = moment(contact.birthDate).format().split('T')[0];
                }
                (contact.id ? contactService.edit(contact, contact.id) : contactService.save(contact)).then(function (data, errors) {
                    notificationService.show('You have successfully saved the changes.');
                    if (!contact.id) {
                        $location.path('/contacts/' + data.id)
                    }
                }), function (errors) {
                    notificationService.show('There was an error while saving changes.');
                }
            } else {
                notificationService.show('Please enter all the required data and in valid format.');
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
                contactService.remove(contact.id).then(function (data, errors) {
                    notificationService.show('Successfully deleted contact.');
                    $location.path('/');
                }, function (errors) {
                    notificationService.show('There was an error, couldn\'t delete contact.');
                });
            });
        }

        $scope.deleteContactInfo = function (contactInfo, e) {
            contactInfo.isDeleted = true;
        }

        $scope.addContactInfo = function (contactInfo, name, e) {
            if (contactInfo.value && contactInfo.type) {
                contactInfo.name = name;
                $scope.contact.contactInfos.push(contactInfo);

                if (name == 'phone') {
                    $scope.phone = { isDeleted: false };
                } else if (name == 'email') {
                    $scope.email = { isDeleted: false };
                }
            } else {
                notificationService.show('Please enter value and type for the contact info.');
            }
        }

    }

})();