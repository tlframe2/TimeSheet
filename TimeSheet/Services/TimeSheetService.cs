using Microsoft.AspNetCore.Identity;
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
    }
}
