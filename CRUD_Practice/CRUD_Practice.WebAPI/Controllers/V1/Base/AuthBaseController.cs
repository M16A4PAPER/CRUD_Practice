using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Practice.WebAPI.Controllers.V1.Base
{
    public class AuthBaseController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthBaseController(IAuthService authService)
        {
            _authService = authService;
        }

        protected async Task<IActionResult> LoginAsync(string email, string password)
        {
            LoginResponse token = await _authService.LoginAsync(email, password);
            return Ok(new { Token = token });
        }

    }
}
