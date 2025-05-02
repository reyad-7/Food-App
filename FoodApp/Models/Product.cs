using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        
        public Restaurant restaurant { get; set; }
    }
}
