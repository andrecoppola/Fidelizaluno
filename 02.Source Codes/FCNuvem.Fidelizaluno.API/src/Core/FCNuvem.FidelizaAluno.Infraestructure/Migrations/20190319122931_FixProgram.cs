using Microsoft.EntityFrameworkCore.Migrations;

namespace FCNuvem.FidelizaAluno.Infraestructure.Migrations
{
    public partial class FixProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRoomStudent_Program_ProgramEntityId",
                table: "ClassRoomStudent");

            migrationBuilder.DropIndex(
                name: "IX_ProgramEntityId",
                table: "ClassRoomStudent");

            migrationBuilder.DropColumn(
                name: "ProgramEntityId",
                table: "ClassRoomStudent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgramEntityId",
                table: "ClassRoomStudent",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgramEntityId",
                table: "ClassRoomStudent",
                column: "ProgramEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRoomStudent_Program_ProgramEntityId",
                table: "ClassRoomStudent",
                column: "ProgramEntityId",
                principalTable: "Program",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
