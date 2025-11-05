(function() {
    'use strict';

    angular.module('productApp')
        .factory('ProductService', ['$http', 'API_URL', ProductService]);

    function ProductService($http, API_URL) {
        var service = {
            getAll: getAll,
            getById: getById,
            create: create,
            update: update,
            remove: remove
        };

        return service;

        function getAll() {
            return $http.get(API_URL);
        }

        function getById(id) {
            return $http.get(API_URL + '/' + id);
        }

        function create(product) {
            return $http.post(API_URL, product);
        }

        function update(id, product) {
            return $http.put(API_URL + '/' + id, product);
        }

        function remove(id) {
            return $http.delete(API_URL + '/' + id);
        }
    }
})();