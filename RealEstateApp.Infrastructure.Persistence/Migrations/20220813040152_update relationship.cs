using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateApp.Infrastructure.Persistence.Migrations
{
    public partial class updaterelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyImprovement");

            migrationBuilder.AddColumn<int>(
                name: "IdProperty",
                table: "Improvements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Improvements_IdProperty",
                table: "Improvements",
                column: "IdProperty");

            migrationBuilder.AddForeignKey(
                name: "FK_Improvements_Properties_IdProperty",
                table: "Improvements",
                column: "IdProperty",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Improvements_Properties_IdProperty",
                table: "Improvements");

            migrationBuilder.DropIndex(
                name: "IX_Improvements_IdProperty",
                table: "Improvements");

            migrationBuilder.DropColumn(
                name: "IdProperty",
                table: "Improvements");

            migrationBuilder.CreateTable(
                name: "PropertyImprovement",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    ImprovementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImprovement", x => new { x.PropertyId, x.ImprovementId });
                    table.ForeignKey(
                        name: "FK_PropertyImprovement_Improvements_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Improvements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyImprovement_Properties_ImprovementId",
                        column: x => x.ImprovementId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImprovement_ImprovementId",
                table: "PropertyImprovement",
                column: "ImprovementId");
        }
    }
}
