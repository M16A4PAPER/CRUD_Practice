using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.WebAPI.Controllers.V1.Base;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Practice.WebAPI.Controllers.V1.Main
{
    [Route("api/v1/employees")] 
    public class EmployeesController(IEmployeesService employeesService) : EmployeesBaseController(employeesService)
    {
        [HttpGet("_debug/temp-string")]
        public async Task<IActionResult> GetTempString()
        {
            return await base.GetTempString();
        }
    }
}
