using CRUD_Practice.DBMySql.Constants;
using CRUD_Practice.DBMySql.Main;
using CRUD_Practice.Models.Interfaces.Repositories;
using CRUD_Practice.Models.Mappers;
using CRUD_Practice.Models.Models;
using MySqlConnector;
using System.Data;

namespace CRUD_Practice.DBMySql.Repositories
{
    public class EmployeesRepository(RepositoryContext context) : BaseRepository(context), IEmployeesRepository
    {
        public async Task<int> AddEmployeeAsync(string name, int departmentId, decimal salary, DateTime joiningDate)
        {
            using MySqlCommand cmd = new MySqlCommand(StoredProcedures.AddEmployee, _connection, _transaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            // IN parameters
            cmd.Parameters.AddWithValue("@p_name", name);
            cmd.Parameters.AddWithValue("@p_department_id", departmentId);
            cmd.Parameters.AddWithValue("@p_salary", salary);
            cmd.Parameters.AddWithValue("@p_joining_date", joiningDate);

            // OUT parameter
            MySqlParameter employeeIdParam = new MySqlParameter("@p_employee_id", MySqlDbType.Int32)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(employeeIdParam);

            await cmd.ExecuteNonQueryAsync();

            return Convert.ToInt32(employeeIdParam.Value);
        }

        public async Task<int> DeleteEmployeeAsync(int employeeId)
        {
            using MySqlCommand cmd = new MySqlCommand(StoredProcedures.DeleteEmployee, _connection, _transaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            // IN parameter
            cmd.Parameters.AddWithValue("@p_id", employeeId);

            // OUT parameter
            MySqlParameter deletedCountParam = new MySqlParameter("@p_deleted_count", MySqlDbType.Int32)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(deletedCountParam);

            await cmd.ExecuteNonQueryAsync();

            return Convert.ToInt32(deletedCountParam.Value);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            using MySqlCommand cmd = new MySqlCommand(StoredProcedures.GetAllEmployees, _connection, _transaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            List<Employee> employees = new List<Employee>();

            using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                employees.Add(EmployeeMapper.MapFromReader(reader));
            }

            return employees;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
        {
            using MySqlCommand cmd = new MySqlCommand(StoredProcedures.GetEmployeeById, _connection, _transaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@p_id", employeeId);

            using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return EmployeeMapper.MapFromReader(reader);
            }

            return null;
        }

        public async Task<int> UpdateEmployeeAsync(int employeeId, string name, int departmentId, decimal salary, DateTime joiningDate)
        {
            using MySqlCommand cmd = new MySqlCommand(StoredProcedures.UpdateEmployee, _connection, _transaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@p_id", employeeId);
            cmd.Parameters.AddWithValue("@p_name", name);
            cmd.Parameters.AddWithValue("@p_department_id", departmentId);
            cmd.Parameters.AddWithValue("@p_salary", salary);
            cmd.Parameters.AddWithValue("@p_joining_date", joiningDate);

            int affectedRows = await cmd.ExecuteNonQueryAsync();

            return affectedRows;
        }

        public Task<string> GetTempString()
        {
            return Task.FromResult("This is a temporary string from EmployeesRepository.");
        }

    }
}
