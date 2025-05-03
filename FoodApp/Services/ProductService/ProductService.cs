using FoodApp.DTOS;
using FoodApp.Repositories.ProductRepository;

namespace FoodApp.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<List<string>> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Task<List<ProductRestaurants>> SearchProduct(string name)
        {
            return _productRepository.SearchProduct(name);
        }
    }
}
