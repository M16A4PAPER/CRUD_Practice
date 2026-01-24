using CRUD_Practice.Models.Models;
using CRUD_Practice.Models.Responses;

namespace CRUD_Practice.WebAPI.Models.V1.Mappers
{
    public static class EmployeeResponseMapper
    {
        public static EmployeeResponse MapFromEmployee(Employee? employee)
        {
            if (employee is null)
            {
                return new EmployeeResponse
                {
                    employee_id = null,
                    employee_name = "No such employee found with given id.",
                    department_id = null,
                    department_name = null,
                    employee_salary = null,
                    join_date = null
                };
            }

            return new EmployeeResponse
            {
                employee_id = employee.Id,
                employee_name = employee.Name,
                department_id = employee.DepartmentId,
                department_name = employee.DepartmentName,
                employee_salary = employee.Salary,
                join_date = employee.JoiningDate
            };
        }

        public static IEnumerable<EmployeeResponse> MapFromEmployees(IEnumerable<Employee> employees)
        {
            return employees.Select(MapFromEmployee);
        }

    }
}
