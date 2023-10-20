using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeeksProject02.Migrations
{
    public partial class ChronicMedicalHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChronicMedicalHistory",
                columns: table => new
                {
                    MedicalHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeStyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surgiersUndergone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyMedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousMedication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImmunizationHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hospitalizations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeTelePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkTelePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextOfKinNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsurenceProvideNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronicMedicalHistory", x => x.MedicalHistoryID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChronicMedicalHistory");
        }
    }
}
