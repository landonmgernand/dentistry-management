using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class AddDiseaseTableAndRelationshipWithTooth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1158e2c5-9800-4634-b1c6-f2ab8fe73139");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "301c660b-5adc-45d6-b817-6b739258bb1b");

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToothDiseases",
                columns: table => new
                {
                    DiseaseId = table.Column<int>(nullable: false),
                    ToothId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToothDiseases", x => new { x.DiseaseId, x.ToothId });
                    table.ForeignKey(
                        name: "FK_ToothDiseases_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToothDiseases_Teeth_ToothId",
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

            migrationBuilder.CreateIndex(
                name: "IX_ToothDiseases_ToothId",
                table: "ToothDiseases",
                column: "ToothId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToothDiseases");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25f06114-e8d5-4987-bd01-91e6884d9924");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c3260f6-b694-4a63-88ca-053e0825994b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "5ce7d067-62a2-4fdc-ac55-6b777855cfbc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "301c660b-5adc-45d6-b817-6b739258bb1b", "dd6547b6-9f5a-4777-a92e-5aa2e2592378", "ApplicationRole", "Manager", "Manager" },
                    { "1158e2c5-9800-4634-b1c6-f2ab8fe73139", "cbf7e8ef-9b85-4922-978c-ff52c78c117a", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7481e0fd-716b-4e3c-a60a-3877fcec1e9d", "AQAAAAEAACcQAAAAEFEDAoe6rJMK4cUkFQMDNPrqYf+ETyWf+QSI9im1bgH736JKIzuLUckBgOR+lTJWhw==", "5a30b192-7037-4aef-8efa-e8b31561c287" });
        }
    }
}
