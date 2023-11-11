using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeeksProject02.Migrations
{
    public partial class StockUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DosesPerPresentationBox",
                table: "Stocks",
                newName: "DosesPerBox");

            migrationBuilder.AddColumn<string>(
                name: "Presentation",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Presentation",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "DosesPerBox",
                table: "Stocks",
                newName: "DosesPerPresentationBox");
        }
    }
}
