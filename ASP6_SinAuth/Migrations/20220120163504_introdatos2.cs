using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP6_SinAuth.Migrations
{
    public partial class introdatos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laboratory_AspNetUsers_Id",
                table: "Laboratory");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryWorkers_Laboratory_laboratoryId",
                table: "LaboratoryWorkers");

            migrationBuilder.DropForeignKey(
                name: "FK_test_types_Laboratory_laboratoryId",
                table: "test_types");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Laboratory_laboratoryId",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Laboratory",
                table: "Laboratory");

            migrationBuilder.RenameColumn(
                name: "laboratoryId",
                table: "Tests",
                newName: "laboratoryIdLab");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_laboratoryId",
                table: "Tests",
                newName: "IX_Tests_laboratoryIdLab");

            migrationBuilder.RenameColumn(
                name: "laboratoryId",
                table: "test_types",
                newName: "laboratoryIdLab");

            migrationBuilder.RenameIndex(
                name: "IX_test_types_laboratoryId",
                table: "test_types",
                newName: "IX_test_types_laboratoryIdLab");

            migrationBuilder.RenameColumn(
                name: "laboratoryId",
                table: "LaboratoryWorkers",
                newName: "laboratoryIdLab");

            migrationBuilder.RenameIndex(
                name: "IX_LaboratoryWorkers_laboratoryId",
                table: "LaboratoryWorkers",
                newName: "IX_LaboratoryWorkers_laboratoryIdLab");

            migrationBuilder.AlterColumn<string>(
                name: "id_laboratory",
                table: "Laboratory",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Laboratory",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laboratory",
                table: "Laboratory",
                column: "id_laboratory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c773b30b-1159-49a4-892a-1f07533b56b0", "AQAAAAEAACcQAAAAEKN7R8pKVHN/pytGX+I4M2rgypZOG19VtK2zTalVPK3Noq+QjiKxgTBUhSbOlucuBg==", "863ea56b-03f9-44e9-af87-f3d1e36b4599" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d261e35-54c3-44c0-8361-ce5017638c72", "AQAAAAEAACcQAAAAEFlg4C42yxWqDMrgGORFStUZqDhbFXHkQJTS/Rs1KQFI2mxYruMBcb6abL5ts9O/jQ==", "c5397ef7-b997-4bb8-b917-b21bb77cf171" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78c025ba-0ace-47ed-aa47-3e43a47004cd", "88e24f28-5d8a-478c-80e6-8df8411bbe3e" });

            migrationBuilder.CreateIndex(
                name: "IX_Laboratory_Id",
                table: "Laboratory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Laboratory_AspNetUsers_Id",
                table: "Laboratory",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryWorkers_Laboratory_laboratoryIdLab",
                table: "LaboratoryWorkers",
                column: "laboratoryIdLab",
                principalTable: "Laboratory",
                principalColumn: "id_laboratory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_test_types_Laboratory_laboratoryIdLab",
                table: "test_types",
                column: "laboratoryIdLab",
                principalTable: "Laboratory",
                principalColumn: "id_laboratory");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Laboratory_laboratoryIdLab",
                table: "Tests",
                column: "laboratoryIdLab",
                principalTable: "Laboratory",
                principalColumn: "id_laboratory",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laboratory_AspNetUsers_Id",
                table: "Laboratory");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryWorkers_Laboratory_laboratoryIdLab",
                table: "LaboratoryWorkers");

            migrationBuilder.DropForeignKey(
                name: "FK_test_types_Laboratory_laboratoryIdLab",
                table: "test_types");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Laboratory_laboratoryIdLab",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Laboratory",
                table: "Laboratory");

            migrationBuilder.DropIndex(
                name: "IX_Laboratory_Id",
                table: "Laboratory");

            migrationBuilder.RenameColumn(
                name: "laboratoryIdLab",
                table: "Tests",
                newName: "laboratoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Tests_laboratoryIdLab",
                table: "Tests",
                newName: "IX_Tests_laboratoryId");

            migrationBuilder.RenameColumn(
                name: "laboratoryIdLab",
                table: "test_types",
                newName: "laboratoryId");

            migrationBuilder.RenameIndex(
                name: "IX_test_types_laboratoryIdLab",
                table: "test_types",
                newName: "IX_test_types_laboratoryId");

            migrationBuilder.RenameColumn(
                name: "laboratoryIdLab",
                table: "LaboratoryWorkers",
                newName: "laboratoryId");

            migrationBuilder.RenameIndex(
                name: "IX_LaboratoryWorkers_laboratoryIdLab",
                table: "LaboratoryWorkers",
                newName: "IX_LaboratoryWorkers_laboratoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Laboratory",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "id_laboratory",
                table: "Laboratory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laboratory",
                table: "Laboratory",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bfc867ab-9889-4eca-b4a2-5f4d661031d4", "AQAAAAEAACcQAAAAEPjHJ//WMB80teETAec4BPEnhSpLq13PHBrNgeCN3VOeXSU39XNIH5rpRwroaknHUg==", "b1426532-c3a6-45fb-85aa-02764221f03d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dddb78eb-c2ce-4962-9d0f-ead59f9005b4", "AQAAAAEAACcQAAAAEHjbRB0LNZesIjfx583aY8pPk6AmgPB5oX2KaSwZS9klnUSVWv0p5Us1bhHjN6HR8w==", "3ef1a567-7a1e-443d-8523-de80dc8934ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4bc8fbc7-dbe7-4957-936b-7aeee2c4f814", "87f5357d-40e6-458d-93a3-8aa7c5cbefee" });

            migrationBuilder.AddForeignKey(
                name: "FK_Laboratory_AspNetUsers_Id",
                table: "Laboratory",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryWorkers_Laboratory_laboratoryId",
                table: "LaboratoryWorkers",
                column: "laboratoryId",
                principalTable: "Laboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_test_types_Laboratory_laboratoryId",
                table: "test_types",
                column: "laboratoryId",
                principalTable: "Laboratory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Laboratory_laboratoryId",
                table: "Tests",
                column: "laboratoryId",
                principalTable: "Laboratory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
