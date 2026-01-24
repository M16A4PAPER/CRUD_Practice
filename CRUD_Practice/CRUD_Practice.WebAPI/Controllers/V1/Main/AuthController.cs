using CRUD_Practice.Abstractions.Requests;
using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.WebAPI.Controllers.V1.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Practice.WebAPI.Controllers.V1.Main
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController(IAuthService authService) : AuthBaseController(authService)
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm]LoginRequest request)
        {
            return await base.LoginAsync(request.email, request.password);
        }
    }
}
