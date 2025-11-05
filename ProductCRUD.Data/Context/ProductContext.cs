using ProductCRUD.Domain.Entities;
using System.Data.Entity;

namespace ProductCRUD.Data.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(p => p.Preco)
                .HasPrecision(18, 2);
        }
    }
}
