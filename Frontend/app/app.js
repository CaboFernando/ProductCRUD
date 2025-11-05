(function() {
    'use strict';

    angular.module('productApp', ['ngRoute'])
        .config(['$routeProvider', function($routeProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: 'app/views/products.html',
                    controller: 'ProductController',
                    controllerAs: 'vm'
                })
                .otherwise({
                    redirectTo: '/'
                });
        }])
        .constant('API_URL', 'https://localhost:44370/api/products');
})();