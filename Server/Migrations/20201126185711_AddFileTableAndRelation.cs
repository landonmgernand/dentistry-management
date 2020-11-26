using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class AddFileTableAndRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54ea0787-7b9b-4756-99ef-c82d5b8c1046");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf334d56-ac36-4aea-949e-520d0192f57b");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Filename = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    Filesize = table.Column<int>(nullable: false),
                    MedicalChartId = table.Column<int>(nullable: false),
                    UploadDT = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_MedicalCharts_MedicalChartId",
                        column: x => x.MedicalChartId,
                        principalTable: "MedicalCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Files_MedicalChartId",
                table: "Files",
                column: "MedicalChartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39589daf-660a-48a3-afc8-404054e304c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4deec7a4-74fa-438d-a7d3-a82b7aea409f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "8a17713e-edd5-4d06-8ffa-fc9ce0013bf8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cf334d56-ac36-4aea-949e-520d0192f57b", "c1785672-f7cb-44d9-9f77-43d2742a80da", "ApplicationRole", "Manager", "Manager" },
                    { "54ea0787-7b9b-4756-99ef-c82d5b8c1046", "644acb25-e24b-4c12-bf05-6236822c8972", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c7ac2d5-d088-4bbc-9876-6368c8212533", "AQAAAAEAACcQAAAAEFb69u7K18TQenziqpoMLEE4bkXYlamxU+qCapasSPJzciwo12Mp9+sXOBscC3VeIw==", "d68279bc-e6a2-41f5-babe-450375a8715d" });
        }
    }
}
