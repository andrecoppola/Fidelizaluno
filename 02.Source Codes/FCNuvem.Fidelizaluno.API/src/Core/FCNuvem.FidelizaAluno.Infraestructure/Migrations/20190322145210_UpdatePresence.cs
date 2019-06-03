using Microsoft.EntityFrameworkCore.Migrations;

namespace FCNuvem.FidelizaAluno.Infraestructure.Migrations
{
    public partial class UpdatePresence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presence_Degree_IdDegree",
                table: "Presence");

            migrationBuilder.DropIndex(
                name: "IX_IdDegree",
                table: "Presence");

            migrationBuilder.DropColumn(
                name: "IdDegree",
                table: "Presence");

            migrationBuilder.AlterColumn<int>(
                name: "IdClass",
                table: "Presence",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "IdCampus",
                table: "ClassRoom",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdClass",
                table: "Presence",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_IdCampus",
                table: "ClassRoom",
                column: "IdCampus");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRoom_Campus_IdCampus",
                table: "ClassRoom",
                column: "IdCampus",
                principalTable: "Campus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Presence_Class_IdClass",
                table: "Presence",
                column: "IdClass",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRoom_Campus_IdCampus",
                table: "ClassRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_Presence_Class_IdClass",
                table: "Presence");

            migrationBuilder.DropIndex(
                name: "IX_IdClass",
                table: "Presence");

            migrationBuilder.DropIndex(
                name: "IX_IdCampus",
                table: "ClassRoom");

            migrationBuilder.DropColumn(
                name: "IdCampus",
                table: "ClassRoom");

            migrationBuilder.AlterColumn<int>(
                name: "IdClass",
                table: "Presence",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDegree",
                table: "Presence",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IdDegree",
                table: "Presence",
                column: "IdDegree");

            migrationBuilder.AddForeignKey(
                name: "FK_Presence_Degree_IdDegree",
                table: "Presence",
                column: "IdDegree",
                principalTable: "Degree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
