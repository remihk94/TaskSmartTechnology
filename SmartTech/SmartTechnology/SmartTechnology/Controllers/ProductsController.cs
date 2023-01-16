using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartTechnology.Dto;
using SmartTechnology.Models;
using SmartTechnology.Services;

namespace SmartTechnology.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        #region Fields
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        #endregion
        #region ctor
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        #endregion
        #region controller methods
        [HttpGet("/products")]
        // gettings all products from database 
        public async Task<IActionResult> GetProducts(bool includeProductVariants = false)
        {
            var products = await _productService.GetProductsAsync(includeProductVariants);
            
            if (products == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No products in database");
            }
           
            return StatusCode(StatusCodes.Status200OK, _mapper.Map<List<Product>,List<ProductDto>>(products));
        }

        [HttpGet("id")]
        // getting single product by id
        // includeProductVariants parameter is to define including related objects 
        public async Task<IActionResult> GetProduct(int id, bool includeProductVariants = false)
        {
            Product product = await _productService.GetProductAsync(id, includeProductVariants);

            if (product == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Product found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, _mapper.Map<Product,ProductDto>(product));
        }

        [HttpPost]
        //NOTE: in this method we should remove id parameter from swagger ui object because
        //the product id is generated automatically in db 
        public async Task<ActionResult<Product>> AddProduct(AddEditProductDto aeProductDto)
        {
            var product = _mapper.Map<AddEditProductDto, Product>(aeProductDto);
            var dbProduct = await _productService.AddProductAsync(product);

            if (dbProduct == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{product.NameEN} could not be added.");
            }

            return CreatedAtAction("GetProduct", new { id = product.Id }, _mapper.Map<Product, AddEditProductDto>(dbProduct));
        }

        [HttpPut("id")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, AddEditProductDto aeProductDto)
        {
            if (id != aeProductDto.Id)
            {
                return BadRequest();
            }
            var product = _mapper.Map<AddEditProductDto, Product>(aeProductDto);
            
            var updated = await _productService.UpdateProductAsync(product);
            return updated == null ? StatusCode(StatusCodes.Status500InternalServerError, $"{aeProductDto.NameEN} could not be updated") : 
                Ok(updated);
          
        }

        [HttpDelete("id")]
        // update product by id
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductAsync(id, true);
            if (product == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Product found for id: {id}");
            }
            (bool status, string message) = await _productService.DeleteProductAsync(product);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, $"Product with id {id} Deleted.");
        }

        [HttpGet("/colors")]
        // getting all colors from db
        public async Task<IActionResult> GetColors()
        {
            var colors = await _productService.GetColorsAsync();

            if (colors == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No colors in database");
            }

            return StatusCode(StatusCodes.Status200OK, _mapper.Map<List<Color>, List<ColorDto>>(colors));
        }

        [HttpGet("/sizes")]
        // getting all sizes from db
        public async Task<IActionResult> GetSizes()
        {
            var sizes = await _productService.GetSizesAsync();

            if (sizes == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No sizes in database");
            }

            return StatusCode(StatusCodes.Status200OK, _mapper.Map<List<Size>, List<SizeDto>>(sizes));
        }
        #endregion
    }
}
