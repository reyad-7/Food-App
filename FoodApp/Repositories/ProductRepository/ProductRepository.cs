using System.Data.Entity;
using FoodApp.DTOS;
using FoodApp.Models;

namespace FoodApp.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly FoodAppDbContext _foodAppDb;
        
        public ProductRepository(FoodAppDbContext foodAppDb)
        {
            _foodAppDb = foodAppDb;
        }

        public Task<List<ProductRestaurants>> SearchProduct(string name)
        {

            var listToReturn = _foodAppDb.Products
                .Include(p => p.restaurant)
                .Where(p => p.Name.ToLower().Trim() == name.ToLower().Trim())
                .Select(p => new ProductRestaurants
                {
                    Id = p.RestaurantId,
                    Name = p.restaurant.Name,
                    Latitude = p.restaurant.Latitude,
                    Longitude = p.restaurant.Longitude,
                })
                .ToList();

            return Task.FromResult(listToReturn);
        }


        Task<List<string>> IProductRepository.GetAllProducts()
        {
            List<string> productsNames = _foodAppDb.Products.Select(p => p.Name).ToList();
            return Task.FromResult(productsNames);

        }

        
    }
}

