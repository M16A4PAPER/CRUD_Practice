using CRUD_Practice.Models.Interfaces.DBFactory;
using CRUD_Practice.Models.Interfaces.Repositories;
using CRUD_Practice.Models.Interfaces.Services;
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

        public async Task<string> GetTempString()
        {
            using IDbConnection connection = _databaseFactory.CreateConnection();
            IEmployeesRepository employeesRepository = _databaseFactory.CreateEmployeesRepository(connection);

            return await employeesRepository.GetTempString();
        }
    }
}
