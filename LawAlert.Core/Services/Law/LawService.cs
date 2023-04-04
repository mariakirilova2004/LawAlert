using LawAlert.Core.Models.Law;
using LawAlert.Infrastructure.Data;
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
            var lawsQuery = this.dbContext.Laws.ToList();

            if (SearchText != null && SearchText != "")
            {
                lawsQuery = lawsQuery.Where(lq => lq.Details.Contains(SearchText)).ToList();
            }

            if (Interest != null && Interest != "All")
            {
                lawsQuery = lawsQuery.Where(lq => lq.Interest.Type.CompareTo(Interest) == 0).ToList();
            }

            var laws = lawsQuery
                .Skip((CurrentPage - 1) * LawsPerPage)
                .Take(LawsPerPage)
                .Select(l => new LawViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Details = l.Details
                }).ToList();

            laws = laws.OrderBy(l => l.Name).ToList();

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
