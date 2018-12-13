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

        public TimeSheetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<TimeSheetReport> GetCurrentPayPeriodReport()
        {
            throw new NotImplementedException();
        }
    }
}
