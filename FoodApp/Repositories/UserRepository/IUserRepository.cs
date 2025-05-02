using FoodApp.DTOS;

namespace FoodApp.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public Task<registerResponseDto> Register(RegisterDto registerDto);
        public Task <LogInResponseDto> Login(LogInDto loginDto);
        public Task<List<UserDto>> GetUsers();

    }
}
