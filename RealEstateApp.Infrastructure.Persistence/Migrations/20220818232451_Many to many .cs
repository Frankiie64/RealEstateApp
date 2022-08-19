using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstateApp.Infrastructure.Persistence.Migrations
{
    public partial class Manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Improvements_Properties_IdProperty",
                table: "Improvements");

            migrationBuilder.DropIndex(
                name: "IX_Improvements_IdProperty",
                table: "Improvements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteProperty",
                table: "FavoriteProperty");

            migrationBuilder.DropColumn(
                name: "IdProperty",
                table: "Improvements");

            migrationBuilder.RenameTable(
                name: "FavoriteProperty",
                newName: "ImpromentsWithProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImpromentsWithProperty",
                table: "ImpromentsWithProperty",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TypeImproments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProperty = table.Column<int>(type: "int", nullable: false),
                    IdImproment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeImproments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeImproments_Improvements_IdImproment",
                        column: x => x.IdImproment,
                        principalTable: "Improvements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeImproments_Properties_IdProperty",
                        column: x => x.IdProperty,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypeImproments_IdImproment",
                table: "TypeImproments",
                column: "IdImproment");

            migrationBuilder.CreateIndex(
                name: "IX_TypeImproments_IdProperty",
                table: "TypeImproments",
                column: "IdProperty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeImproments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImpromentsWithProperty",
                table: "ImpromentsWithProperty");

            migrationBuilder.RenameTable(
                name: "ImpromentsWithProperty",
                newName: "FavoriteProperty");

            migrationBuilder.AddColumn<int>(
                name: "IdProperty",
                table: "Improvements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteProperty",
                table: "FavoriteProperty",
                column: "Id");

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
    }
}
