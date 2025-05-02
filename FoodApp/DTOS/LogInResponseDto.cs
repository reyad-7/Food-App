using FoodApp.Models;

namespace FoodApp.DTOS
{
    public class LogInResponseDto
    {
        public string Token { get; set; }
        public UserDto user { get; set; }
    }
}