using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItCompany.Migrations
{
    public partial class Admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e1b78f86-46d2-40db-9731-405c47e8480e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Phone", "RecordDate", "Username" },
                values: new object[] { new Guid("f56cdae7-6658-407e-b7ed-2534c18778f8"), "info@admin.com", "ادمین", "1234", "123456789", new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f56cdae7-6658-407e-b7ed-2534c18778f8"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Phone", "RecordDate", "Username" },
                values: new object[] { new Guid("e1b78f86-46d2-40db-9731-405c47e8480e"), "info@admin.com", "ادمین", "1234", "123456789", new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" });
        }
    }
}
