using LawAlert.Core.Models.Law;
using LawAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Services.Chapter
{
    public class ChapterService : IChapterService
    {
        private readonly LawAlertDbContext dbContext;

        public ChapterService(LawAlertDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public AllChaptersQueryModel All(string SearchText, int CurrentPage, int ChaptersPerPage)
        {
            var chaptersQuery = this.dbContext.Chapters.ToList();

            if (SearchText != null && SearchText != "")
            {
                chaptersQuery = chaptersQuery.Where(lq => lq.Name.ToLower().Contains(SearchText.ToLower())).ToList();
            }

            var chapters = chaptersQuery
                .Select(l => new Models.Chapter.ChapterViewModel
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList();

            chapters = chapters.OrderBy(l => l.Name).ToList();

            var totalChapters = chaptersQuery.Count();

            return new AllChaptersQueryModel()
            {
            };
        }
    }
}
