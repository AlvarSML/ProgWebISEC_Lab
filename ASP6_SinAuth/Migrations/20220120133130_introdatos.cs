using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP6_SinAuth.Migrations
{
    public partial class introdatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "961d92d0-d56f-4d5b-8dd5-3bb01dbe301c", "5b68f2b4-61bb-4108-b691-756282d60404" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "657dbee9-3140-4937-b0a3-2c57bbced241", "e60b9d73-1302-4393-b6b0-2beceaa9698a" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e7", 0, "20661c30-2161-495b-b005-de51aa728abd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager@manager.com", false, false, null, "Manager", null, null, null, "1234567890", false, "cdc85cf2-6e40-4778-a297-38e2eda56821", false, "Manager" });

            migrationBuilder.InsertData(
                table: "LaboratoryManagers",
                columns: new[] { "Id", "CompanyAddress", "FirstName", "LastName", "NationalID" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e7", "gg", "Man", "Ager", "1234567890" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LaboratoryManagers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "79a7bd70-5685-45b6-9afa-23e04a0b7378", "295ce240-2cf3-4d99-bcf1-cba151e4520a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "35effced-2ad5-48f4-bb8d-1a1b7135f66e", "29a7497d-5bf9-428e-9e8b-93e7642b7d38" });
        }
    }
}
