using System.ComponentModel.DataAnnotations;

namespace FoodApp.DTOS
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "passwords do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? gender { get; set; }
        [Range(1,4, ErrorMessage = "Level must be form 1 to 4.")]
        public short? level { get; set; }
    }
}
