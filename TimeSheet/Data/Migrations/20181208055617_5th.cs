using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Data.Migrations
{
    public partial class _5th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkDays_AspNetUsers_UserId",
                schema: "TimeSheet",
                table: "WorkDays");

            migrationBuilder.DropIndex(
                name: "IX_WorkDays_UserId",
                schema: "TimeSheet",
                table: "WorkDays");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "TimeSheet",
                table: "WorkDays");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "TimeSheet",
                table: "PayPeriods",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PayPeriods_UserId",
                schema: "TimeSheet",
                table: "PayPeriods",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayPeriods_AspNetUsers_UserId",
                schema: "TimeSheet",
                table: "PayPeriods",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayPeriods_AspNetUsers_UserId",
                schema: "TimeSheet",
                table: "PayPeriods");

            migrationBuilder.DropIndex(
                name: "IX_PayPeriods_UserId",
                schema: "TimeSheet",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "TimeSheet",
                table: "PayPeriods");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "TimeSheet",
                table: "WorkDays",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDays_UserId",
                schema: "TimeSheet",
                table: "WorkDays",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkDays_AspNetUsers_UserId",
                schema: "TimeSheet",
                table: "WorkDays",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
