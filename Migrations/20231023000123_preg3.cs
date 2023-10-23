using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeeksProject02.Migrations
{
    public partial class preg3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ChronicBooking");

            migrationBuilder.DropColumn(
                name: "delivery_date",
                table: "Pregnancy_Tracker");

            migrationBuilder.RenameColumn(
                name: "current_day",
                table: "Pregnancy_Tracker",
                newName: "patient_ID");
        }

        //    migrationBuilder.AlterColumn<string>(
        //        name: "LastName",
        //        table: "AspNetUsers",
        //        type: "nvarchar(100)",
        //        nullable: true,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(100)");

        //    migrationBuilder.AlterColumn<string>(
        //        name: "FirstName",
        //        table: "AspNetUsers",
        //        type: "nvarchar(100)",
        //        nullable: true,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(100)");

        //    migrationBuilder.CreateTable(
        //        name: "AddBookings",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            IsMedicalAidMember = table.Column<bool>(type: "bit", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AddBookings", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "PatientBookings",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            City = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            PreferredContactMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
        //            IsMedicalAidMember = table.Column<bool>(type: "bit", nullable: false),
        //            MedicalAidNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            MedicalAidName = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_PatientBookings", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AvailableDay",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            AddBookingId = table.Column<int>(type: "int", nullable: true),
        //            PatientBookingId = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AvailableDay", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_AvailableDay_AddBookings_AddBookingId",
        //                column: x => x.AddBookingId,
        //                principalTable: "AddBookings",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_AvailableDay_PatientBookings_PatientBookingId",
        //                column: x => x.PatientBookingId,
        //                principalTable: "PatientBookings",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "PreferredAppointmentTime",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            AddBookingId = table.Column<int>(type: "int", nullable: true),
        //            PatientBookingId = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_PreferredAppointmentTime", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_PreferredAppointmentTime_AddBookings_AddBookingId",
        //                column: x => x.AddBookingId,
        //                principalTable: "AddBookings",
        //                principalColumn: "Id");
        //            table.ForeignKey(
        //                name: "FK_PreferredAppointmentTime_PatientBookings_PatientBookingId",
        //                column: x => x.PatientBookingId,
        //                principalTable: "PatientBookings",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AvailableDay_AddBookingId",
        //        table: "AvailableDay",
        //        column: "AddBookingId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AvailableDay_PatientBookingId",
        //        table: "AvailableDay",
        //        column: "PatientBookingId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_PreferredAppointmentTime_AddBookingId",
        //        table: "PreferredAppointmentTime",
        //        column: "AddBookingId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_PreferredAppointmentTime_PatientBookingId",
        //        table: "PreferredAppointmentTime",
        //        column: "PatientBookingId");
        //}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableDay");

            migrationBuilder.DropTable(
                name: "PreferredAppointmentTime");

            migrationBuilder.DropTable(
                name: "AddBookings");

            migrationBuilder.DropTable(
                name: "PatientBookings");

            migrationBuilder.RenameColumn(
                name: "patient_ID",
                table: "Pregnancy_Tracker",
                newName: "current_day");

            migrationBuilder.AddColumn<DateTime>(
                name: "delivery_date",
                table: "Pregnancy_Tracker",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ChronicBooking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredGenderConsultant = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronicBooking", x => x.BookingID);
                });
        }
    }
}
