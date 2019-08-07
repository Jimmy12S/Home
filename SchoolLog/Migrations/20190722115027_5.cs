using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolLog.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competition_School_SchoolID",
                table: "Competition");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Student_StudentID",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_School_Student_StudentID",
                table: "School");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_School_SchoolID",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School",
                table: "School");

            migrationBuilder.DropIndex(
                name: "IX_School_StudentID",
                table: "School");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_StudentID",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competition",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "School");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "School",
                newName: "Schools");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameTable(
                name: "Competition",
                newName: "Competitions");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Students",
                newName: "StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_SchoolID",
                table: "Students",
                newName: "IX_Students_SchoolID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Events",
                newName: "EventID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schools",
                table: "Schools",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competitions",
                table: "Competitions",
                column: "SchoolID");

            migrationBuilder.CreateTable(
                name: "EventStudents",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStudents", x => new { x.StudentId, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventStudents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventStudents_EventId",
                table: "EventStudents",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_Schools_SchoolID",
                table: "Competitions",
                column: "SchoolID",
                principalTable: "Schools",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Schools_SchoolID",
                table: "Students",
                column: "SchoolID",
                principalTable: "Schools",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Schools_SchoolID",
                table: "Competitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Schools_SchoolID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "EventStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schools",
                table: "Schools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competitions",
                table: "Competitions");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Schools",
                newName: "School");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "Competitions",
                newName: "Competition");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Student",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_SchoolID",
                table: "Student",
                newName: "IX_Student_SchoolID");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "Event",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "School",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School",
                table: "School",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competition",
                table: "Competition",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_School_StudentID",
                table: "School",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_StudentID",
                table: "Event",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Competition_School_SchoolID",
                table: "Competition",
                column: "SchoolID",
                principalTable: "School",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Student_StudentID",
                table: "Event",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_School_Student_StudentID",
                table: "School",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_School_SchoolID",
                table: "Student",
                column: "SchoolID",
                principalTable: "School",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
