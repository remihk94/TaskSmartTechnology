using Microsoft.EntityFrameworkCore;
using SmartTechnology.Models;

namespace SmartTechnology.Data
{
    public class AppDbContext : DbContext
    {
        //NOTE: In order to start do not forget to update database from package manager console 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Define relationship between product and product variant
            builder.Entity<ProductVariant>()
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductVariants);

            // Define relationship between product variant and color
            builder.Entity<ProductVariant>()
                .HasOne(x => x.Color)
                .WithMany(x => x.ProductVariants);

            // Define relationship between product variant and size
            builder.Entity<ProductVariant>()
                .HasOne(x => x.Size)
                .WithMany(x => x.ProductVariants);

            // Seed database for demo
            new DbInitializer(builder).Seed();
        }
    
    }
}
