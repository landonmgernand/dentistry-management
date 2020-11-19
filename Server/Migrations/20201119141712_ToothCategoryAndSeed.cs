using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class ToothCategoryAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a6fd261-7cab-41e4-b193-777ab04d8824");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f92a2f76-3475-4d6d-9d83-d8053eb0bcf9");

            migrationBuilder.AddColumn<int>(
                name: "ToothCategoryId",
                table: "Teeth",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ToothCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToothCategory", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "f67d19fc-f7bc-4e58-bc6a-7a4a0b417953");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "eff68c02-c366-498d-8ecc-0be09041c07c", "8f9ece7a-80f2-4f60-b974-f38db2b944df", "ApplicationRole", "Manager", "Manager" },
                    { "1652571a-2872-4467-aa32-2e2a2f85cb7f", "1616af75-4954-46e7-b2c8-5c225e9d7e29", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86142ba8-b887-48b2-87ad-5294a6f44cea", "AQAAAAEAACcQAAAAEPnyuUugW4kgJXP04wQkC+a8JOlJv3e/R9ISrSoABPyowAMiJB0JcplQeuOb069oGw==", "5c741a57-87aa-4171-a797-d86931a0475a" });

            migrationBuilder.InsertData(
                table: "ToothCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "UpperRight" },
                    { 2, "UpperLeft" },
                    { 3, "LowerRight" },
                    { 4, "LowerLeft" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teeth_ToothCategoryId",
                table: "Teeth",
                column: "ToothCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teeth_ToothCategory_ToothCategoryId",
                table: "Teeth",
                column: "ToothCategoryId",
                principalTable: "ToothCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teeth_ToothCategory_ToothCategoryId",
                table: "Teeth");

            migrationBuilder.DropTable(
                name: "ToothCategory");

            migrationBuilder.DropIndex(
                name: "IX_Teeth_ToothCategoryId",
                table: "Teeth");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1652571a-2872-4467-aa32-2e2a2f85cb7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff68c02-c366-498d-8ecc-0be09041c07c");

            migrationBuilder.DropColumn(
                name: "ToothCategoryId",
                table: "Teeth");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "580bc178-bc4a-475f-b921-86ef508eaee1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f92a2f76-3475-4d6d-9d83-d8053eb0bcf9", "536bfde3-1749-423b-b6be-585c1be1c411", "ApplicationRole", "Manager", "Manager" },
                    { "1a6fd261-7cab-41e4-b193-777ab04d8824", "34ca124b-6990-4308-b05c-8dd3cb41771e", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5c2c3e9-52be-45c3-8869-c181e4920206", "AQAAAAEAACcQAAAAEAUfV7G8BwikkEdPZ6E5FpgZxpRh1tiSKwoqKXEPzKM7PMDykmposRiCUJGHzAvUCQ==", "7fac3c22-f62f-4067-bc95-691641486888" });
        }
    }
}
