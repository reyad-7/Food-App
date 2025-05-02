using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace FoodApp.Models
{
    public class FoodAppDbContext : IdentityDbContext<User>
    {
        public FoodAppDbContext(DbContextOptions<FoodAppDbContext> options)
        : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
