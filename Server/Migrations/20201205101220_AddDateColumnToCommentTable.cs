using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class AddDateColumnToCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b9254c5-1a14-43d4-bbd5-761ec24e2ab8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93b4d648-05a6-401e-b488-ddd782344977");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5832d829-ce1f-4e7f-b809-10b2c28f9d12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcfa3ac3-310b-4807-bedc-a3db9cbafaa5");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "5e65a3e2-8420-48ad-af60-a91ab5730527");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b9254c5-1a14-43d4-bbd5-761ec24e2ab8", "06a64acb-36b6-4467-9acf-0565c89a9161", "ApplicationRole", "Manager", "Manager" },
                    { "93b4d648-05a6-401e-b488-ddd782344977", "49e4310a-0656-4e2e-8e81-7d7dc04d3bac", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "525f394b-f003-419d-8ae1-ce4a0630d25c", "AQAAAAEAACcQAAAAEAxprzyumLHs8B4l4xCNVFL8W1ps2IzN5nHQHwBtHzWtmbPdHWwBL6FrwEXP2EQWRQ==", "71c31664-c973-4fc9-bfdb-d6601ff96280" });
        }
    }
}
