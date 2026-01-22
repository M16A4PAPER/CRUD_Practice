using CRUD_Practice.Models.Models;
using MySqlConnector;

namespace CRUD_Practice.Models.Mappers
{
    public static class EmployeeMapper
    {
        public static Employee MapFromReader(MySqlDataReader reader)
        {
            return new Employee
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                DepartmentId = reader.IsDBNull(reader.GetOrdinal("id")) ? null : reader.GetInt32(reader.GetOrdinal("id")),
                DepartmentName = reader.IsDBNull(reader.GetOrdinal("department_name")) ? null : reader.GetString(reader.GetOrdinal("department_name")),
                Salary = reader.GetDecimal(reader.GetOrdinal("salary")),
                JoiningDate = reader.GetDateTime(reader.GetOrdinal("joining_date"))
            };
        }
    }
}
