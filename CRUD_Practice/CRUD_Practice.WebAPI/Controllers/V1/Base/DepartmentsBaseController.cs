using Microsoft.AspNetCore.Mvc;

namespace CRUD_Practice.WebAPI.Controllers.V1.Base
{
    public class DepartmentsBaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
