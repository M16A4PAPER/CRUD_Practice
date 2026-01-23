using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.Models.Models;
using CRUD_Practice.Models.Responses;
using CRUD_Practice.WebAPI.Models.V1.Mappers;
using CRUD_Practice.WebAPI.Models.V1.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Practice.WebAPI.Controllers.V1.Base
{
    public abstract class DepartmentsBaseController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;

        public DepartmentsBaseController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        protected async Task<IActionResult> AddDepartmentAsync(string name, string? location)
        {
            int newDepartmentId = await _departmentsService.AddDepartmentAsync(name, location);
            ApiResponse<int> response = ApiResponse<int>.SuccessResponse(newDepartmentId, "Department added successfully");

            return Ok(response);
        }

        protected async Task<IActionResult> DeleteDepartmentAsync(int departmentId)
        {
            int deletedCount = await _departmentsService.DeleteDepartmentAsync(departmentId);
            ApiResponse<int> response = ApiResponse<int>.SuccessResponse(deletedCount, "Department deleted successfully");

            return Ok(response);
        }

        protected async Task<IActionResult> GetAllDepartmentsAsync()
        {
            IEnumerable<Department> departments = await _departmentsService.GetAllDepartmentsAsync();

            IEnumerable<DepartmentResponse> mappedDepartments = DepartmentResponseMapper.MapFromDepartments(departments);

            ApiResponse<IEnumerable<DepartmentResponse>> response = ApiResponse<IEnumerable<DepartmentResponse>>.SuccessResponse(mappedDepartments, "Departments retrieved successfully");
            return Ok(response);
        }

        protected async Task<IActionResult> GetDepartmentByIdAsync(int departmentId)
        {
            Department? department = await _departmentsService.GetDepartmentByIdAsync(departmentId);

            DepartmentResponse mappedDepartment = DepartmentResponseMapper.MapFromDepartment(department);

            ApiResponse<DepartmentResponse> response = ApiResponse<DepartmentResponse>.SuccessResponse(mappedDepartment, "Department retrieved successfully");
            return Ok(response);
        }

        protected async Task<IActionResult> UpdateDepartmentAsync(int departmentId, string name, string? location)
        {
            int updatedCount = await _departmentsService.UpdateDepartmentAsync(departmentId, name, location);
            ApiResponse<int> response = ApiResponse<int>.SuccessResponse(updatedCount, "Department updated successfully");

            return Ok(response);
        }

    }
}