using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.Models.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRUD_Practice.Services.Auth
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _settings;

        public JwtTokenService(IOptions<JwtSettings> settings)
        {
            _settings = settings.Value;
        }

        public string GenerateToken(int userId, string email)
        {
            if (string.IsNullOrWhiteSpace(_settings.Key))
                throw new InvalidOperationException("JWT Key is missing from configuration.");

            if (string.IsNullOrWhiteSpace(_settings.Issuer))
                throw new InvalidOperationException("JWT Issuer is missing from configuration.");

            var keyBytes = Encoding.UTF8.GetBytes(_settings.Key);
            var key = new SymmetricSecurityKey(keyBytes);

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_settings.ExpiryInMinutes),
                signingCredentials: creds
            );

            Console.WriteLine(_settings.ExpiryInMinutes);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
