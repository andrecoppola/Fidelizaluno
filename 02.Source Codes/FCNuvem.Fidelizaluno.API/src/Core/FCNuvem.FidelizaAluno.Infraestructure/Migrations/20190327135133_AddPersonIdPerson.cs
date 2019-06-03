using Microsoft.EntityFrameworkCore.Migrations;

namespace FCNuvem.FidelizaAluno.Infraestructure.Migrations
{
    public partial class AddPersonIdPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonId",
                table: "Person",
                type: "varchar(MAX)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Person");
        }
    }
}
