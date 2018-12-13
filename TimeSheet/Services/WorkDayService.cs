using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Data;
using TimeSheet.Models;

namespace TimeSheet.Services
{
    public class WorkDayService : IWorkDayService
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;

        public WorkDayService(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<bool> AddWorkDayAsync(WorkDay newWorkDay, User currentUser)
        {
            DateTime recentPayPeriodStart = _context.PayPeriods.OrderBy(e => e.Id).Last().PeriodStartDate;
            DateTime recentPayPeriodEnd = _context.PayPeriods.OrderBy(e => e.Id).Last().PeriodEndDate;

            // Creates new Pay Period and TimeSheet for that period if current date is past previous period end date
            if (DateTime.Now > recentPayPeriodEnd)
            {
                PayPeriod newPayPeriod = new PayPeriod()
                {
                    PeriodStartDate = recentPayPeriodEnd.AddSeconds(1),
                    PeriodEndDate = recentPayPeriodEnd.AddDays(14)
                };

                _context.PayPeriods.Add(newPayPeriod);

                TimeSheetReport newTimeSheetReport = new TimeSheetReport()
                {
                    TotalRegHours = 0,
                    TotalOTHours = 0,
                    TotalPeriodPay = 0,
                    UserId = currentUser.Id,
                    PayPeriodId = newPayPeriod.Id
                };

                _context.TimeSheetReports.Add(newTimeSheetReport);
                _context.SaveChanges();
            }

            // creates TimeSheet if user has none
            if (_context.TimeSheetReports.Where(e => e.UserId == currentUser.Id).Count() < 1)
            {
                TimeSheetReport newTimeSheetReport = new TimeSheetReport()
                {
                    TotalRegHours = 0,
                    TotalOTHours = 0,
                    TotalPeriodPay = 0,
                    UserId = currentUser.Id,
                    PayPeriodId = _context.PayPeriods.OrderBy(e => e.Id).ToList().Last().Id
                };

                _context.TimeSheetReports.Add(newTimeSheetReport);
                _context.SaveChanges();
            }

            // Creates new instance of workDay
            newWorkDay.Date = newWorkDay.ClockIn;
            newWorkDay.HoursWorked = calculateTotalHours(newWorkDay);
            var currentReport = _context.TimeSheetReports.Where(e => e.UserId == currentUser.Id).OrderBy(e => e.Id).ToList().Last();
            newWorkDay.TimeSheetReportId = currentReport.Id;

            // Updates TimeSheet
            currentReport.TotalRegHours += newWorkDay.HoursWorked;
            currentReport.TotalOTHours = (currentReport.TotalRegHours > 40 && !currentUser.Exempt) ? currentReport.TotalRegHours - 40 : 0;
            currentReport.TotalPeriodPay = (currentReport.TotalRegHours * currentUser.HourlyWage) + (currentReport.TotalOTHours *
                                            currentUser.HourlyWage * 1.5);

            _context.WorkDays.Add(newWorkDay);

            var saveResult = await _context.SaveChangesAsync();

            return saveResult == 1;

        }

        private double calculateTotalHours(WorkDay newWorkDay)
        {
            TimeSpan duration = newWorkDay.ClockOut - newWorkDay.ClockIn;

            return duration.TotalHours;
        }
    }
}
