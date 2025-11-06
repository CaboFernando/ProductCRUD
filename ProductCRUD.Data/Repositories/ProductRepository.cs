using ProductCRUD.Data.Context;
using ProductCRUD.Domain.Entities;
using ProductCRUD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProductCRUD.Data.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private readonly ProductContext _context;
        private bool _disposed;

        public ProductRepository()
        {
            _context = new ProductContext();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.AsNoTracking().OrderBy(p => p.Nome).ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public Product Create(Product product)
        {
            product.DataCadastro = DateTime.Now;
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Update(Product product)
        {
            var existing = _context.Products.Find(product.Id);
            if (existing != null)
            {
                existing.Nome = product.Nome;
                existing.Descricao = product.Descricao;
                existing.Preco = product.Preco;
                _context.Entry(existing).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return existing;
        }

        public bool Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
