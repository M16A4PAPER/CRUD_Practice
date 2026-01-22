using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.WebAPI.Controllers.V1.Base; 
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Practice.WebAPI.Controllers.V1.Main
{
    [Route("api/v1/departments")]
    public class DepartmentsController(IDepartmentsService departmentsService) : DepartmentsBaseController(departmentsService)
    {
        [HttpGet("_debug/temp-string")]
        public new async Task<IActionResult> GetTempString()
        {
            return await base.GetTempString();
        }
    }
}
