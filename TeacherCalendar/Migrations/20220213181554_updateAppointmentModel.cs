using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeacherCalendar.Migrations
{
    public partial class updateAppointmentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentSurname",
                table: "Appointments",
                newName: "StudentNameSurname");

            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Appointments",
                newName: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentNameSurname",
                table: "Appointments",
                newName: "StudentSurname");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Appointments",
                newName: "StudentName");
        }
    }
}
