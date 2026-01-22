using CRUD_Practice.Abstractions.Requests;
using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.WebAPI.Controllers.V1.Base;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Practice.WebAPI.Controllers.V1.Main
{
    [ApiController]
    [Route("api/v1/employees")] 
    public class EmployeesController(IEmployeesService employeesService) : EmployeesBaseController(employeesService)
    {
        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeRequest request)
        {
            return await base.AddEmployeeAsync(
                request.Name,
                request.DepartmentId,
                request.Salary,
                request.JoiningDate);
        }


        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] int employeeId)
        {
            return await base.DeleteEmployeeAsync(employeeId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            return await base.GetAllEmployeesAsync();
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] int employeeId)
        {
            return await base.GetEmployeeByIdAsync(employeeId);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] int employeeId, [FromBody] EmployeeRequest request)
        {
            return await base.UpdateEmployeeAsync(
                employeeId,
                request.Name,
                request.DepartmentId,
                request.Salary,
                request.JoiningDate
                );
        }

    }
}
