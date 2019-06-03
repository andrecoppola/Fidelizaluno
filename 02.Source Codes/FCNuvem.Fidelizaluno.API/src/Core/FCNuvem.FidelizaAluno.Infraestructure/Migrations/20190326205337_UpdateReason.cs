using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FCNuvem.FidelizaAluno.Infraestructure.Migrations
{
    public partial class UpdateReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            if (ActiveProvider == "Microsoft.EntityFrameworkCore.SqlServer")
            {
                // do something SQL Server - specific
            }

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reason",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.InsertData(
                table: "Reason",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Distancia" },
                    { 2, "Financeiro" },
                    { 3, "Desempenho" },
                    { 4, "Comportamento" },
                    { 5, "Aptidão" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reason",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Reason",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
