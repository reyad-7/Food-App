using FirebaseAdmin.Auth;
using FoodApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace FoodApp.Repositories.GoogleLogIn_Repository
{
    public class LoginwithGoogle : ILoginwithGoogle
    {
        private readonly FoodAppDbContext _foodAppDb;
        private readonly UserManager<User> _userManager; 
        private readonly ILogger<LoginwithGoogle> _logger;

        public LoginwithGoogle(
            FoodAppDbContext foodAppDb,
            UserManager<User> userManager, 
            ILogger<LoginwithGoogle> logger)
        {
            _foodAppDb = foodAppDb;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<User> HandleGoogleLoginAsync(string idToken)
        {
            try
            {
                // Verify the Firebase token
                var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);

                // Extract user information from token
                var email = decodedToken.Claims.GetValueOrDefault("email")?.ToString();
                var name = decodedToken.Claims.GetValueOrDefault("name")?.ToString();

                if (string.IsNullOrEmpty(email))
                {
                    throw new ArgumentException("Email not found in Firebase token");
                }

                var existingUser = await _userManager.FindByEmailAsync(email);

                if (existingUser != null)
                {
                    existingUser.Name = name ?? existingUser.Name;
                    await _userManager.UpdateAsync(existingUser);
                    return existingUser;
                }
                // if user not found, create new user
                var newUser = new User
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    Name = name ?? "Google User",
                    level = 1 
                };

                var createResult = await _userManager.CreateAsync(newUser);


                if (!createResult.Succeeded)
                {
                    var errors = string.Join(", ", createResult.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to create user: {errors}");
                }

                return newUser;
            }
            catch (FirebaseAuthException ex)
            {
                _logger.LogError(ex, "Firebase authentication failed");
                throw new UnauthorizedAccessException("Invalid Firebase token");
            }
        }

    }
}