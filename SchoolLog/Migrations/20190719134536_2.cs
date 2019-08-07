using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolLog.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolType",
                table: "School");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolType",
                table: "School",
                nullable: false,
                defaultValue: 0);
        }
    }
}
