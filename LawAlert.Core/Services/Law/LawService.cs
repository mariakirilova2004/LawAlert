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

        public AllLawsQueryModel All(string SearchText, int CurrentPage, int LawsPerPage)
        {

        }
    }
}
