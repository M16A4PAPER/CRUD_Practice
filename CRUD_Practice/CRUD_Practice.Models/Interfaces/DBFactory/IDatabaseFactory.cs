using CRUD_Practice.Models.Interfaces.Repositories;
using System.Data;

namespace CRUD_Practice.Models.Interfaces.DBFactory
{
    public interface IDatabaseFactory
    {
        IDbConnection CreateConnection();

        IDepartmentsRepository CreateDepartmentsRepository(IDbConnection connection, IDbTransaction? transaction = null);
        IEmployeesRepository CreateEmployeesRepository(IDbConnection connection, IDbTransaction? transaction = null);
    }
}
