using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP6_SinAuth.Migrations
{
    public partial class lab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "laboratoryId",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_laboratoryId",
                table: "Tests",
                column: "laboratoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Laboratory_laboratoryId",
                table: "Tests",
                column: "laboratoryId",
                principalTable: "Laboratory",
                principalColumn: "id_laboratory",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Laboratory_laboratoryId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_laboratoryId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "laboratoryId",
                table: "Tests");
        }
    }
}
