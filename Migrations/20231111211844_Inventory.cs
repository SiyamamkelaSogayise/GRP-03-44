using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeeksProject02.Migrations
{
    public partial class Inventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DosesPerPresentationBox = table.Column<int>(type: "int", nullable: false),
                    PresentationBoxLotNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PresentationBoxExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoseLotNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoseExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DosesOnHand = table.Column<int>(type: "int", nullable: false),
                    TotalDosesOnHand = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            
        }
    }
}
