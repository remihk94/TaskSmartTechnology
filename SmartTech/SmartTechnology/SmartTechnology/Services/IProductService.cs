using SmartTechnology.Models;

namespace SmartTechnology.Services
{
    public interface IProductService
    {
        // NOTE: here we have all methods related to products, (e.g CRUD operations)
        // methods for getting product variants like Color, Size that are related to products are added
        // Product Variants in this code are Color and Size 

        /// <summary>
        /// GET All Products
        /// Returns all products in the database 
        /// </summary>
        /// <param name="includeProductVariants"></param>
        /// boolean parameter to define whether to include products variants or not.
        Task<List<Product>> GetProductsAsync(bool includeProductVariants);

        /// <summary>
        /// GET Single Product
        /// </summary>
        /// <param name="id"></param>
        /// Define the id of the product to get
        /// <param name="includeVariants"></param>
        /// boolean parameter to define whether to include product variants or not.
        Task<Product> GetProductAsync(int id, bool includeVariants = false);


        /// <summary>
        /// POST New Product
        /// </summary>
        /// <param name="product"></param>
        /// Defines the product object to create
        Task<Product> AddProductAsync(Product product);


        /// <summary>
        /// PUT Product
        /// Update specific product in the database 
        /// </summary>
        /// <param name="product"></param>
        /// Defines the product object to update
        Task<Product> UpdateProductAsync(Product product);


        /// <summary>
        /// DELETE Product
        /// </summary>
        /// <param name="product"></param>
        /// Defines the product object to delete
        Task<(bool, string)> DeleteProductAsync(Product product);


        /// <summary>
        /// GET All Colors
        /// Returns all colors in the database 
        /// </summary>
        Task<List<Color>> GetColorsAsync();

        /// <summary>
        /// GET All Colors
        /// Returns all sizes in the database 
        /// </summary>
        Task<List<Size>> GetSizesAsync();  


    }
}
