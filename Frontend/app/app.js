'use strict';

(function () {
  angular
    .module('productApp', ['ngRoute'])
    .config(['$routeProvider', function ($routeProvider) {
      $routeProvider
        .when('/products', {
          templateUrl: 'app/views/products.html',
          controller: 'ProductController',
          controllerAs: 'vm'
        })
        .otherwise({ redirectTo: '/products' });
    }])
    .constant('API_BASE_URL', '/api'); // ajuste se sua API estiver em outra URL
})();
