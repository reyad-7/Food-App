using FoodApp.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Controllers.ProductController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllProducts();
            if (result == null)
            {
                return NotFound("No products found");
            }
            return Ok(result);
        }
        [HttpGet("SearchProduct/{name}")]
        public async Task<IActionResult> SearchProduct(string name)
        {
            var result = await _productService.SearchProduct(name);
            if (result == null || result.Count == 0)
            {
                return NotFound("No Restuarants found");
            }
            return Ok(result);
        }

    }
}
