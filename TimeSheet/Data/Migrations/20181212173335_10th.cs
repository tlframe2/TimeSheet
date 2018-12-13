using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Data.Migrations
{
    public partial class _10th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayPeriods_AspNetUsers_UserId",
                schema: "TimeSheet",
                table: "PayPeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkDays_PayPeriods_PayPeriodId",
                schema: "TimeSheet",
                table: "WorkDays");

            migrationBuilder.DropIndex(
                name: "IX_PayPeriods_UserId",
                schema: "TimeSheet",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "TotalOTHours",
                schema: "TimeSheet",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "TotalPeriodPay",
                schema: "TimeSheet",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "TotalRegHours",
                schema: "TimeSheet",
                table: "PayPeriods");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "TimeSheet",
                table: "PayPeriods");

            migrationBuilder.RenameColumn(
                name: "PayPeriodId",
                schema: "TimeSheet",
                table: "WorkDays",
                newName: "TimeSheetReportId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkDays_PayPeriodId",
                schema: "TimeSheet",
                table: "WorkDays",
                newName: "IX_WorkDays_TimeSheetReportId");

            migrationBuilder.CreateTable(
                name: "TimeSheetReports",
                schema: "TimeSheet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TotalRegHours = table.Column<double>(nullable: false),
                    TotalOTHours = table.Column<double>(nullable: false),
                    TotalPeriodPay = table.Column<decimal>(type: "money", nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    PayPeriodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheetReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheetReports_PayPeriods_PayPeriodId",
                        column: x => x.PayPeriodId,
                        principalSchema: "TimeSheet",
                        principalTable: "PayPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSheetReports_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetReports_PayPeriodId",
                schema: "TimeSheet",
                table: "TimeSheetReports",
                column: "PayPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetReports_UserId",
                schema: "TimeSheet",
                table: "TimeSheetReports",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkDays_TimeSheetReports_TimeSheetReportId",
                schema: "TimeSheet",
                table: "WorkDays",
                column: "TimeSheetReportId",
                principalSchema: "TimeSheet",
                principalTable: "TimeSheetReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkDays_TimeSheetReports_TimeSheetReportId",
                schema: "TimeSheet",
                table: "WorkDays");

            migrationBuilder.DropTable(
                name: "TimeSheetReports",
                schema: "TimeSheet");

            migrationBuilder.RenameColumn(
                name: "TimeSheetReportId",
                schema: "TimeSheet",
                table: "WorkDays",
                newName: "PayPeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkDays_TimeSheetReportId",
                schema: "TimeSheet",
                table: "WorkDays",
                newName: "IX_WorkDays_PayPeriodId");

            migrationBuilder.AddColumn<double>(
                name: "TotalOTHours",
                schema: "TimeSheet",
                table: "PayPeriods",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPeriodPay",
                schema: "TimeSheet",
                table: "PayPeriods",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "TotalRegHours",
                schema: "TimeSheet",
                table: "PayPeriods",
                nullable: false,
                defaultValue: 0.0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_WorkDays_PayPeriods_PayPeriodId",
                schema: "TimeSheet",
                table: "WorkDays",
                column: "PayPeriodId",
                principalSchema: "TimeSheet",
                principalTable: "PayPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
