using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLExp.Migrations
{
    public partial class subject_teacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Subjects_SubjectId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_SubjectId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Teachers");

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                columns: table => new
                {
                    AllotedTeachersTeacherId = table.Column<int>(type: "int", nullable: false),
                    SubjectsAllotedSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => new { x.AllotedTeachersTeacherId, x.SubjectsAllotedSubjectId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subjects_SubjectsAllotedSubjectId",
                        column: x => x.SubjectsAllotedSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Teachers_AllotedTeachersTeacherId",
                        column: x => x.AllotedTeachersTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_SubjectsAllotedSubjectId",
                table: "SubjectTeacher",
                column: "SubjectsAllotedSubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectTeacher");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SubjectId",
                table: "Teachers",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Subjects_SubjectId",
                table: "Teachers",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId");
        }
    }
}
