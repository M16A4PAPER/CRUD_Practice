using CRUD_Practice.Models.Interfaces.DBFactory;
using CRUD_Practice.Models.Interfaces.Repositories;
using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.Models.Models;
using System.Data;

namespace CRUD_Practice.Services.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly IDatabaseFactory _databaseFactory;

        public DepartmentsService(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public async Task<int> AddDepartmentAsync(string name, string? location)
        {
            using IDbConnection connection = _databaseFactory.CreateConnection();
            IDepartmentsRepository departmentsRepository = _databaseFactory.CreateDepartmentsRepository(connection);

            return await departmentsRepository.AddDepartmentAsync(name, location);
        }

        public async Task<int> DeleteDepartmentAsync(int departmentId)
        {
            using IDbConnection connection = _databaseFactory.CreateConnection();
            IDepartmentsRepository departmentsRepository = _databaseFactory.CreateDepartmentsRepository(connection);

            return await departmentsRepository.DeleteDepartmentAsync(departmentId);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            using IDbConnection connection = _databaseFactory.CreateConnection();
            IDepartmentsRepository departmentsRepository = _databaseFactory.CreateDepartmentsRepository(connection);
            
            return await departmentsRepository.GetAllDepartmentsAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int departmentId)
        {
            using IDbConnection connection = _databaseFactory.CreateConnection();
            IDepartmentsRepository departmentsRepository = _databaseFactory.CreateDepartmentsRepository(connection);

            return await departmentsRepository.GetDepartmentByIdAsync(departmentId);
        }

        public async Task<int> UpdateDepartmentAsync(int departmentId, string name, string? location)
        {
            using IDbConnection connection = _databaseFactory.CreateConnection();
            IDepartmentsRepository departmentsRepository = _databaseFactory.CreateDepartmentsRepository(connection);

            return await departmentsRepository.UpdateDepartmentAsync(departmentId, name, location);
        }

    }
}
