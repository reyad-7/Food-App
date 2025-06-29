namespace FoodApp.Models
{
    public class Restaurant
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? type { get; set; }
        public List<Product> ? MenuProducts { get; set; } = new List<Product>();
    }
}
