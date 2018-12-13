using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Services
{
    public interface ITimeSheetService
    {
        TimeSheetReport GetCurrentPayPeriodReport(User currentUser);
        Task<WorkDay[]> GetWorkDaysForCurrentPayPeriodAsync(User currentUser);
    }
}
