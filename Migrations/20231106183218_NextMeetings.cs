using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeeksProject02.Migrations
{
    public partial class NextMeetings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NextMeetings",
                columns: table => new
                {
                    ChronicBookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChronicBookingDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chronicBookingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChronicReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignitureByName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextMeetings", x => x.ChronicBookingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NextMeetings");
        }
    }
}
