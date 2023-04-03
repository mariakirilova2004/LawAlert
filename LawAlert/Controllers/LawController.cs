using LawAlert.Core.Models.Law;
using Microsoft.AspNetCore.Mvc;
using LawAlert.Core.Services.Law;

namespace LawAlert.Controllers
{
    public class LawController : Controller
    {
        private readonly ILawService lawService;
        private readonly ILogger logger;

        public LawController(ILawService lawService,
                                ILogger logger)
        {
            this.lawService = lawService;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult All([FromQuery] AllLawsQueryModel query)
        {
            var queryResult = this.LawService.All(
                query.SearchText,
                query.CurrentPage,
                query.LawsPerPage);

            query.TotalLawsCount = queryResult.TotalLawsCount;
            query.Laws = queryResult.Laws;

            return View(query);
        }
    }
}
