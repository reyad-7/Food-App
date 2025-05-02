using FoodApp.DTOS;

namespace FoodApp.Repositories.RestaurantRepository
{
    public interface IRestaurantRepository
    {
        public Task<List<RestaurantDto>> GetRestaurants();
        public Task<List<AllProductsForEachRestauarntDTO>> listAllProductsForEachRestauarnt();

    }
}
