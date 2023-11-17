using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeeksProject02.Migrations
{
    public partial class Chroninxtmeting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChronicNextMeeting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChronicBookingDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chronicBookingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChronicReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignitureByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronicNextMeeting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChronicNextMeeting");
        }
    }
}
