﻿using LawAlert.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Services.User
{
    public interface IUserService
    {
        Infrastructure.Data.Entities.Accounts.User GetUserById(string Id);
        //Task Edit(EditUserFormModel model);
        //public bool EmailExists(string email);
        //bool IdExists(string userId);
        //public bool NameExists(string name);
        AllUsersQueryModel All(string searchTerm = "",
                                      string searchTermOn = "FirstName",
                                          int currentPage = 1,
                                          int usersPerPage = 1);
        Task Forget(string Id);
    }
}
