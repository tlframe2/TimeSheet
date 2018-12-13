using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Services
{
    public interface IWorkDayService
    {
        Task<bool> AddWorkDayAsync(WorkDay newWorkDay, User currentUser); 
    }
}
