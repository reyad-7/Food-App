using FoodApp.DTOS;
using FoodApp.Repositories.GoogleLogIn_Repository;
using FoodApp.Repositories.JwtService;

namespace FoodApp.Services.GoogleLogInService
{
    public class GoogleLogInService : IGoogleLogInService
    {
        private readonly IjwtRepository _jwtRepository;
        private readonly ILoginwithGoogle _loginwithGoogle;
        public GoogleLogInService(IjwtRepository jwtRepository, ILoginwithGoogle loginwithGoogle)
        {
            _jwtRepository = jwtRepository;
            _loginwithGoogle = loginwithGoogle;
        }


         async Task <LogInResponseDto> IGoogleLogInService.GoogleLogIn(string idToken)
        {
            var user = await _loginwithGoogle.HandleGoogleLoginAsync(idToken);

            if (user == null)
            {
                return new LogInResponseDto
                {
                    Token = "",
                    user = null,
                };
            }
            var returneduser = new UserDto
            {
                Id = user.Id,
                UserEmail = user.Email,
                UserName = user.UserName,
                UserLevel = user.level,
                UserGender = user.gender
            };
            var token = _jwtRepository.CreateToken(user);
            return new LogInResponseDto
            {
                Token = token,
                user = returneduser
            };
        }
    }
}
