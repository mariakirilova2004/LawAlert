using LawAlert.Core.Models.User;
using LawAlert.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
        public AllUsersQueryModel All(string searchTerm = "",
                                      string searchTermOn = "FirstName",
                                          int currentPage = 1,
                                          int usersPerPage = 10)
        {

            var usersQuery = this.dbContext.Users.Include(u => u.Interests).ToList();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                switch (searchTermOn)
                {
                    case "UserName":
                        usersQuery = usersQuery.Where(u => u.UserName.ToLower().Contains(searchTerm.ToLower())).ToList();
                        break;
                    case "FirstName":
                        usersQuery = usersQuery.Where(u => u.FirstName.ToLower().Contains(searchTerm.ToLower())).ToList();
                        break;
                    case "LastName":
                        usersQuery = usersQuery.Where(u => u.LastName.ToLower().Contains(searchTerm.ToLower())).ToList();
                        break;
                    case "Email":
                        usersQuery = usersQuery.Where(u => u.Email.ToLower().Contains(searchTerm.ToLower())).ToList();
                        break;
                }
            }

            var users = usersQuery
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    PhoneNumber = u.PhoneNumber,
                    Email = u.Email,
                    BirthDate = u.BirthDate,
                    Interest = u.Interests?.FirstOrDefault()?.Type
                }).ToList();

            users = users.OrderByDescending(c => c.FirstName).ToList();

            var totalUsers = usersQuery.Count();

            return new AllUsersQueryModel()
            {
                UsersPerPage = usersPerPage,
                TotalUsersCount = totalUsers,
                Users = users
            };
        }

        //public bool EmailExists(string email)
        //{
        //    return this.repository.All<Infrastructure.Data.Entities.Account.User>(u => u.Email == email).ToList().Count > 0;
        //}

        public async Task Forget(string Id)
        {
            try
            {
                Infrastructure.Data.Entities.Accounts.User user = this.dbContext.Users.Where(u => u.Id == Id).FirstOrDefault();

                if (user != null)
                {
                    user.Email = "";
                    this.dbContext.Update(user);
                    await this.dbContext.SaveChangesAsync();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Infrastructure.Data.Entities.Accounts.User GetUserById(string Id)
        {
            return dbContext.Users.FirstOrDefault(u => u.Id == Id);
        }

        //public async Task Edit(EditUserFormModel model)
        //{
        //    var sanitalizer = new HtmlSanitizer();

        //    var user = dbContext.Users.FirstOrDefault(u => u.Id == model.Id);

        //    user.UserName = sanitalizer.Sanitize(model.UserName);
        //    user.FirstName = sanitalizer.Sanitize(model.FirstName);
        //    user.MiddleName = sanitalizer.Sanitize(model.MiddleName);
        //    user.LastName = sanitalizer.Sanitize(model.LastName);
        //    user.EGN = sanitalizer.Sanitize(model.EGN);
        //    user.Email = sanitalizer.Sanitize(model.Email);
        //    user.PhoneNumber = sanitalizer.Sanitize(model.PhoneNumber);
        //    user.HiringDate = model.HiringDate;
        //    user.IsActive = model.IsActive;
        //    user.DismissionDate = model.DismissionDate;

        //    dbContext.Users.Update(user);

        //    try
        //    {
        //        await dbContext.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public bool IdExists(string userId)
        //{
        //    return this.repository.All<Infrastructure.Data.Entities.Account.User>(u => u.Id == userId).ToList().Count > 0;
        //}

        //public bool NameExists(string name)
        //{
        //    return this.repository.All<Infrastructure.Data.Entities.Account.User>(u => u.UserName == name).ToList().Count > 0;
        //}
    }
}
