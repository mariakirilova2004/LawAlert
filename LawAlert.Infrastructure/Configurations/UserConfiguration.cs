using LawAlert.Infrastructure.Data.Entities.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Infrastructure.Configurations
{
        public class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasData(CreateUser());
            }

            private User CreateUser()
            {
                var hasher = new PasswordHasher<User>();

                var user = new User()
                {
                    FirstName = "User",
                    LastName = "Userov",
                    Email = "admin@mail.com",
                    NormalizedEmail = "ADMIN@MAIL.COM",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    PhoneNumber = "0888888888",
                    Interests = null
                };

                user.PasswordHash = hasher.HashPassword(user, "user123");
                return user;
            }
        }
}
