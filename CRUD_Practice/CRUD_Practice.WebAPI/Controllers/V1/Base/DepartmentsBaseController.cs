using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.Models.Responses;
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

        protected async Task<IActionResult> GetTempString()
        {
            string stringFromService = await _departmentsService.GetTempString();

            var response = ApiResponse<string>.SuccessResponse(stringFromService, "String retrieval successful");

            return Ok(response);
        }

    }
}