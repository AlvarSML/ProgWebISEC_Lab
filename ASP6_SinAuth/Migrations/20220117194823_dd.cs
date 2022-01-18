using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP6_SinAuth.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_clientId",
                table: "Tests");

            migrationBuilder.AlterColumn<string>(
                name: "clientId",
                table: "Tests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_clientId",
                table: "Tests",
                column: "clientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_clientId",
                table: "Tests");

            migrationBuilder.AlterColumn<string>(
                name: "clientId",
                table: "Tests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_clientId",
                table: "Tests",
                column: "clientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
