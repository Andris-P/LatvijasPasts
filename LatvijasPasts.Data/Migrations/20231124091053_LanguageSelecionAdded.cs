using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LatvijasPasts.Data.Migrations
{
    public partial class LanguageSelecionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "CurriculumVitae",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "CurriculumVitae",
                newName: "FirstName");

            migrationBuilder.CreateTable(
                name: "LanguageKnowledges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LanguageLevel = table.Column<int>(type: "int", nullable: false),
                    CurriculumVitaeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageKnowledges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageKnowledges_CurriculumVitae_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "CurriculumVitae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageKnowledges_CurriculumVitaeId",
                table: "LanguageKnowledges",
                column: "CurriculumVitaeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageKnowledges");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "CurriculumVitae",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "CurriculumVitae",
                newName: "Firstname");
        }
    }
}
