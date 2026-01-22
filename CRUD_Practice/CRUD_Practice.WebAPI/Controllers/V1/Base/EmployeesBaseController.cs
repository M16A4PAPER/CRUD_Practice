using Microsoft.AspNetCore.Mvc;

namespace CRUD_Practice.WebAPI.Controllers.V1.Base
{
    public class EmployeesBaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
