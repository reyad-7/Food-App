using Microsoft.AspNetCore.Identity;


namespace FoodApp.Models
{
    public class User:IdentityUser
    {
        public string Name { get; set; }
        public string ?gender { get; set; }
        public short? level { get; set; }
    }
}