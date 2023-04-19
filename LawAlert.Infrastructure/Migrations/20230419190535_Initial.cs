using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawAlert.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "648b6ed3-72e0-4d86-aa22-3c482f0b61c4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a6896efc-6e32-4a97-afe6-2af590c7d332", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "57b2d2a5-5614-4ce2-85f3-2b261b773a5c", "admin@mail.com", false, "User", "Userov", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAENj4tCmSzR74iyYknZUrqe9Sl6aEKMtVHJ+JTdfJF35HaFRIlb4g04c71AYLM8+nVg==", "0888888888", false, "359d9fcd-cd5a-4287-871d-2aab1b1f1801", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a6896efc-6e32-4a97-afe6-2af590c7d332");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "648b6ed3-72e0-4d86-aa22-3c482f0b61c4", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cb084804-1a5c-4e5a-93c0-86c61d2c610c", "admin@mail.com", false, "User", "Userov", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEK9cL/ZYTLHHUgl0MFNKvKxpDUbqT4GiNiiUquRbnExg+X+U3AseTMHlnvz57MV2cg==", "0888888888", false, "6a5094d7-7d77-4580-998b-d920ccb617c5", false, "Admin" });
        }
    }
}
