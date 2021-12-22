using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP6_SinAuth.Migrations
{
    public partial class herencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Laboratory_laboratoryId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_laboratoryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "laboratoryId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Laboratory_workers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    laboratoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratory_workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laboratory_workers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Laboratory_workers_Laboratory_laboratoryId",
                        column: x => x.laboratoryId,
                        principalTable: "Laboratory",
                        principalColumn: "id_laboratory");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Laboratory_workers_laboratoryId",
                table: "Laboratory_workers",
                column: "laboratoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laboratory_workers");

            migrationBuilder.AddColumn<int>(
                name: "laboratoryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_laboratoryId",
                table: "AspNetUsers",
                column: "laboratoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Laboratory_laboratoryId",
                table: "AspNetUsers",
                column: "laboratoryId",
                principalTable: "Laboratory",
                principalColumn: "id_laboratory");
        }
    }
}
