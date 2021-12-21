using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP6_SinAuth.Migrations
{
    public partial class modelo_final2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "test_types",
                columns: table => new
                {
                    id_type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_types", x => x.id_type);
                });

            

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    id_test = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creation_date = table.Column<DateTime>(type: "datetime2", rowVersion: true, nullable: false),
                    test_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    result = table.Column<int>(type: "int", nullable: false),
                    clientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    typeId = table.Column<int>(type: "int", nullable: false),
                    technicianId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.id_test);
                    table.ForeignKey(
                        name: "FK_Tests_AspNetUsers_clientId",
                        column: x => x.clientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tests_AspNetUsers_technicianId",
                        column: x => x.technicianId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tests_test_types_typeId",
                        column: x => x.typeId,
                        principalTable: "test_types",
                        principalColumn: "id_type",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_Tests_clientId",
                table: "Tests",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_technicianId",
                table: "Tests",
                column: "technicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_typeId",
                table: "Tests",
                column: "typeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "test_types");

            migrationBuilder.DropTable(
                name: "Laboratory");
        }
    }
}
