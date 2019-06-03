using Microsoft.EntityFrameworkCore.Migrations;

namespace FCNuvem.FidelizaAluno.Infraestructure.Migrations
{
    public partial class FixReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alert_Reason_IdReason",
                table: "Alert");

            migrationBuilder.DropForeignKey(
                name: "FK_ReasonEvasion_Reason_IdReason",
                table: "ReasonEvasion");

            migrationBuilder.DropIndex(
                name: "IX_IdReason",
                table: "ReasonEvasion");

            migrationBuilder.DropIndex(
                name: "IX_IdReason",
                table: "Alert");

            migrationBuilder.DropColumn(
                name: "IdReason",
                table: "Alert");

            migrationBuilder.AddColumn<int>(
                name: "ReasonId",
                table: "ReasonEvasion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReasonId",
                table: "ReasonEvasion",
                column: "ReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReasonEvasion_Reason_ReasonId",
                table: "ReasonEvasion",
                column: "ReasonId",
                principalTable: "Reason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReasonEvasion_Reason_ReasonId",
                table: "ReasonEvasion");

            migrationBuilder.DropIndex(
                name: "IX_ReasonId",
                table: "ReasonEvasion");

            migrationBuilder.DropColumn(
                name: "ReasonId",
                table: "ReasonEvasion");

            migrationBuilder.AddColumn<int>(
                name: "IdReason",
                table: "Alert",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IdReason",
                table: "ReasonEvasion",
                column: "IdReason");

            migrationBuilder.CreateIndex(
                name: "IX_IdReason",
                table: "Alert",
                column: "IdReason");

            migrationBuilder.AddForeignKey(
                name: "FK_Alert_Reason_IdReason",
                table: "Alert",
                column: "IdReason",
                principalTable: "Reason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReasonEvasion_Reason_IdReason",
                table: "ReasonEvasion",
                column: "IdReason",
                principalTable: "Reason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
