using Microsoft.EntityFrameworkCore.Migrations;

namespace FCNuvem.FidelizaAluno.Infraestructure.Migrations
{
    public partial class UpdateStudentEnrolled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentSituation",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CurrentSituation",
                table: "EvasionHistory");

            migrationBuilder.AddColumn<bool>(
                name: "Enrolled",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enrolled",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "CurrentSituation",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentSituation",
                table: "EvasionHistory",
                nullable: true);
        }
    }
}
