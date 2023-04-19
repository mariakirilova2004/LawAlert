using LawAlert.Core.Models.Article;
using LawAlert.Core.Models.Law;
using LawAlert.Core.Services.Article;
using LawAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Services.Article
{
    public class ArticleService : IArticleService
    {
        private readonly LawAlertDbContext dbContext;

        public ArticleService(LawAlertDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public AllArticlesQueryModel All(string SearchText, int CurrentPage, int ArticlesPerPage, int id)
        {
            var articleQuery = this.dbContext.Articles.Where(a => a.ChapterId == id).Include(c => c.Chapter).ThenInclude(c => c.Law).ToList();

            if (SearchText != null && SearchText != "")
            {
                articleQuery = articleQuery.Where(aq => aq.Details.ToLower().Contains(SearchText.ToLower())).ToList();
            }

            var ChapterName = articleQuery[0]?.Chapter?.Name;
            var LawName = articleQuery[0]?.Chapter?.Law?.Name;

            var articles = articleQuery
                .Select(a => new Models.Article.ArticleViewModel
                {
                    Id = a.Id,
                    Details = a.Details
                }).ToList();

            articles = articles.OrderBy(a => a.Id).ToList();

            var totalArticles = articleQuery.Count();

            return new AllArticlesQueryModel()
            {
                ArticlesPerPage = ArticlesPerPage,
                TotalArticlesCount = totalArticles,
                Articles = articles,
                LawName = LawName,
                ChapterName = ChapterName
            };
        }
    }
}
