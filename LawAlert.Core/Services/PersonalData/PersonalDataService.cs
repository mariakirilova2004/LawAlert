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

namespace LawAlert.Core.Services.PersonalData
{
    public class PersonalDataService : IPersonalDataService
    {
        private readonly LawAlertDbContext dbContext;

        public PersonalDataService(LawAlertDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public string GetPurpose()
        {
            return dbContext.PersonalData.Where(pd => pd.Type == "Purpose").FirstOrDefault().Description;
        }
    }
}
