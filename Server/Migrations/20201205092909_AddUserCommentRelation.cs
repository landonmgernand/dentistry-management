using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class AddUserCommentRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11db4857-f39f-45a0-9423-a523c70ba97b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aedf5402-f8e6-481d-a7c0-3b546e9cbc8d");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Comments",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b9254c5-1a14-43d4-bbd5-761ec24e2ab8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93b4d648-05a6-401e-b488-ddd782344977");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "427d3608-c62e-4152-bf9d-555400b5e647");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11db4857-f39f-45a0-9423-a523c70ba97b", "53770672-8344-4719-870d-f4dfcc667bc6", "ApplicationRole", "Manager", "Manager" },
                    { "aedf5402-f8e6-481d-a7c0-3b546e9cbc8d", "49ec70bb-f622-41d6-9c05-0a3619ece5d9", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5aa5307-2b7f-48b2-b691-10ec96a60bd1", "AQAAAAEAACcQAAAAEJh+6+ZP0P2Y4iVBbER+OTvoPH0oIQ6IeHts5S+V1DqIaqwyNiBh7bkrqTV2xVmgow==", "ac474587-7335-49b6-ace9-78d4ab68e47a" });
        }
    }
}
