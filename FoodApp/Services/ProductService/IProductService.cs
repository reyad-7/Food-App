using FoodApp.DTOS;

namespace FoodApp.Services.ProductService
{
    public interface IProductService
    {

        public Task<List<string>> GetAllProducts();
        public Task<List<ProductRestaurants>> SearchProduct(string name);
    }
}
