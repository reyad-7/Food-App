using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Firebase.Auth;
using Microsoft.IdentityModel.Tokens;

namespace FoodApp.Repositories.JwtService
{

    public class jwtRepository : IjwtRepository
    {
        private readonly IConfiguration configuration;
        private string securityKey;
        public jwtRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            securityKey = configuration.GetValue<string>("ApiSettings:Secret") ?? throw new InvalidOperationException("ApiSettings:Secret is not configured.");

        }
        string IjwtRepository.CreateToken(Models.User user)
        {

            var Claims = new List<Claim>()
            
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Name),
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
