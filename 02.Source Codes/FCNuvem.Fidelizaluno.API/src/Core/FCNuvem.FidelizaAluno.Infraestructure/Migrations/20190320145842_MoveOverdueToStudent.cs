using Microsoft.EntityFrameworkCore.Migrations;

namespace FCNuvem.FidelizaAluno.Infraestructure.Migrations
{
    public partial class MoveOverdueToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Overdue",
                table: "Person");

            migrationBuilder.AddColumn<bool>(
                name: "Overdue",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Overdue",
                table: "Student");

            migrationBuilder.AddColumn<bool>(
                name: "Overdue",
                table: "Person",
                nullable: true);
        }
    }
}
