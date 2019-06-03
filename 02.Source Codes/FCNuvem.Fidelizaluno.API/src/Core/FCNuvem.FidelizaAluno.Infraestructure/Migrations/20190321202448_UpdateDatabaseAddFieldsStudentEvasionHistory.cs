using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FCNuvem.FidelizaAluno.Infraestructure.Migrations
{
    public partial class UpdateDatabaseAddFieldsStudentEvasionHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReasonEvasion",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Percentual",
                table: "EvasionHistory");

            migrationBuilder.RenameColumn(
                name: "EvasionChance",
                table: "Student",
                newName: "EvasionScore");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "EvasionHistory",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "CurrentSituation",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountPaymentPendent",
                table: "EvasionHistory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentSituation",
                table: "EvasionHistory",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Distance",
                table: "EvasionHistory",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EvasionScore",
                table: "EvasionHistory",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MediaScore",
                table: "EvasionHistory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SendAt",
                table: "Alert",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentSituation",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AmountPaymentPendent",
                table: "EvasionHistory");

            migrationBuilder.DropColumn(
                name: "CurrentSituation",
                table: "EvasionHistory");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "EvasionHistory");

            migrationBuilder.DropColumn(
                name: "EvasionScore",
                table: "EvasionHistory");

            migrationBuilder.DropColumn(
                name: "MediaScore",
                table: "EvasionHistory");

            migrationBuilder.DropColumn(
                name: "SendAt",
                table: "Alert");

            migrationBuilder.RenameColumn(
                name: "EvasionScore",
                table: "Student",
                newName: "EvasionChance");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "EvasionHistory",
                newName: "Data");

            migrationBuilder.AddColumn<string>(
                name: "ReasonEvasion",
                table: "Student",
                type: "varchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Percentual",
                table: "EvasionHistory",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
