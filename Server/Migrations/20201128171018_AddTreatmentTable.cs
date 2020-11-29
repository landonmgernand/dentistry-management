using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class AddTreatmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39589daf-660a-48a3-afc8-404054e304c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4deec7a4-74fa-438d-a7d3-a82b7aea409f");

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "35e2a303-db62-46fe-bf10-e5703adb9725");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6934bcde-bdda-4566-8519-4b3b68624c04", "ccc2af0d-ba5c-4618-95e9-77da276b0fea", "ApplicationRole", "Manager", "Manager" },
                    { "b6881904-5b77-4474-95db-e538d0fa18f8", "f2ad1aac-19ba-40d4-acd6-cb58f3df7575", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba779571-a9b8-44ca-ac7e-1610b6e1f1eb", "AQAAAAEAACcQAAAAEBEUI/lQ7cY87omIcDOG1OZDgY2TvTry8cpbszqT07ZMGb3pe795QQUfoB+tN8rx0A==", "65a2df9e-55a4-4837-aab5-14dbf0663ac3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6934bcde-bdda-4566-8519-4b3b68624c04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6881904-5b77-4474-95db-e538d0fa18f8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "e340e525-6680-40aa-8893-8c4572672bca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4deec7a4-74fa-438d-a7d3-a82b7aea409f", "a336d546-1eba-4536-bd84-883489c6fda9", "ApplicationRole", "Manager", "Manager" },
                    { "39589daf-660a-48a3-afc8-404054e304c7", "ba3768ae-a535-4b23-8f33-9f593e411751", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23fe1fc7-282b-4409-b4c7-07880cc59d0c", "AQAAAAEAACcQAAAAEL81cCOTAmOMCmLQh4ZqJT1qBMX/pCH2+R5DmQI59Fn2+XlgjRsk7acU6juIcY7NRg==", "e305319b-25b2-485b-aa03-b5c8f2f84b95" });
        }
    }
}
