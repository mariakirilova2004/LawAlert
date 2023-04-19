using LawAlert.Core.Models.Article;
using LawAlert.Core.Models.Law;
using LawAlert.Core.Models.Point;
using LawAlert.Core.Services.Article;
using LawAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Services.Point
{
    public class PointService : IPointService
    {
        private readonly LawAlertDbContext dbContext;

        public PointService(LawAlertDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public AllPointsQueryModel All(string SearchText, int CurrentPage, int PointsPerPage, int id)
        {
            var pointQuery = this.dbContext.Points.Where(a => a.ArticleId == id).Include(c => c.Article).ThenInclude(c => c.Chapter).ThenInclude(c => c.Law).ToList();

            if (SearchText != null && SearchText != "")
            {
                pointQuery = pointQuery.Where(aq => aq.Description.ToLower().Contains(SearchText.ToLower())).ToList();
            }

            var ArticleName = pointQuery[0]?.Article.Details;
            var ChapterName = pointQuery[0]?.Article.Chapter?.Name;
            var LawName = pointQuery[0]?.Article.Chapter?.Law?.Name;

            var points = pointQuery
                .Skip(CurrentPage - 1)
                .Take(PointsPerPage)
                .Select(a => new Models.Point.PointViewModel
                {
                    Id = a.Id,
                    Description = a.Description
                }).ToList();

            points = points.OrderBy(a => a.Id).ToList();

            var totalPoints = pointQuery.Count();

            return new AllPointsQueryModel()
            {
                PointsPerPage = PointsPerPage,
                TotalPointsCount = totalPoints,
                Points = points,
                ArticleName = ArticleName,
                LawName = LawName,
                ChapterName = ChapterName
            };
        }
    }
}
