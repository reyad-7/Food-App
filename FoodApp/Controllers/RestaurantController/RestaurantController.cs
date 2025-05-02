using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodApp.Services.RestaurantService;


namespace FoodApp.Controllers.RestaurantController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            this._restaurantService = restaurantService;
        }
        [HttpGet("GetRestaurants")]
        public async Task<IActionResult> GetRestaurants()
        {
            var result = await _restaurantService.GetRestaurants();
            if (result == null)
            {
                return NotFound("No restaurants found");
            }
            return Ok(result);
        }
        [HttpGet("ListAllProductsForEachRestauarnt")]
        public async Task<IActionResult> ListAllProductsForEachRestauarnt()
        {
            var result = await _restaurantService.listAllProductsForEachRestauarnt();
            if (result == null)
            {
                return NotFound("No products found");
            }
            return Ok(result);
        }
    }
}
