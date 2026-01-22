using CRUD_Practice.Models.Models;
using MySqlConnector;

namespace CRUD_Practice.Models.Mappers
{
    public static class DepartmentMapper
    {
        public static Department MapFromReader(MySqlDataReader reader)
        {
            return new Department
            {
                Id = reader.GetInt32(reader.GetOrdinal("id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Location = reader.IsDBNull(reader.GetOrdinal("location"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("location"))
            };
        }
    }
}
