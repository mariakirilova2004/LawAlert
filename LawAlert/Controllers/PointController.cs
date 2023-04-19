using LawAlert.Core.Models.Law;
using Microsoft.AspNetCore.Mvc;
using LawAlert.Core.Services.Law;
using LawAlert.Core.Services.Interest;
using LawAlert.Core.Services.Chapter;
using LawAlert.Core.Models.Article;
using LawAlert.Core.Services.Article;
using Microsoft.AspNetCore.Authorization;
using LawAlert.Core.Services.Point;
using LawAlert.Core.Models.Point;

namespace LawAlert.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class PointController : Controller
    {
        private readonly IPointService pointService;
        private readonly ILogger logger;

        public PointController(IPointService _pointService,
                             ILogger logger)
        {
            this.pointService = _pointService;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult All([FromQuery] AllPointsQueryModel query, int id)
        {
            var queryResult = this.pointService.All(
                query.SearchText,
                query.CurrentPage,
                query.PointsPerPage,
                id);

            query.ArticleName = queryResult.ArticleName;
            query.ChapterName = queryResult.ChapterName;
            query.LawName = queryResult.LawName;
            query.TotalPointsCount = queryResult.TotalPointsCount;
            query.Points = queryResult.Points;
            return View(query);
        }
    }
}
