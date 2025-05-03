using FoodApp.DTOS;
using FoodApp.Models;

namespace FoodApp.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task <List<string>> GetAllProducts();
        public Task<List<ProductRestaurants>> SearchProduct(string name);
    }
}
