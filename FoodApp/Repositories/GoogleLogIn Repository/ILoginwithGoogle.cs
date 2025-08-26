using FoodApp.Models;

namespace FoodApp.Repositories.GoogleLogIn_Repository
{
    public interface ILoginwithGoogle
    {
        public Task<User> HandleGoogleLoginAsync(string idToken);
    }
}
