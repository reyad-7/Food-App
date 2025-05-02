using FoodApp.DTOS;

namespace FoodApp.Services.UserService
{
    public interface IUserService
    {
        public Task<registerResponseDto> Register(RegisterDto registerDto);
        public Task<LogInResponseDto> Login(LogInDto loginDto);
        public Task<List<UserDto>> GetUsers();
    }
}
