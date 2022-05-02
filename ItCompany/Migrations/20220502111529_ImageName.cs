using Microsoft.EntityFrameworkCore.Migrations;

namespace ItCompany.Migrations
{
    public partial class ImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Employees",
                newName: "ImageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Employees",
                newName: "Image");
        }
    }
}
