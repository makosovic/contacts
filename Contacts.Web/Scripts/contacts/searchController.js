(function () {
    'use strict';

    angular
         .module('capp')
         .controller('searchController', [
            'contactService', '$mdToast', '$location',
            searchController
         ]);

    function searchController(contactService, $mdToast, $location) {
        this.querySearch = function querySearch(query) {
            return contactService.search(query);
        };

        this.selectedItemChange = function (item) {
            $location.path('/contacts/' + item.id);
        };
    }

})();