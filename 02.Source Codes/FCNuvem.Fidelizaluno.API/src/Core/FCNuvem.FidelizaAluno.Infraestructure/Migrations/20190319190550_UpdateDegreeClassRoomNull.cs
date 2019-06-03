using Microsoft.EntityFrameworkCore.Migrations;

namespace FCNuvem.FidelizaAluno.Infraestructure.Migrations
{
    public partial class UpdateDegreeClassRoomNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degree_ClassRoom_ClassRoomEntityId",
                table: "Degree");

            migrationBuilder.DropColumn(
                name: "IdClass",
                table: "Degree");

            migrationBuilder.RenameColumn(
                name: "ClassRoomEntityId",
                table: "Degree",
                newName: "IdClassRoom");

            migrationBuilder.RenameIndex(
                name: "IX_ClassRoomEntityId",
                table: "Degree",
                newName: "IX_IdClassRoom");

            migrationBuilder.AddForeignKey(
                name: "FK_Degree_ClassRoom_IdClassRoom",
                table: "Degree",
                column: "IdClassRoom",
                principalTable: "ClassRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degree_ClassRoom_IdClassRoom",
                table: "Degree");

            migrationBuilder.RenameColumn(
                name: "IdClassRoom",
                table: "Degree",
                newName: "ClassRoomEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_IdClassRoom",
                table: "Degree",
                newName: "IX_ClassRoomEntityId");

            migrationBuilder.AddColumn<int>(
                name: "IdClass",
                table: "Degree",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Degree_ClassRoom_ClassRoomEntityId",
                table: "Degree",
                column: "ClassRoomEntityId",
                principalTable: "ClassRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
