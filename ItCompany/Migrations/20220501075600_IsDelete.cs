using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItCompany.Migrations
{
    public partial class IsDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f56cdae7-6658-407e-b7ed-2534c18778f8"));

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Phone", "RecordDate", "Username" },
                values: new object[] { new Guid("e1b78f86-46d2-40db-9731-405c47e8480e"), "info@admin.com", "ادمین", "1234", "123456789", new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e1b78f86-46d2-40db-9731-405c47e8480e"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDelete", "Name", "Password", "Phone", "RecordDate", "Username" },
                values: new object[] { new Guid("f56cdae7-6658-407e-b7ed-2534c18778f8"), "info@admin.com", false, null, "1234", "123456789", new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" });
        }
    }
}
