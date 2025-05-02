using FoodApp.DTOS;
using FoodApp.Repositories.RestaurantRepository;

namespace FoodApp.Services.RestaurantService
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            this._restaurantRepository = restaurantRepository;
        }
        public Task<List<RestaurantDto>> GetRestaurants()
        {
            return _restaurantRepository.GetRestaurants();
        }

        public Task<List<AllProductsForEachRestauarntDTO>> listAllProductsForEachRestauarnt()
        {
            return _restaurantRepository.listAllProductsForEachRestauarnt();
        }
    }
}
