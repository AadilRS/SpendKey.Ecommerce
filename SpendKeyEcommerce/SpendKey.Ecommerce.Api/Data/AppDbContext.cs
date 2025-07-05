using Microsoft.EntityFrameworkCore;
using SpendKey.Ecommerce.Api.Models;

namespace SpendKey.Ecommerce.Api.Data
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Cart> Carts { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Category>()
                    .HasOne(c => c.Parent)
                    .WithMany(c => c.Children)
                    .HasForeignKey(c => c.Parent_Id)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
}

