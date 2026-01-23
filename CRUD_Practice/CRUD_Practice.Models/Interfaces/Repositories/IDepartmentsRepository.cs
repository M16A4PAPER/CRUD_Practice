using CRUD_Practice.Models.Models;

namespace CRUD_Practice.Models.Interfaces.Repositories
{
    public interface IDepartmentsRepository
    {
        Task<int> AddDepartmentAsync(string name, string? location);
        Task<int> DeleteDepartmentAsync(int departmentId);
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department?> GetDepartmentByIdAsync(int departmentId);
        Task<int> UpdateDepartmentAsync(int departmentId, string name, string? location);
    }
}
