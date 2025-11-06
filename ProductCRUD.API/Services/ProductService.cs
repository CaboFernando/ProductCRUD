using System;
using System.Collections.Generic;
using System.Linq;
using ProductCRUD.API.Models;
using ProductCRUD.Domain.Entities;
using ProductCRUD.Domain.Repositories;
using ProductCRUD.Data.Repositories;

namespace ProductCRUD.API.Services
{
    public interface IProductService : IDisposable
    {
        IEnumerable<ProductReadDto> GetAll();
        ProductReadDto GetById(int id);
        ProductReadDto Create(ProductCreateDto dto);
        ProductReadDto Update(int id, ProductUpdateDto dto);
        bool Delete(int id);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService() : this(new ProductRepository()) { }

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ProductReadDto> GetAll()
        {
            return _repo.GetAll().Select(MapToReadDto).ToList();
        }

        public ProductReadDto GetById(int id)
        {
            var entity = _repo.GetById(id);
            return entity == null ? null : MapToReadDto(entity);
        }

        public ProductReadDto Create(ProductCreateDto dto)
        {
            var entity = new Product
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco
            };
            var created = _repo.Create(entity);
            return MapToReadDto(created);
        }

        public ProductReadDto Update(int id, ProductUpdateDto dto)
        {
            var entity = new Product
            {
                Id = id,
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco
            };
            var updated = _repo.Update(entity);
            return updated == null ? null : MapToReadDto(updated);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public void Dispose()
        {
            var disposable = _repo as IDisposable;
            if (disposable != null) disposable.Dispose();
        }

        private static ProductReadDto MapToReadDto(Product p)
        {
            return new ProductReadDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                DataCadastro = p.DataCadastro
            };
        }
    }
}
