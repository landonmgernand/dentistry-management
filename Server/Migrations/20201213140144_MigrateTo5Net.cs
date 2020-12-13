using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class MigrateTo5Net : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0211b05-6272-49b8-85fe-994cce590f71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7de91d3-6be4-49c0-b94f-5274ae84e715");

            migrationBuilder.AddColumn<DateTime>(
                name: "ConsumedTime",
                table: "PersistedGrants",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PersistedGrants",
                type: "varchar(200) CHARACTER SET utf8mb4",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "PersistedGrants",
                type: "varchar(100) CHARACTER SET utf8mb4",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DeviceCodes",
                type: "varchar(200) CHARACTER SET utf8mb4",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "DeviceCodes",
                type: "varchar(100) CHARACTER SET utf8mb4",
                maxLength: 100,
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f4ac592-08bd-49dc-8faa-68eedaecb016");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9a86ac5-acee-4bff-9cab-eeeb583c96cb");

            migrationBuilder.DropColumn(
                name: "ConsumedTime",
                table: "PersistedGrants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PersistedGrants");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "PersistedGrants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DeviceCodes");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "DeviceCodes");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
