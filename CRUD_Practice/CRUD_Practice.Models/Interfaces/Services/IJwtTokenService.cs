namespace CRUD_Practice.Models.Interfaces.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(int userId, string email);
    }

}
