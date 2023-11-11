using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeeksProject02.Migrations
{
    public partial class VaccineOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Stock",
                table: "Lasts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Lasts");
        }
    }
}
