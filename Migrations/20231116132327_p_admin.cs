using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeeksProject02.Migrations
{
    public partial class p_admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments_Ps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserDetailsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserStatusId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments_Ps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointments_Ps_AspNetUsers_UserDetailsId",
                        column: x => x.UserDetailsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Ps_AspNetUsers_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Ps_UserDetailsId",
                table: "Appointments_Ps",
                column: "UserDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Ps_UserStatusId",
                table: "Appointments_Ps",
                column: "UserStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments_Ps");
        }
    }
}
