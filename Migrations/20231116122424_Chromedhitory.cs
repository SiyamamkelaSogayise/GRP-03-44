using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeeksProject02.Migrations
{
    public partial class Chromedhitory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChroMedicalHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    InsurenceProvideNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChroMedicalHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChroMedicalHistory");
        }
    }
}
