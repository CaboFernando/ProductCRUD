'use strict';

(function () {
  angular
    .module('productApp')
    .controller('ProductController', ['ProductService', function (ProductService) {
      var vm = this;
      vm.products = [];
      vm.form = {};
      vm.isEditing = false;

      vm.load = function () {
        ProductService.getAll().then(function (data) {
          vm.products = data || [];
        });
      };

      vm.edit = function (product) {
        vm.form = angular.copy(product);
        vm.isEditing = true;
      };

      vm.cancel = function () {
        vm.form = {};
        vm.isEditing = false;
      };

      vm.save = function () {
        if (vm.isEditing) {
          ProductService.update(vm.form.id || vm.form.Id, vm.form).then(function () {
            vm.load();
            vm.cancel();
          });
        } else {
          ProductService.create(vm.form).then(function () {
            vm.load();
            vm.cancel();
          });
        }
      };

      vm.remove = function (product) {
        var id = product.id || product.Id;
        if (!id) return;
        if (!confirm('Excluir este produto?')) return;
        ProductService.remove(id).then(function () {
          vm.load();
        });
      };

      // init
      vm.load();
    }]);
})();
