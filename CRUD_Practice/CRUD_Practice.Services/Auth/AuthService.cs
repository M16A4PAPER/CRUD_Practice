using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.Models.Responses;
using System.Security.Authentication;

namespace CRUD_Practice.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new AuthenticationException("Email and password are required");

            await Task.Delay(5);

            if (email != "admin@123.com" || password != "password")
                throw new AuthenticationException("Invalid email or password");

            var token = _jwtTokenService.GenerateToken(1, email);

            return new LoginResponse
            {
                AccessToken = token
            };
        }

    }
}
