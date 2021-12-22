using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP6_SinAuth.Migrations
{
    public partial class tipos_usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_clientId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_technicianId",
                table: "Tests");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Clients_clientId",
                table: "Tests",
                column: "clientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Laboratory_workers_technicianId",
                table: "Tests",
                column: "technicianId",
                principalTable: "Laboratory_workers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Clients_clientId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Laboratory_workers_technicianId",
                table: "Tests");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_clientId",
                table: "Tests",
                column: "clientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_technicianId",
                table: "Tests",
                column: "technicianId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
