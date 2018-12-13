using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Data;
using TimeSheet.Models;

namespace TimeSheet.Services
{
    public class TimeSheetService : ITimeSheetService
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;

        public TimeSheetService(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public TimeSheetReport GetCurrentPayPeriodReport(User currentUser)
        {
            return _context.TimeSheetReports.Where(e => e.UserId == currentUser.Id).OrderBy(e => e.PayPeriodId).Last();
        }

        public async Task<WorkDay[]> GetWorkDaysForCurrentPayPeriodAsync(User currentUser)
        {
            return await _context.WorkDays.Where(e => e.TimeSheetReport.UserId == currentUser.Id).ToArrayAsync();
        }

        private async Task<TimeSheetReport> ComputeReportAsync(TimeSheetReport report)
        {
            List<WorkDay> workDays = report.WorkDays;
            report.TotalRegHours = workDays.Sum(e => e.HoursWorked);
            await _context.SaveChangesAsync();
            return report;
        }
    }
}
