using ProductCRUD.Domain.Entities;
using System.Data.Entity;
using ProductCRUD.Data.Migrations;

namespace ProductCRUD.Data.Context
{
    public class ProductContext : DbContext
    {
        static ProductContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductContext, Configuration>());
        }

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
