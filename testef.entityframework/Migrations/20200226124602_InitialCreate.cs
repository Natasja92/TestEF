using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testef.entityframework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    EducationId = table.Column<Guid>(nullable: false),
                    EducationalInstitute = table.Column<string>(nullable: true),
                    Course = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.EducationId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CitizenServiceNumber = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    BusinessPhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "PersonEducation",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(nullable: false),
                    EducationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEducation", x => new { x.PersonId, x.EducationId });
                    table.ForeignKey(
                        name: "FK_PersonEducation_Education_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Education",
                        principalColumn: "EducationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonEducation_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Education",
                columns: new[] { "EducationId", "Category", "Course", "EducationalInstitute", "EndDate", "Level", "StartDate" },
                values: new object[,]
                {
                    { new Guid("99a19480-d320-49fa-8206-64d69d728466"), "IT", "Software Engineering", "Fontys Venlo University of Applied Sciences", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HBO", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("434cc863-fa52-4ecd-ba38-e9cab5bd76fe"), "IT", "Business Informatics", "Fontys Venlo University of Applied Sciences", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HBO", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a7333772-0b12-4218-b23d-1172b4fe5658"), "IT", "Software Engineering", "Zuyd Hogeschool University of Applied Sciences", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HBO", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5e091e1-c9e6-41fb-a942-f6ada86cddc2"), "IT", "Software Engineering", "Fontys Eindhoven University of Applied Sciences", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HBO", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "BusinessPhoneNumber", "CitizenServiceNumber", "City", "Email", "Name", "PostalCode" },
                values: new object[,]
                {
                    { new Guid("4bce93a4-35ac-42a3-842f-c45ca5f2ed60"), "0612345678", 111222333, "Maastricht", "HStals@ilionx.com", "Harry Stals", "6371XX" },
                    { new Guid("067efba1-bdbd-4dfa-b944-7b9519e2531f"), "0612345678", 111222333, "Maastricht", "LCurvers@ilionx.com", "Linda Curvers", "6371XX" },
                    { new Guid("1d40496a-2a34-47b3-8509-9e25dff830dc"), "0612345678", 111222333, "Maastricht", "DVanHorst@ilionx.com", "Denny van Horst", "6371XX" },
                    { new Guid("fb0c7c49-cb8a-4743-adbd-473943e8e098"), "0612345678", 111222333, "Maastricht", "KHansen@ilionx.com", "Kyra Hansen", "6371XX" },
                    { new Guid("3c8e38a0-b7a3-4db1-a0d9-be37800f7df9"), "0612345678", 111222333, "Maastricht", "GJansen@ilionx.com", "Guus Jansen", "6371XX" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducation_EducationId",
                table: "PersonEducation",
                column: "EducationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonEducation");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
