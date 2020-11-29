using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class AddAllergyTableAndRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25f06114-e8d5-4987-bd01-91e6884d9924");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c3260f6-b694-4a63-88ca-053e0825994b");

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    MedicalChartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergies_MedicalCharts_MedicalChartId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_MedicalChartId",
                table: "Allergies",
                column: "MedicalChartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54ea0787-7b9b-4756-99ef-c82d5b8c1046");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf334d56-ac36-4aea-949e-520d0192f57b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "9f0f765c-ca5f-4752-8ffb-558542412661");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c3260f6-b694-4a63-88ca-053e0825994b", "f928d335-d008-495f-8ba1-c2b3187de5b1", "ApplicationRole", "Manager", "Manager" },
                    { "25f06114-e8d5-4987-bd01-91e6884d9924", "1eaf73a6-219a-415e-9f72-de64234d20cd", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe04cde3-d19e-48d7-bc61-dbe98edad1ef", "AQAAAAEAACcQAAAAENKYcbrooQ2OJdSgGdwkN+cinz5FQ8r4JXSXaYSuCeDZA7pBI8p5cVFyzy64SKxx+w==", "f8f6f446-e221-4494-9db0-b9dd89554675" });
        }
    }
}
