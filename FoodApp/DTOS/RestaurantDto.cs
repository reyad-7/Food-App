using FoodApp.Models;

namespace FoodApp.DTOS
{
    public class RestaurantDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? type { get; set; }
        public List<string> MenuProductsNames { get; set; } = new List<string>();
    }
}
