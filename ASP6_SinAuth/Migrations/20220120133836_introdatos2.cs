using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP6_SinAuth.Migrations
{
    public partial class introdatos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75d597d6-f5f8-413d-8d1f-40ea858ecf77", "AQAAAAEAACcQAAAAEApPnTYKa9UBZWVsV6dnjMQh6np5s0T2duTMKAuCuMKRrgnOvYXsJDvSb0H04NLUdw==", "0502e4e1-904e-4189-9f8d-fc2d5889da49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85b339a3-9b75-4357-bacd-b9936d8fae82", "AQAAAAEAACcQAAAAELKyBjgdhhAu/ZNQb3xnD4mACinuCRj0YrUdp0NpSQN389GZxaLQ+IvoiGPljmyBoQ==", "67870817-1cc8-44fd-9f1b-905804ab6f45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ed576098-b3db-4d1d-8530-38aa53072313", "952ad219-655a-4b05-88ce-24aadd82c1b5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "961d92d0-d56f-4d5b-8dd5-3bb01dbe301c", null, "5b68f2b4-61bb-4108-b691-756282d60404" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "657dbee9-3140-4937-b0a3-2c57bbced241", null, "e60b9d73-1302-4393-b6b0-2beceaa9698a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "20661c30-2161-495b-b005-de51aa728abd", "cdc85cf2-6e40-4778-a297-38e2eda56821" });
        }
    }
}
