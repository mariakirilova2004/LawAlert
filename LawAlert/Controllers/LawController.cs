using LawAlert.Core.Models.Law;
using Microsoft.AspNetCore.Mvc;
using LawAlert.Core.Services.Law;
using LawAlert.Core.Services.Interest;

namespace LawAlert.Controllers
{
    public class LawController : Controller
    {
        private readonly ILawService lawService;
        private readonly IInterestService interestService;
        private readonly ILogger logger;

        public LawController(ILawService _lawService,
                             IInterestService _interestService,
                             ILogger logger)
        {
            this.lawService = _lawService;
            this.interestService = _interestService;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult All([FromQuery] AllLawsQueryModel query)
        {
            var queryResult = this.lawService.All(
                query.SearchText,
                query.Interest,
                query.CurrentPage,
                query.LawsPerPage); 

            query.TotalLawsCount = queryResult.TotalLawsCount;
            query.Laws = queryResult.Laws;
            query.Interests = interestService.GetInterestsViews();
            return View(query);
        }
    }
}
