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

        
    }
}

