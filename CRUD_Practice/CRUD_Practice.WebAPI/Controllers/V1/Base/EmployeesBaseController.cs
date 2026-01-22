using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.Models.Models;
using CRUD_Practice.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Practice.WebAPI.Controllers.V1.Base
{
    public class EmployeesBaseController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesBaseController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        protected async Task<IActionResult> AddEmployeeAsync(string name, int departmentId, decimal salary, DateTime joiningDate)
        {
            int newEmployeeId = await _employeesService.AddEmployeeAsync(name, departmentId, salary, joiningDate);
            ApiResponse<int> response = ApiResponse<int>.SuccessResponse(newEmployeeId, "Employee added successfully");
            
            return Ok(response);
        }

        protected async Task<IActionResult> DeleteEmployeeAsync(int employeeId)
        {
            int deletedCount = await _employeesService.DeleteEmployeeAsync(employeeId);
            ApiResponse<int> response = ApiResponse<int>.SuccessResponse(deletedCount, "Employee deleted successfully");
            
            return Ok(response);
        }

        protected async Task<IActionResult> GetAllEmployeesAsync()
        {
            IEnumerable<Employee> employees = await _employeesService.GetAllEmployeesAsync();
            ApiResponse<IEnumerable<Employee>> response = ApiResponse<IEnumerable<Employee>>.SuccessResponse(employees, "Employees retrieved successfully");

            return Ok(response);
        }

        protected async Task<IActionResult> GetEmployeeByIdAsync(int employeeId)
        {
            Employee employee = await _employeesService.GetEmployeeByIdAsync(employeeId);
            ApiResponse<Employee> response = ApiResponse<Employee>.SuccessResponse(employee, "Employee retrieved successfully");

            return Ok(response);
        }

        protected async Task<IActionResult> UpdateEmployeeAsync(int employeeId, string name, int departmentId, decimal salary, DateTime joiningDate)
        {
            int updatedCount = await _employeesService.UpdateEmployeeAsync(employeeId, name, departmentId, salary, joiningDate);
            ApiResponse<int> response = ApiResponse<int>.SuccessResponse(updatedCount, "Employee updated successfully");

            return Ok(response);
        }

    }
}