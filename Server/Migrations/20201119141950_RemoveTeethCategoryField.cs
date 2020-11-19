using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class RemoveTeethCategoryField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1652571a-2872-4467-aa32-2e2a2f85cb7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eff68c02-c366-498d-8ecc-0be09041c07c");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Teeth");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "c9e5ba9c-ab9a-45be-959c-d2982aa9c28b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9e9198a7-f6b8-4e90-96ed-551ef79c8f87", "d966df19-642a-4d85-816d-7c819cc73246", "ApplicationRole", "Manager", "Manager" },
                    { "633c2f0b-09e8-4286-90ce-47cf1694958a", "67e1a425-d5d9-4f28-a129-7c80285cb152", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6b731bb-535d-44a7-9697-1c8a2c240223", "AQAAAAEAACcQAAAAEONqWz9Az6xtaTN3t8DkPK5h+lIiq2IFSCAHOYdaGv5cvPdj0KeJmFUM70IL7VYVlA==", "34d129ee-1d7e-4a0a-91a3-60cf9847366f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "633c2f0b-09e8-4286-90ce-47cf1694958a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e9198a7-f6b8-4e90-96ed-551ef79c8f87");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Teeth",
                type: "varchar(100) CHARACTER SET utf8mb4",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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
        }
    }
}
