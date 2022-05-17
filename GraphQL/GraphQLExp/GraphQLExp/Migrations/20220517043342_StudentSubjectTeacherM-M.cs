using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLExp.Migrations
{
    public partial class StudentSubjectTeacherMM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Students_OptedByStudentId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Subjects_OptedSubjectsSubjectId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsAllotedSubjectId",
                table: "SubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Teachers_AllotedTeachersTeacherId",
                table: "SubjectTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject");

            migrationBuilder.RenameColumn(
                name: "SubjectsAllotedSubjectId",
                table: "SubjectTeacher",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "AllotedTeachersTeacherId",
                table: "SubjectTeacher",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeacher_SubjectsAllotedSubjectId",
                table: "SubjectTeacher",
                newName: "IX_SubjectTeacher_TeacherId");

            migrationBuilder.RenameColumn(
                name: "OptedSubjectsSubjectId",
                table: "StudentSubject",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "OptedByStudentId",
                table: "StudentSubject",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubject_OptedSubjectsSubjectId",
                table: "StudentSubject",
                newName: "IX_StudentSubject_SubjectId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SubjectTeacher",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentSubject",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_SubjectId",
                table: "SubjectTeacher",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_StudentId",
                table: "StudentSubject",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Students_StudentId",
                table: "StudentSubject",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectId",
                table: "StudentSubject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectId",
                table: "SubjectTeacher",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeacherId",
                table: "SubjectTeacher",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Students_StudentId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectId",
                table: "SubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeacherId",
                table: "SubjectTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTeacher_SubjectId",
                table: "SubjectTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubject_StudentId",
                table: "StudentSubject");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SubjectTeacher");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentSubject");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "SubjectTeacher",
                newName: "SubjectsAllotedSubjectId");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "SubjectTeacher",
                newName: "AllotedTeachersTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeacher_TeacherId",
                table: "SubjectTeacher",
                newName: "IX_SubjectTeacher_SubjectsAllotedSubjectId");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "StudentSubject",
                newName: "OptedSubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentSubject",
                newName: "OptedByStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubject",
                newName: "IX_StudentSubject_OptedSubjectsSubjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher",
                columns: new[] { "AllotedTeachersTeacherId", "SubjectsAllotedSubjectId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject",
                columns: new[] { "OptedByStudentId", "OptedSubjectsSubjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Students_OptedByStudentId",
                table: "StudentSubject",
                column: "OptedByStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Subjects_OptedSubjectsSubjectId",
                table: "StudentSubject",
                column: "OptedSubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectsAllotedSubjectId",
                table: "SubjectTeacher",
                column: "SubjectsAllotedSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teachers_AllotedTeachersTeacherId",
                table: "SubjectTeacher",
                column: "AllotedTeachersTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
