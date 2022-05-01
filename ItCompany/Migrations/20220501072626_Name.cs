using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItCompany.Migrations
{
    public partial class Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11371ac7-ad54-4471-92f3-90dd00cd77fd"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDelete", "Name", "Password", "Phone", "RecordDate", "Username" },
                values: new object[] { new Guid("f56cdae7-6658-407e-b7ed-2534c18778f8"), "info@admin.com", false, null, "1234", "123456789", new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f56cdae7-6658-407e-b7ed-2534c18778f8"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDelete", "Password", "Phone", "RecordDate", "Username" },
                values: new object[] { new Guid("11371ac7-ad54-4471-92f3-90dd00cd77fd"), "info@admin.com", false, "1234", "123456789", new DateTime(2020, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" });
        }
    }
}
