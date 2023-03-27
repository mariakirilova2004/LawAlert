using LawAlert.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Services.User
{
    public class UserService : IUserService
    {
        private readonly LawAlertDbContext dbContext;

        public UserService(LawAlertDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
    }
}
