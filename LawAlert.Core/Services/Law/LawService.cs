using LawAlert.Core.Models.Law;
using LawAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Services.Law
{
    public class LawService : ILawService
    {
        private readonly LawAlertDbContext dbContext;

        public LawService(LawAlertDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public AllLawsQueryModel All(string SearchText, string Interest, int CurrentPage, int LawsPerPage)
        {
            var lawsQuery = this.dbContext.Laws.Include(l => l.Interest).ToList();

            if (SearchText != null && SearchText != "")
            {
                lawsQuery = lawsQuery.Where(lq => lq.Name.ToLower().Contains(SearchText.ToLower()) || lq.Details.ToLower().Contains(SearchText.ToLower())).ToList();
            }

            if (Interest != null && Interest != "All")
            {
                lawsQuery = lawsQuery.Where(lq => lq.Interest.Type == Interest).ToList();
            }

            var laws = lawsQuery
                .Select(l => new Models.Law.LawViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Details = l.Details
                }).ToList();

            laws = laws.OrderBy(l => l.Id).ToList();

            var totalLaws = lawsQuery.Count();

            return new AllLawsQueryModel()
            {
                LawsPerPage = LawsPerPage,
                TotalLawsCount = totalLaws,
                Laws = laws
            };
        }
    }
}
