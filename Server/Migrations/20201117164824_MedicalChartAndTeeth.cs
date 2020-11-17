using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentistryManagement.Server.Migrations
{
    public partial class MedicalChartAndTeeth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06723487-d9d9-43fe-b0a7-e3d703335859");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0911e63-219e-4591-a2a1-2121d6896109");

            migrationBuilder.CreateTable(
                name: "MedicalChart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalChart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalChart_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teeth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(maxLength: 150, nullable: false),
                    Category = table.Column<string>(maxLength: 100, nullable: false),
                    MedicalChartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teeth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teeth_MedicalChart_MedicalChartId",
                        column: x => x.MedicalChartId,
                        principalTable: "MedicalChart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_MedicalChart_PatientId",
                table: "MedicalChart",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teeth_MedicalChartId",
                table: "Teeth",
                column: "MedicalChartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teeth");

            migrationBuilder.DropTable(
                name: "MedicalChart");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a6fd261-7cab-41e4-b193-777ab04d8824");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f92a2f76-3475-4d6d-9d83-d8053eb0bcf9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "0c885991-5eba-40de-aef7-667b8af255b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06723487-d9d9-43fe-b0a7-e3d703335859", "8fad9ec2-abd4-45f0-8f44-5e65ad436e3d", "ApplicationRole", "Manager", "Manager" },
                    { "f0911e63-219e-4591-a2a1-2121d6896109", "4df3dfe5-c50b-448d-8ad8-eb8760b59e3b", "ApplicationRole", "Dentist", "Dentist" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6013cb00-3064-408d-8e2b-2cdf39134806", "AQAAAAEAACcQAAAAEBmiU622Ibbp0Q8LQBebe06UD/gpp4LGhIOOcrGsC4ejK/wlomCZ+o3UKydrpVbWfg==", "1c398534-a968-45fe-be94-0f4181ea5565" });
        }
    }
}
