using FoodApp.Models;

namespace FoodApp.DTOS
{
    public class AllProductsForEachRestauarntDTO
    {
        public string RestaurantName { get; set; }
        public string? type { get; set; }
        public List<ProductDto> products { get; set; } = new List<ProductDto>();
    }
}
