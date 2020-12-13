using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class AddNumberColumnToTeethTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "326109f0-15ed-498f-842f-124cfd26028f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94e91e0c-a411-4b30-9606-1faf878495ad");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Teeth",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "523f5b48-d2e8-443a-a35f-1344ebba082a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b0211b05-6272-49b8-85fe-994cce590f71", "94e0d71a-c40d-4a5d-8cd0-86c9da6a554a", "ApplicationRole", "Manager", "Manager" },
                    { "e7de91d3-6be4-49c0-b94f-5274ae84e715", "7cb1e95b-72f1-476f-bf50-bfa7320215e6", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21678110-fcb7-4792-9157-1b30b706da23", "AQAAAAEAACcQAAAAEJbH7S0Wk31TiVTE6QLV2zFRWDrd9udZWR+z87Vkcmk8gHunENUC2ydJxdy1OKhR0g==", "bfb89618-e953-4eac-bf19-cc5e02099334" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0211b05-6272-49b8-85fe-994cce590f71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7de91d3-6be4-49c0-b94f-5274ae84e715");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Teeth");

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
        }
    }
}
