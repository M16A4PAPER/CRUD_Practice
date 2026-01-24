using CRUD_Practice.Models.Responses;

namespace CRUD_Practice.Models.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(string email, string password);
    }

}
