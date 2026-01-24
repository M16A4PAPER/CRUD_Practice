using CRUD_Practice.Abstractions.Requests;
using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.WebAPI.Controllers.V1.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Practice.WebAPI.Controllers.V1.Main
{
    [ApiController]
    [Route("api/v1/departments")]
    [Authorize]
    public class DepartmentsController(IDepartmentsService departmentsService) : DepartmentsBaseController(departmentsService)
    {
        [HttpPost]
        public async Task<IActionResult> AddDepartmentAsync([FromBody] DepartmentRequest request)
        {
            return await base.AddDepartmentAsync(
                request.Name,
                request.Location);
        }

        [HttpDelete("{departmentId}")]
        public async Task<IActionResult> DeleteDepartmentAsync([FromRoute] int departmentId)
        {
            return await base.DeleteDepartmentAsync(departmentId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartmentsAsync()
        {
            return await base.GetAllDepartmentsAsync();
        }

        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetDepartmentByIdAsync([FromRoute] int departmentId)
        {
            return await base.GetDepartmentByIdAsync(departmentId);
        }

        [HttpPut("{departmentId}")]
        public async Task<IActionResult> UpdateDepartmentAsync([FromRoute] int departmentId, [FromBody] DepartmentRequest request)
        {
            return await base.UpdateDepartmentAsync(
                departmentId,
                request.Name,
                request.Location
                );
        }

    }
}
