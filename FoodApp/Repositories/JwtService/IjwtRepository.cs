using Firebase.Auth;

namespace FoodApp.Repositories.JwtService
{
    public interface IjwtRepository
    {

        public string CreateToken(Models.User user);
    }
}
