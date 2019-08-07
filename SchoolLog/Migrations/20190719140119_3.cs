using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolLog.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "School",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "School",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 50);
        }
    }
}
