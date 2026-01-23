using CRUD_Practice.DBMySql.Constants;
using CRUD_Practice.DBMySql.Main;
using CRUD_Practice.Models.Interfaces.Repositories;
using CRUD_Practice.Models.Mappers;
using CRUD_Practice.Models.Models;
using MySqlConnector;
using System.Data;

namespace CRUD_Practice.DBMySql.Repositories
{
    public class DepartmentsRepository(RepositoryContext context) : BaseRepository(context), IDepartmentsRepository
    {
        public async Task<int> AddDepartmentAsync(string name, string? location)
        {
            using MySqlCommand cmd = new MySqlCommand(StoredProcedures.AddDepartment, _connection, _transaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            // IN parameters
            cmd.Parameters.AddWithValue("@p_name", name);
            cmd.Parameters.AddWithValue("@p_location",
                location ?? (object)DBNull.Value);

            // OUT parameter
            MySqlParameter departmentIdParam = new MySqlParameter("@p_department_id", MySqlDbType.Int32)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(departmentIdParam);

            await cmd.ExecuteNonQueryAsync();

            return Convert.ToInt32(departmentIdParam.Value);
        }

        public async Task<int> DeleteDepartmentAsync(int departmentId)
        {
            using MySqlCommand cmd = new MySqlCommand(StoredProcedures.DeleteDepartment, _connection, _transaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            // IN parameter
            cmd.Parameters.AddWithValue("@p_id", departmentId);

            // OUT parameter
            MySqlParameter deletedCountParam = new MySqlParameter("@p_deleted_count", MySqlDbType.Int32)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(deletedCountParam);

            await cmd.ExecuteNonQueryAsync();

            return Convert.ToInt32(deletedCountParam.Value);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            using MySqlCommand cmd = new MySqlCommand(StoredProcedures.GetAllDepartments, _connection, _transaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            List<Department> departments = new List<Department>();

            using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                departments.Add(DepartmentMapper.MapFromReader(reader));
            }

            return departments;
        }

        public async Task<Department?> GetDepartmentByIdAsync(int departmentId)
        {
            using MySqlCommand cmd = new MySqlCommand(StoredProcedures.GetDepartmentById, _connection, _transaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@p_id", departmentId);

            using MySqlDataReader reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return DepartmentMapper.MapFromReader(reader);
            }

            return null;
        }

        public async Task<int> UpdateDepartmentAsync(int departmentId, string name, string? location)
        {
            using MySqlCommand cmd = new MySqlCommand(StoredProcedures.UpdateDepartment, _connection, _transaction)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@p_id", departmentId);
            cmd.Parameters.AddWithValue("@p_name", name);
            cmd.Parameters.AddWithValue("@p_location",
                location ?? (object)DBNull.Value);

            int affectedRows = await cmd.ExecuteNonQueryAsync();

            return affectedRows;
        }

    }
}
