using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Data.Migrations
{
    public partial class _7th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "HoursWorked",
                schema: "TimeSheet",
                table: "WorkDays",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "HoursWorked",
                schema: "TimeSheet",
                table: "WorkDays",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
