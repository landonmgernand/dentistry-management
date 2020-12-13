using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class AddToothTreatmentHistoryRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5832d829-ce1f-4e7f-b809-10b2c28f9d12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcfa3ac3-310b-4807-bedc-a3db9cbafaa5");

            migrationBuilder.AddColumn<int>(
                name: "ToothId",
                table: "TreatmentHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "7df14db9-b6d1-4d2c-9fdd-9641206c83b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94e91e0c-a411-4b30-9606-1faf878495ad", "083510d5-c4d3-40ae-8521-5260cb6bbe1e", "ApplicationRole", "Manager", "Manager" },
                    { "326109f0-15ed-498f-842f-124cfd26028f", "592f4e41-a7d2-41f2-affc-1b208a35cb00", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8ad2339-6a36-46e7-9f2f-481cb9d78a51", "AQAAAAEAACcQAAAAEMle0sBgHCFOibbMBkl9MiiXeXVKg4RykSpL1e0cVp2KwUsHQBlVLnNj1H9qyYRv9Q==", "3e711072-0cfc-4d20-bfa6-a21decf76c4d" });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistories_ToothId",
                table: "TreatmentHistories",
                column: "ToothId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatmentHistories_Teeth_ToothId",
                table: "TreatmentHistories",
                column: "ToothId",
                principalTable: "Teeth",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatmentHistories_Teeth_ToothId",
                table: "TreatmentHistories");

            migrationBuilder.DropIndex(
                name: "IX_TreatmentHistories_ToothId",
                table: "TreatmentHistories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "326109f0-15ed-498f-842f-124cfd26028f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94e91e0c-a411-4b30-9606-1faf878495ad");

            migrationBuilder.DropColumn(
                name: "ToothId",
                table: "TreatmentHistories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "7c2f1ff1-c1b0-4504-98a2-ac3be0d2023c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fcfa3ac3-310b-4807-bedc-a3db9cbafaa5", "bda7477a-7e1c-4d98-afac-91c1a90f6783", "ApplicationRole", "Manager", "Manager" },
                    { "5832d829-ce1f-4e7f-b809-10b2c28f9d12", "31f062cc-c731-4461-84f7-0e6395331fdc", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0df53bcf-e14f-4f19-a553-22bfb377f0ae", "AQAAAAEAACcQAAAAEPwuAlTUWflOOkzE/d2LegV28llq1LvUnEHp9fs0Dl7xSIsrmomds6/yRzneMjLjUw==", "03730781-9836-4f5e-b3f4-b7318fb08ed9" });
        }
    }
}
