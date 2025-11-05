'use strict';

(function () {
  angular
    .module('productApp')
    .factory('ProductService', ['$http', 'API_BASE_URL', function ($http, API_BASE_URL) {
      var baseUrl = API_BASE_URL + '/products';

      function getAll() {
        return $http.get(baseUrl).then(handleSuccess, handleError);
      }

      function getById(id) {
        return $http.get(baseUrl + '/' + id).then(handleSuccess, handleError);
      }

      function create(product) {
        return $http.post(baseUrl, product).then(handleSuccess, handleError);
      }

      function update(id, product) {
        return $http.put(baseUrl + '/' + id, product).then(handleSuccess, handleError);
      }

      function remove(id) {
        return $http.delete(baseUrl + '/' + id).then(handleSuccess, handleError);
      }

      function handleSuccess(response) { return response.data; }
      function handleError(error) { return Promise.reject(error.data || error); }

      return {
        getAll: getAll,
        getById: getById,
        create: create,
        update: update,
        remove: remove
      };
    }]);
})();
