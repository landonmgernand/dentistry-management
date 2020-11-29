using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class AddTreatmentHistoryTableAndRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6934bcde-bdda-4566-8519-4b3b68624c04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6881904-5b77-4474-95db-e538d0fa18f8");

            migrationBuilder.CreateTable(
                name: "TreatmentHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    DateOfTreatment = table.Column<DateTime>(nullable: false),
                    MedicalChartId = table.Column<int>(nullable: false),
                    TreatmentId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    AffiliateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatmentHistories_Affiliates_AffiliateId",
                        column: x => x.AffiliateId,
                        principalTable: "Affiliates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentHistories_MedicalCharts_MedicalChartId",
                        column: x => x.MedicalChartId,
                        principalTable: "MedicalCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentHistories_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "dbda4b70-554d-460a-8702-46be59dd579b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f016dd82-c21a-4b06-b0a2-a5e53e7d030b", "b13dab17-5ec2-4eb2-af02-f80e4bddafdd", "ApplicationRole", "Manager", "Manager" },
                    { "c96e7111-fe86-419c-aaa7-3546211c8e13", "bb6b286f-ca53-47b2-b838-22b788b8cc35", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ecc78dd-7dbd-4c20-ae56-36d07583207a", "AQAAAAEAACcQAAAAEM79P1ScPESGXxwZdNOeKahvipP5VK6BaubvVnZHKBoAWQDFkAwQSd25eg4F2guvrQ==", "028d8f0b-c7c9-4948-b1e1-ca55306c32b9" });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistories_AffiliateId",
                table: "TreatmentHistories",
                column: "AffiliateId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistories_MedicalChartId",
                table: "TreatmentHistories",
                column: "MedicalChartId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistories_TreatmentId",
                table: "TreatmentHistories",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentHistories_UserId",
                table: "TreatmentHistories",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreatmentHistories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c96e7111-fe86-419c-aaa7-3546211c8e13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f016dd82-c21a-4b06-b0a2-a5e53e7d030b");

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
    }
}
