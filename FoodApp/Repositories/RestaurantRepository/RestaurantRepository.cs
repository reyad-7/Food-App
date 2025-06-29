using System.Data.Entity;
using FoodApp.DTOS;
using FoodApp.Models;
using FoodApp.Repositories.RestaurantRepository;

namespace FoodApp.Repositories.RestaurantRepository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly FoodAppDbContext _foodAppDb;
        private string securityKey;

        public RestaurantRepository(FoodAppDbContext foodAppDb)
        {
            _foodAppDb = foodAppDb;
        }

        public async Task<List<RestaurantDto>> GetRestaurants()
        {
            var restaurants = _foodAppDb.Restaurants.ToList();
            var listToReturn = new List<RestaurantDto>();
            foreach (var restaurant in restaurants)
            {
                var restaurantDto = new RestaurantDto();

                restaurantDto.Name = restaurant.Name;
                restaurantDto.Address = restaurant.Address;
                restaurantDto.Latitude = restaurant.Latitude;
                restaurantDto.Longitude = restaurant.Longitude;
                restaurantDto.type = restaurant.type;
                restaurantDto.MenuProductsNames = _foodAppDb.Products
                .Where(p => p.RestaurantId == restaurant.Id)
                .Select(p => p.Name)
                .ToList();

                listToReturn.Add(restaurantDto);
            }
            return (listToReturn);
        }

        Task<List<AllProductsForEachRestauarntDTO>> IRestaurantRepository.listAllProductsForEachRestauarnt()
        {
            var restaurants = _foodAppDb.Restaurants.ToList();
            var listToReturn = new List<AllProductsForEachRestauarntDTO>();
            foreach (var restaurant in restaurants)
            {
                var restaurantDto = new AllProductsForEachRestauarntDTO
                {
                    RestaurantName = restaurant.Name,
                    type = restaurant.type,
                    products = _foodAppDb.Products
                     .Where(p => p.RestaurantId == restaurant.Id).ToList()
                     .Select(p => new ProductDto
                     {
                         Name = p.Name,
                         Price = p.Price,
                     }).ToList()
                };
                listToReturn.Add(restaurantDto);
            }
            return Task.FromResult(listToReturn);

        }
    }

}