using CRUD_Practice.DBMySql.Repositories;
using CRUD_Practice.Models.Interfaces.DBFactory;
using CRUD_Practice.Models.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System.Data;

namespace CRUD_Practice.DBMySql.Main
{
    public class MySqlDatabaseFactory : IDatabaseFactory
    {
        private readonly string _connectionString;
        private readonly string _encryptionKey;
        private readonly ILoggerFactory _loggerFactory;

        public MySqlDatabaseFactory(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            string connectionStringName = "DefaultConnection";
            _connectionString = configuration.GetConnectionString(connectionStringName) ?? throw new InvalidOperationException($"Connection string '{connectionStringName}' not found.");
            _encryptionKey = configuration["EncryptionSettings:DBKey"] ?? throw new InvalidOperationException("Encryption key not found in configuration.");
            _loggerFactory = loggerFactory;
        }

        public IDbConnection CreateConnection()
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        private RepositoryContext CreateContext(IDbConnection connection, IDbTransaction? transaction)
        {
            return new RepositoryContext((MySqlConnection)connection, (MySqlTransaction?)transaction, _encryptionKey);
        }

        public IDepartmentsRepository CreateDepartmentsRepository(IDbConnection connection, IDbTransaction? transaction = null)
        {
            return new DepartmentsRepository(CreateContext(connection, transaction));
        }

        public IEmployeesRepository CreateEmployeesRepository(IDbConnection connection, IDbTransaction? transaction = null)
        {
            return new EmployeesRepository(CreateContext(connection, transaction));
        }

    }
}
