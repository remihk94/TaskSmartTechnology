using Microsoft.EntityFrameworkCore;
using SmartTechnology.Data;
using SmartTechnology.Models;

namespace SmartTechnology.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db)
        {
            _db = db;
        }

        #region Methods
        #region product functions
        public async Task<List<Product>> GetProductsAsync(bool includeProductVariants)
        {
            try
            {
                if(includeProductVariants) // if we want to include the related product variants 
                return await _db.Products.Include(c=>c.ProductVariants).ThenInclude(c=>c.Color)
                    .Include(c=>c.ProductVariants).ThenInclude(c=>c.Size).ToListAsync();

                else return await _db.Products.ToListAsync();

            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Product> GetProductAsync(int id, bool includeProductVariants)
        {
            try
            {
                if (includeProductVariants) //  should be included
                {
                    var productDb = await _db.Products.Include(b => b.ProductVariants).ThenInclude(p=>p.Color).Include(b => b.ProductVariants).ThenInclude(p=>p.Size)
                        .FirstOrDefaultAsync(i => i.Id == id);
                    return productDb;
                }

              
                return await _db.Products.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<Product> AddProductAsync(Product product)
        {
            try
            {
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();
                return await _db.Products.FindAsync(product.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null;  
            }
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            try
            {
                // getting old product from db
                var productDb = await _db.Products.Include(c=>c.ProductVariants).FirstAsync(c=>c.Id == product.Id);
                // old product variants should be delelted first
                if (productDb.ProductVariants != null)
                {
                    foreach (var item in productDb.ProductVariants)
                    {
                        var pv = _db.ProductVariants.Find(item.Id);
                        _db.ProductVariants.Remove(pv);
                    }
                }

                // assign new values 
                productDb.ProductVariants = product.ProductVariants;
                productDb.DescriptionEN = product.DescriptionEN;
                productDb.DescriptionAR = product.DescriptionAR;
                productDb.DescriptionFR = product.DescriptionFR;
                productDb.NameAR = product.NameAR;
                productDb.NameEN = product.NameEN;
                productDb.NameFR = product.NameFR;


                //updating productDb object
                _db.Entry(productDb).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return productDb;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteProductAsync(Product product)
        {
            try
            {
                // getting product from DB
                var dbProduct = await _db.Products.FindAsync(product.Id);

                if (dbProduct == null)
                {
                    return (false, "Product could not be found");
                }
                // delete product
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();

                return (true, "Product got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }
        #endregion
        #region product variants
        // here are methods to get seed data that related to product variants
        public async Task<List<Color>> GetColorsAsync()
        {
            try
            {
                return await _db.Colors.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Size>> GetSizesAsync()
        {
            try
            {
                return await _db.Sizes.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #endregion
    }
}
