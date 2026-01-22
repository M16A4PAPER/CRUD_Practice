using CRUD_Practice.Models.Interfaces.DBFactory;
using CRUD_Practice.Models.Interfaces.Repositories;
using CRUD_Practice.Models.Interfaces.Services;
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

        public async Task<string> GetTempString()
        {
            using IDbConnection connection = _databaseFactory.CreateConnection();
            IDepartmentsRepository departmentsRepository = _databaseFactory.CreateDepartmentsRepository(connection);

            return await departmentsRepository.GetTempString();
        }
    }
}
