(function() {
    'use strict';

    angular.module('productApp')
        .controller('ProductController', ['ProductService', ProductController]);

    function ProductController(ProductService) {
        var vm = this;

        vm.products = [];
        vm.product = {};
        vm.isEditing = false;
        vm.errorMessage = '';
        vm.successMessage = '';

        vm.loadProducts = loadProducts;
        vm.saveProduct = saveProduct;
        vm.editProduct = editProduct;
        vm.deleteProduct = deleteProduct;
        vm.cancelEdit = cancelEdit;

        init();

        function init() {
            loadProducts();
        }

        function loadProducts() {
            ProductService.getAll()
                .then(function(response) {
                    vm.products = response.data;
                })
                .catch(function(error) {
                    showError('Erro ao carregar produtos');
                });
        }

        function saveProduct() {
            if (!validateProduct()) return;

            if (vm.isEditing) {
                updateProduct();
            } else {
                createProduct();
            }
        }

        function createProduct() {
            ProductService.create(vm.product)
                .then(function(response) {
                    showSuccess('Produto criado com sucesso!');
                    loadProducts();
                    cancelEdit();
                })
                .catch(function(error) {
                    showError('Erro ao criar produto');
                });
        }

        function updateProduct() {
            ProductService.update(vm.product.Id, vm.product)
                .then(function(response) {
                    showSuccess('Produto atualizado com sucesso!');
                    loadProducts();
                    cancelEdit();
                })
                .catch(function(error) {
                    showError('Erro ao atualizar produto');
                });
        }

        function editProduct(product) {
            vm.product = angular.copy(product);
            vm.isEditing = true;
        }

        function deleteProduct(id) {
            if (!confirm('Deseja realmente excluir este produto?')) return;

            ProductService.remove(id)
                .then(function() {
                    showSuccess('Produto excluído com sucesso!');
                    loadProducts();
                })
                .catch(function(error) {
                    showError('Erro ao excluir produto');
                });
        }

        function cancelEdit() {
            vm.product = {};
            vm.isEditing = false;
            clearMessages();
        }

        function validateProduct() {
            if (!vm.product.Nome || !vm.product.Preco) {
                showError('Preencha todos os campos obrigatórios');
                return false;
            }
            return true;
        }

        function showSuccess(message) {
            vm.successMessage = message;
            vm.errorMessage = '';
            setTimeout(clearMessages, 3000);
        }

        function showError(message) {
            vm.errorMessage = message;
            vm.successMessage = '';
        }

        function clearMessages() {
            vm.successMessage = '';
            vm.errorMessage = '';
        }
    }
})();