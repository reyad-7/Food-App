using FoodApp.DTOS;

namespace FoodApp.Services.GoogleLogInService
{
    public interface IGoogleLogInService
    {
        public Task<LogInResponseDto> GoogleLogIn(string idToken);
    }
}
