using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawAlert.Infrastructure.Migrations
{
    public partial class PersonalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a6896efc-6e32-4a97-afe6-2af590c7d332");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9e4cf816-f041-4ab4-ac3b-5df636a9c984", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c6581b71-e401-49f2-88b4-2870df6d7933", "admin@mail.com", false, "User", "Userov", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEFp9nKpcnLfq8UVw+5S6b5LzRG+J9eEjv65f14jEb6LPyNvbhfsfUPJ3ExObaEONSw==", "0888888888", false, "93baa22a-e5d5-43e1-8720-13e518cd6c2a", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e4cf816-f041-4ab4-ac3b-5df636a9c984");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a6896efc-6e32-4a97-afe6-2af590c7d332", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "57b2d2a5-5614-4ce2-85f3-2b261b773a5c", "admin@mail.com", false, "User", "Userov", false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAENj4tCmSzR74iyYknZUrqe9Sl6aEKMtVHJ+JTdfJF35HaFRIlb4g04c71AYLM8+nVg==", "0888888888", false, "359d9fcd-cd5a-4287-871d-2aab1b1f1801", false, "Admin" });
        }
    }
}
