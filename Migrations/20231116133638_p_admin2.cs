using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeeksProject02.Migrations
{
    public partial class p_admin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Ps_AspNetUsers_UserDetailsId",
                table: "Appointments_Ps");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Ps_AspNetUsers_UserStatusId",
                table: "Appointments_Ps");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_Ps_UserDetailsId",
                table: "Appointments_Ps");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_Ps_UserStatusId",
                table: "Appointments_Ps");

            migrationBuilder.DropColumn(
                name: "UserDetailsId",
                table: "Appointments_Ps");

            migrationBuilder.DropColumn(
                name: "UserStatusId",
                table: "Appointments_Ps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserDetailsId",
                table: "Appointments_Ps",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserStatusId",
                table: "Appointments_Ps",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Ps_UserDetailsId",
                table: "Appointments_Ps",
                column: "UserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Ps_UserStatusId",
                table: "Appointments_Ps",
                column: "UserStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Ps_AspNetUsers_UserDetailsId",
                table: "Appointments_Ps",
                column: "UserDetailsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Ps_AspNetUsers_UserStatusId",
                table: "Appointments_Ps",
                column: "UserStatusId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
