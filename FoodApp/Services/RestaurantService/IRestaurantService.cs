using FoodApp.DTOS;

namespace FoodApp.Services.RestaurantService
{
    public interface IRestaurantService
    {
        public Task<List<RestaurantDto>> GetRestaurants();
        public Task<List<AllProductsForEachRestauarntDTO>> listAllProductsForEachRestauarnt();

    }
}
