using Microsoft.AspNetCore.Mvc;

namespace LawAlert.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
