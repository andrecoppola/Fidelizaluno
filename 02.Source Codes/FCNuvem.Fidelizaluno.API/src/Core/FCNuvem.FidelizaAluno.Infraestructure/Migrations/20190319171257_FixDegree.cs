using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FCNuvem.FidelizaAluno.Infraestructure.Migrations
{
    public partial class FixDegree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Degree_GradeId",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Degree_ClassRoom_IdClassRoom",
                table: "Degree");

            migrationBuilder.DropIndex(
                name: "IX_GradeId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Class");

            migrationBuilder.RenameColumn(
                name: "IdClassRoom",
                table: "Degree",
                newName: "ClassRoomEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_IdClassRoom",
                table: "Degree",
                newName: "IX_ClassRoomEntityId");

            migrationBuilder.RenameColumn(
                name: "IdGrade",
                table: "Class",
                newName: "IdDegree");

            migrationBuilder.CreateTable(
                name: "DegreeCourse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdDegree = table.Column<int>(nullable: false),
                    DegreeId = table.Column<int>(nullable: true),
                    IdCourse = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DegreeCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DegreeCourse_Degree_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdDegree",
                table: "Class",
                column: "IdDegree");

            migrationBuilder.CreateIndex(
                name: "IX_CourseId",
                table: "DegreeCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeId",
                table: "DegreeCourse",
                column: "DegreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Degree_IdDegree",
                table: "Class",
                column: "IdDegree",
                principalTable: "Degree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Degree_ClassRoom_ClassRoomEntityId",
                table: "Degree",
                column: "ClassRoomEntityId",
                principalTable: "ClassRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Degree_IdDegree",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Degree_ClassRoom_ClassRoomEntityId",
                table: "Degree");

            migrationBuilder.DropTable(
                name: "DegreeCourse");

            migrationBuilder.DropIndex(
                name: "IX_IdDegree",
                table: "Class");

            migrationBuilder.RenameColumn(
                name: "ClassRoomEntityId",
                table: "Degree",
                newName: "IdClassRoom");

            migrationBuilder.RenameIndex(
                name: "IX_ClassRoomEntityId",
                table: "Degree",
                newName: "IX_IdClassRoom");

            migrationBuilder.RenameColumn(
                name: "IdDegree",
                table: "Class",
                newName: "IdGrade");

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Class",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GradeId",
                table: "Class",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Degree_GradeId",
                table: "Class",
                column: "GradeId",
                principalTable: "Degree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Degree_ClassRoom_IdClassRoom",
                table: "Degree",
                column: "IdClassRoom",
                principalTable: "ClassRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
