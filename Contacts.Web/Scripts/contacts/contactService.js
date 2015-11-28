(function () {
    'use strict';

    angular
        .module('capp')
        .service('contactService', [
            '$http', '$q',
            contactService
        ]);

    function contactService($http, $q) {
        var getAll = function () {
            return getResult($http.get('/api/contacts'));
        };

        var search = function (phrase) {
            return getResult($http.get('/api/contacts/search?phrase=' + phrase));
        };

        var getById = function (contactId) {
            return getResult($http.get('/api/contacts/' + contactId));
        };

        var remove = function (contactId) {
            return getResult($http.delete('/api/contacts/' + contactId));
        };

        var edit = function (contact, contactId) {
            return getResult($http.put('/api/contacts/' + contactId, contact));
        };

        var save = function (contact) {
            return getResult($http.post('/api/contacts', contact));
        };

        var getResult = function (promise) {
            var deferred = $q.defer();
            promise.then(function (result) {
                deferred.resolve(result.data);
            }), function () {
                deferred.reject(result.status);
            };
            return deferred.promise;
        };

        return {
            getAll: getAll,
            search: search,
            getById: getById,
            remove: remove,
            edit: edit,
            save: save
        };
    }
})();