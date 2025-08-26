using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FoodApp.DTOS;
using FoodApp.Models;
using FoodApp.Repositories.JwtService;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace FoodApp.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodAppDbContext _foodAppDb;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration configuration;
        private string securityKey;
        private readonly IjwtRepository _jwtRepository ;

        public UserRepository(FoodAppDbContext foodAppDb, IConfiguration configuration, UserManager<User> userManager, IjwtRepository jwtRepository)
        {
            _foodAppDb = foodAppDb;
            _userManager = userManager;
            securityKey = configuration.GetValue<string>("ApiSettings:Secret") ?? throw new InvalidOperationException("ApiSettings:Secret is not configured.");
            this._jwtRepository = jwtRepository;
        }

        public Task<List<UserDto>> GetUsers()
        {
            var  users = new List<UserDto>();
            var userList = _userManager.Users.ToList();
            foreach (var user in userList) { 
                var userToAdd = new UserDto();
                userToAdd.UserName = user.UserName;
                userToAdd.UserEmail = user.Email;
                userToAdd.UserLevel = user.level;
                userToAdd.UserGender= user.gender;
                userToAdd.Id = user.Id;
                users.Add(userToAdd);
            }
            return Task.FromResult(users);
        }

        public async Task<LogInResponseDto> Login(LogInDto loginDto)
        {
            var user =_userManager.FindByNameAsync(loginDto.UserName).Result;
            if (user == null || !await _userManager.CheckPasswordAsync(user,loginDto.Password))
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
                UserGender = user.gender,
                UserLevel = user.level,
            };
            
            string token = _jwtRepository.CreateToken(user);

            return new LogInResponseDto
            {
                user = returneduser,
                Token = token
            };
        }

        public async Task<registerResponseDto> Register(RegisterDto registerDto)
        {
            var userToRegister = new User
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                gender = registerDto.gender,
                level = registerDto.level,
                UserName = registerDto.UserName,
            };
            var userResponse = new registerResponseDto();
            var result = await _userManager.CreateAsync(userToRegister, registerDto.Password);
            if (!result.Succeeded)
            {
                userResponse.ErrorMessages.AddRange(result.Errors.Select(e => e.Description));
            }
            return userResponse;
        }
    }
}

