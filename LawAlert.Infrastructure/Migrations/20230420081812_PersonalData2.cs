using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawAlert.Infrastructure.Migrations
{
    public partial class PersonalData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e4cf816-f041-4ab4-ac3b-5df636a9c984");

            migrationBuilder.CreateTable(
                name: "PersonalData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalData", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b495f801-7e09-4265-9c14-08016600d8ce", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "766abc67-80f1-4f75-bdb6-47f30a98a00a", "admin@mail.com", false, "User", "Userov", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEJmFay6io2ttwtlL3WBotpwCYxeC5GQ1ESovwmOKj3Yeem8r3+SwdA5xjLi6GL0BtQ==", "0888888888", false, "b2477a97-d675-4cc3-96d6-d6a6360683a9", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalData");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b495f801-7e09-4265-9c14-08016600d8ce");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9e4cf816-f041-4ab4-ac3b-5df636a9c984", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c6581b71-e401-49f2-88b4-2870df6d7933", "admin@mail.com", false, "User", "Userov", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEFp9nKpcnLfq8UVw+5S6b5LzRG+J9eEjv65f14jEb6LPyNvbhfsfUPJ3ExObaEONSw==", "0888888888", false, "93baa22a-e5d5-43e1-8720-13e518cd6c2a", false, "Admin" });
        }
    }
}
