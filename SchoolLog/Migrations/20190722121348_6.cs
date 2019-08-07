using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolLog.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventStudents_Students_StudentId",
                table: "EventStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventStudents",
                table: "EventStudents");

            migrationBuilder.DropIndex(
                name: "IX_EventStudents_EventId",
                table: "EventStudents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventStudents",
                table: "EventStudents",
                columns: new[] { "EventId", "StudentId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_EventStudents_StudentId_EventId",
                table: "EventStudents",
                columns: new[] { "StudentId", "EventId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventStudents_Students_EventId",
                table: "EventStudents",
                column: "EventId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventStudents_Students_EventId",
                table: "EventStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventStudents",
                table: "EventStudents");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_EventStudents_StudentId_EventId",
                table: "EventStudents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventStudents",
                table: "EventStudents",
                columns: new[] { "StudentId", "EventId" });

            migrationBuilder.CreateIndex(
                name: "IX_EventStudents_EventId",
                table: "EventStudents",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventStudents_Students_StudentId",
                table: "EventStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
