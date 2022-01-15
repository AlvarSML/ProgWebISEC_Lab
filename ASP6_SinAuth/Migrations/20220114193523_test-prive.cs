using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP6_SinAuth.Migrations
{
    public partial class testprive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "test_types",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "test_types");
        }
    }
}
