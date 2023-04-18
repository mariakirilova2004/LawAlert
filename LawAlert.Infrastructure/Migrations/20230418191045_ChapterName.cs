using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawAlert.Infrastructure.Migrations
{
    public partial class ChapterName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7606def-4276-4e06-b5c2-2810dd0c0bc6");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Chapters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cbe7e253-0330-4d0d-907e-3617ed3314c7", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "e1361889-a4cd-45cf-85ed-18b243e8593e", "admin@mail.com", false, "User", "Userov", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEC1QvCrodxbVkUWqp/axlYkwa2PUR3F93GODSsINFsM+IwKoPrPRtWYWjJQr1dr0yw==", "0888888888", false, "81d5d15e-39ed-4a35-80fe-de99ef30a7eb", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cbe7e253-0330-4d0d-907e-3617ed3314c7");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Chapters");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e7606def-4276-4e06-b5c2-2810dd0c0bc6", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "98c01819-a3f7-4466-8162-29d290ad93dc", "admin@mail.com", false, "User", "Userov", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEGd9B0oXWzEY5lIIHG0wdbNMD7JPm0NaOLlyob54jtPfU7qRzzgA1w7TDsUFnXgf/g==", "0888888888", false, "53074191-b880-48af-ab78-c1e831ee7b22", false, "Admin" });
        }
    }
}
