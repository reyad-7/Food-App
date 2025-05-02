using FoodApp.DTOS;
using FoodApp.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _userService.Register(registerDto);
            if (result.ErrorMessages.Any())
            {
                return BadRequest(new { Errors = result.ErrorMessages });
            }
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LogInDto loginDto)
        {
            var result = await _userService.Login(loginDto);
            if (result.Token=="")
            {
                return BadRequest("Login Failed");
            }
            return Ok(result);
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetUsers();
            if (result == null)
            {
                return NotFound("No users found");
            }
            return Ok(result);
        }
    }
}
