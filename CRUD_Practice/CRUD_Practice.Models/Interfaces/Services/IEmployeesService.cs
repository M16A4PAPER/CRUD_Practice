using CRUD_Practice.Models.Models;

namespace CRUD_Practice.Models.Interfaces.Services
{
    public interface IEmployeesService
    {
        Task<int> AddEmployeeAsync(string name, int departmentId, decimal salary, DateTime joiningDate);
        Task<int> DeleteEmployeeAsync(int employeeId);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task<int> UpdateEmployeeAsync(int employeeId, string name, int departmentId, decimal salary, DateTime joiningDate);
    }
}
