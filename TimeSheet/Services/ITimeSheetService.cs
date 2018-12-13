using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Services
{
    public interface ITimeSheetService
    {
        Task<TimeSheetReport> GetCurrentPayPeriodReport();
    }
}
