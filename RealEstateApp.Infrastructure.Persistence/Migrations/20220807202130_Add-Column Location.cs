using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateApp.Infrastructure.Persistence.Migrations
{
    public partial class AddColumnLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Properties");
        }
    }
}
