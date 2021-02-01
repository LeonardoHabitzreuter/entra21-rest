using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class UserSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Profile" },
                values: new object[] { new Guid("6d05094e-885b-4615-8059-22ddaabd6475"), "sysadmin@company.com", "Sys Admin", "202CB962AC59075B964B07152D234B70", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6d05094e-885b-4615-8059-22ddaabd6475"));
        }
    }
}
