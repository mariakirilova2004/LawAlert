using LawAlert.Core.Models.Law;
using Microsoft.AspNetCore.Mvc;
using LawAlert.Core.Services.Law;
using LawAlert.Core.Services.Interest;
using LawAlert.Core.Services.Chapter;
using LawAlert.Core.Models.Article;
using LawAlert.Core.Services.Article;
using Microsoft.AspNetCore.Authorization;

namespace LawAlert.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ILogger logger;

        public ArticleController(IArticleService _articleService,
                             ILogger logger)
        {
            this.articleService = _articleService;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult All([FromQuery] AllArticlesQueryModel query, int id)
        {
            var queryResult = this.articleService.All(
                query.SearchText,
                query.CurrentPage,
                query.ArticlesPerPage,
                id);

            query.ChapterName = queryResult.ChapterName;
            query.LawName = queryResult.LawName;
            query.TotalArticlesCount = queryResult.TotalArticlesCount;
            query.Articles = queryResult.Articles;
            return View(query);
        }
    }
}
