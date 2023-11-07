using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeeksProject02.Migrations
{
    public partial class Questionnaire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionnaireResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergicReaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnotherAllergicReaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pregnant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breastfeeding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeakenedImmuneSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousVaccine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CovidSymptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CloseContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherVaccines = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthConditions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireResponses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionnaireResponses");
        }
    }
}
