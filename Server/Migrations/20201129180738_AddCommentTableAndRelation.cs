using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class AddCommentTableAndRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c96e7111-fe86-419c-aaa7-3546211c8e13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f016dd82-c21a-4b06-b0a2-a5e53e7d030b");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    ToothId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Teeth_ToothId",
                        column: x => x.ToothId,
                        principalTable: "Teeth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ToothId",
                table: "Comments",
                column: "ToothId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11db4857-f39f-45a0-9423-a523c70ba97b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aedf5402-f8e6-481d-a7c0-3b546e9cbc8d");

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
        }
    }
}
