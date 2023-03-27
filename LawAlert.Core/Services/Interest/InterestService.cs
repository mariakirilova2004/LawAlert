using LawAlert.Core.Models.Interest;
using LawAlert.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Services.Interest
{
    public class InterestService : IInterestService
    {
        private readonly LawAlertDbContext dbContext;
        public InterestService(LawAlertDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public List<InterestViewModel> GetInterestViewModels()
        {
            return this.dbContext.Interests.Select(i => new InterestViewModel()
            {
                Id = i.Id,
                Type = i.Type
            })
            .ToList();
        }
    }
}
