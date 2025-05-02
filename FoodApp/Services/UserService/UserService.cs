using FoodApp.DTOS;
using FoodApp.Repositories.UserRepository;

namespace FoodApp.Services.UserService
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<registerResponseDto> Register(RegisterDto registerDto)
        {
            return await _userRepository.Register(registerDto);
        }
        public async Task<LogInResponseDto> Login(LogInDto loginDto)
        {
            return await _userRepository.Login(loginDto);
        }

        public Task<List<UserDto>> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}
