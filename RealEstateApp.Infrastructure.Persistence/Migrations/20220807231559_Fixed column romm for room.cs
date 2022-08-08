using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateApp.Infrastructure.Persistence.Migrations
{
    public partial class Fixedcolumnrommforroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Romm",
                table: "Properties",
                newName: "Room");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Room",
                table: "Properties",
                newName: "Romm");
        }
    }
}
