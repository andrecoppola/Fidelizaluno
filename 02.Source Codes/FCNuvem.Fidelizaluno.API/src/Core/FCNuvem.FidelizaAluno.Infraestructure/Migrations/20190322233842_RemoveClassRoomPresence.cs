using Microsoft.EntityFrameworkCore.Migrations;

namespace FCNuvem.FidelizaAluno.Infraestructure.Migrations
{
    public partial class RemoveClassRoomPresence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presence_ClassRoom_IdClassRoom",
                table: "Presence");

            migrationBuilder.DropIndex(
                name: "IX_IdClassRoom",
                table: "Presence");

            migrationBuilder.DropColumn(
                name: "IdClassRoom",
                table: "Presence");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdClassRoom",
                table: "Presence",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdClassRoom",
                table: "Presence",
                column: "IdClassRoom");

            migrationBuilder.AddForeignKey(
                name: "FK_Presence_ClassRoom_IdClassRoom",
                table: "Presence",
                column: "IdClassRoom",
                principalTable: "ClassRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
