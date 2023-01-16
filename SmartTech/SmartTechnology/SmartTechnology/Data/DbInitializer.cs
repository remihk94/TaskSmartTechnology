using Microsoft.EntityFrameworkCore;
using SmartTechnology.Models;

namespace SmartTechnology.Data
{
    public class DbInitializer 
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }
        public void Seed()
        {
            // Seeding Colors and Sizes
            _builder.Entity<Color>(a =>
            {
                a.HasData(new Color
                {
                    Id = 1,
                    ColorValueAr = "أحمر",
                     ColorValueEn = "Red",
                     ColorValueFr = "Rose"
                });
                a.HasData(new Color
                {
                    Id =2,
                    ColorValueAr = "أزرق",
                    ColorValueEn = "Blue",
                    ColorValueFr = "Blue"
                });
            });
            _builder.Entity<Size>(a =>
            {
                a.HasData(new Size
                {
                    Id=1,
                   SizeValue = 36
                });
                a.HasData(new Size
                {
                    Id = 2,
                    SizeValue = 37
                });
                a.HasData(new Size
                {
                    Id=3,
                    SizeValue = 38
                });
                a.HasData(new Size
                {
                    Id = 4,
                    SizeValue = 39
                });
                a.HasData(new Size
                {
                    Id = 5,
                    SizeValue = 40
                });
            });
        }
    }
}
