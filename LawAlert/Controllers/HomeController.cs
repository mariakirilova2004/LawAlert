using LawAlert.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LawAlert.Core.Services.PersonalData;
using LawAlert.Core.Models.PersonalData;

namespace LawAlert.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonalDataService personalData;

        public HomeController(ILogger<HomeController> logger,
                              IPersonalDataService _personalData)
        {
            _logger = logger;
            personalData = _personalData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            var aboutViewModel = new AboutPurposeViewModel() { Purpose = personalData.GetPurpose() };
            return View(aboutViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}