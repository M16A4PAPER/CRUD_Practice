using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.Models.Responses;
using CRUD_Practice.Services.Services;
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

        protected async Task<IActionResult> GetTempString()
        {
            string stringFromService = await _employeesService.GetTempString();

            var response = ApiResponse<string>.SuccessResponse(stringFromService, "String retrieval successful");

            return Ok(response);
        }
    }
}