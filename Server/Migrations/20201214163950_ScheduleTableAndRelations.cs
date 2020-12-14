using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class ScheduleTableAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f4ac592-08bd-49dc-8faa-68eedaecb016");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9a86ac5-acee-4bff-9cab-eeeb583c96cb");

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedule_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "7677177c-6aaf-4eb5-9c24-06b5e02774f9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dff13feb-c0cf-4c58-8278-90612d70a79b", "40a72143-3b08-4c39-acaf-03dd51d5fca5", "ApplicationRole", "Manager", "Manager" },
                    { "ea036eb1-16db-4aa1-8924-c318cf3cb22c", "36258e33-c366-40df-9a93-fe12c17375fa", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8ca3d9b-1ac8-4890-a100-25065fd12716", "AQAAAAEAACcQAAAAEOq6oi9tay5xLOz61DXiQ9wFkNhcmOVB4yOserHm68BfQLrtuZWZKFhMYjssBFfHDg==", "0d38537b-21ef-4680-bf83-0f8fee6f138c" });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_PatientId",
                table: "Schedule",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_UserId",
                table: "Schedule",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dff13feb-c0cf-4c58-8278-90612d70a79b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea036eb1-16db-4aa1-8924-c318cf3cb22c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "768e32fc-5f54-4653-b149-2a363b9ee23c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6f4ac592-08bd-49dc-8faa-68eedaecb016", "ba94980f-812f-47e5-ae68-86f09f7e8eb4", "ApplicationRole", "Manager", "Manager" },
                    { "f9a86ac5-acee-4bff-9cab-eeeb583c96cb", "2a8ee5c8-591b-4fbb-9419-23cc2b5d6b87", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2dc44f9e-4ee4-4d6d-9df8-436b766a38fc", "AQAAAAEAACcQAAAAECuf3cQdLFdygN0XTblnTOf0TFjbTt8UiLOLpYf6y/DRZ1FFvQ7KiNvZ3v9x1PekLQ==", "debc597b-e59e-429f-8864-0708d5b28485" });
        }
    }
}
