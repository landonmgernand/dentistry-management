using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class AffiliatesAndAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83617646-4e9d-47e3-a089-cfe4691b9e71");

            migrationBuilder.AddColumn<int>(
                name: "AffiliateId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Affiliate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 20, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    AffiliateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Affiliate_AffiliateId",
                        column: x => x.AffiliateId,
                        principalTable: "Affiliate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "31d48246-3cc3-4e9a-9ffa-5674d638ddc9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "b12b75c4-2f57-4ee3-95b5-0173cbef7caa", "1b55ae55-5f56-412d-b84e-4b42cef1729f", "ApplicationRole", "User", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0c500b7-31ae-488d-a9bd-f51d36e9327e", "AQAAAAEAACcQAAAAEG1xUe0aGBrPw/OItE2u+2Z9b2NWYhQVVOjzInCN15GweUz4iy7AZXVjyH+5qSYrnw==", "80397e1f-71c3-45c2-a6c3-428f03fa92eb" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AffiliateId",
                table: "AspNetUsers",
                column: "AffiliateId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AffiliateId",
                table: "Address",
                column: "AffiliateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Affiliate_AffiliateId",
                table: "AspNetUsers",
                column: "AffiliateId",
                principalTable: "Affiliate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Affiliate_AffiliateId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Affiliate");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AffiliateId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b12b75c4-2f57-4ee3-95b5-0173cbef7caa");

            migrationBuilder.DropColumn(
                name: "AffiliateId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "e4315321-db50-4cc2-b500-b94d0af455fa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "83617646-4e9d-47e3-a089-cfe4691b9e71", "2e4db6d6-1efb-4224-abf9-4377b7326a71", "ApplicationRole", "User", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26e8501f-9b54-4596-94f1-41fbe02526e9", "AQAAAAEAACcQAAAAEAnSuqtmDRykjJZmfhYhFgQ88AbX1WfFA3h/APmAXdOgsCGFEbJ7UoWxpo88EC0icA==", "f86b1443-a993-4fec-9690-7b13a6cf537f" });
        }
    }
}
