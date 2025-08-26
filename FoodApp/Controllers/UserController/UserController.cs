using Azure.Core;
using FoodApp.DTOS;
using FoodApp.Services.GoogleLogInService;
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
        private readonly IGoogleLogInService _googleLogInService ;

        public UserController(IUserService userService,IGoogleLogInService googleLogInService)
        {
            this._userService = userService;
            this._googleLogInService = googleLogInService;
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
        //[HttpGet("GetUsers")]
        //public async Task<IActionResult> GetUsers()
        //{
        //    var result = await _userService.GetUsers();
        //    if (result == null)
        //    {
        //        return NotFound("No users found");
        //    }
        //    return Ok(result);
        //}

        [HttpPost("logInWithGoogle")]
        public async Task<IActionResult> LogInWithGoogle([FromBody] string idToken)
        {
            if (string.IsNullOrEmpty(idToken))
                return BadRequest("Google ID token is required");

            try
            {
                var result = await _googleLogInService.GoogleLogIn(idToken);

                if (result == null || string.IsNullOrEmpty(result.Token))
                    return Unauthorized("Invalid Google token or login failed");
                    
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing Google login");
            }
        }
    }
}
