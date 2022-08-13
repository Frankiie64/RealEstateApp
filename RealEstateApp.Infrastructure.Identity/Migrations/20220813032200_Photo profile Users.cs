using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateApp.Infrastructure.Identity.Migrations
{
    public partial class PhotoprofileUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoProfileUrl",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoProfileUrl",
                schema: "Identity",
                table: "Users");
        }
    }
}
