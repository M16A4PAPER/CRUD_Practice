using CRUD_Practice.Models.Models;
using CRUD_Practice.Models.Responses;

namespace CRUD_Practice.WebAPI.Models.V1.Mappers
{
    public class DepartmentResponseMapper
    {
        public static DepartmentResponse MapFromDepartment(Department? department)
        {
            if (department is null)
            {
                return new DepartmentResponse
                {
                    department_id = null,
                    department_name = "No such department found for given id.",
                    department_location = null
                };
            }

            return new DepartmentResponse
            {
                department_id = department.Id,
                department_name = department.Name,
                department_location = department.Location
            };
        }

        public static IEnumerable<DepartmentResponse> MapFromDepartments(IEnumerable<Department> departments)
        {
            return departments.Select(MapFromDepartment);
        }
    }
}
