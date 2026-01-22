using CRUD_Practice.Models.Interfaces.DBFactory;
using CRUD_Practice.Models.Interfaces.Repositories;
using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.Models.Models;
using System.Data;

namespace CRUD_Practice.Services.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IDatabaseFactory _databaseFactory;

        public EmployeesService(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public async Task<int> AddEmployeeAsync(string name, int departmentId, decimal salary, DateTime joiningDate)
        {
            using IDbConnection connection = _databaseFactory.CreateConnection();
            IEmployeesRepository employeesRepository = _databaseFactory.CreateEmployeesRepository(connection);

            return await employeesRepository.AddEmployeeAsync(name, departmentId, salary, joiningDate);
        }

        public async Task<int> DeleteEmployeeAsync(int employeeId)
        {
            using IDbConnection connection = _databaseFactory.CreateConnection();
            IEmployeesRepository employeesRepository = _databaseFactory.CreateEmployeesRepository(connection);

            return await employeesRepository.DeleteEmployeeAsync(employeeId);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            using IDbConnection connection = _databaseFactory.CreateConnection();
            IEmployeesRepository employeesRepository = _databaseFactory.CreateEmployeesRepository(connection);

            return await employeesRepository.GetAllEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            using IDbConnection connection = _databaseFactory.CreateConnection();
            IEmployeesRepository employeesRepository = _databaseFactory.CreateEmployeesRepository(connection);

            return await employeesRepository.GetEmployeeByIdAsync(employeeId);
        }

        public async Task<int> UpdateEmployeeAsync(int employeeId, string name, int departmentId, decimal salary, DateTime joiningDate)
        {
            using IDbConnection connection = _databaseFactory.CreateConnection();
            IEmployeesRepository employeesRepository = _databaseFactory.CreateEmployeesRepository(connection);

            return await employeesRepository.UpdateEmployeeAsync(employeeId, name, departmentId, salary, joiningDate);
        }

    }
}
