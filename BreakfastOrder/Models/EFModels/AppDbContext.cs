using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BreakfastOrder.Models.EFModels
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<AddOnCategory> AddOnCategories { get; set; }
        public virtual DbSet<AddOnOption> AddOnOptions { get; set; }
        public virtual DbSet<ProductAddOnDetail> ProductAddOnDetails { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddOnCategory>()
                .HasMany(e => e.AddOnOptions)
                .WithRequired(e => e.AddOnCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AddOnCategory>()
                .HasMany(e => e.ProductAddOnDetails)
                .WithRequired(e => e.AddOnCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AddOnOption>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<AddOnOption>()
                .HasMany(e => e.ProductAddOnDetails)
                .WithRequired(e => e.AddOnOption)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ProductCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductAddOnDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
