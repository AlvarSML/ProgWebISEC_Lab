using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP6_SinAuth.Migrations
{
    public partial class cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Clients_clientId",
                table: "Tests");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_clientId",
                table: "Tests",
                column: "clientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_clientId",
                table: "Tests");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Clients_clientId",
                table: "Tests",
                column: "clientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
