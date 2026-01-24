using System.ComponentModel.DataAnnotations;

namespace CRUD_Practice.Abstractions.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is required")]
        public string email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; } = string.Empty;
    }
}
