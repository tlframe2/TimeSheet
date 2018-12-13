using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;
using TimeSheet.Services;
using TimeSheet.ViewModels.TimeSheetViewModels;

namespace TimeSheet.Controllers
{
    public class TimeSheetController : Controller
    {
        private readonly ITimeSheetService _timeSheetService;
        private readonly UserManager<User> _userManager;

        public TimeSheetController(ITimeSheetService timeSheetService, UserManager<User> userManager)
        {
            _timeSheetService = timeSheetService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CurrentTimeSheetReport()
        {
            var currentUser = await GetCurrentUserAsync();
            var report = await _timeSheetService.GetCurrentPayPeriodReportAsync(currentUser);

            var model = new TimeSheetViewModel()
            {
                Report = report
            };

            return View(model);
        }

        public async Task<IActionResult> CurrentPayPeriodWorkDays()
        {
            var currentUser = await GetCurrentUserAsync();
            var workDays = await _timeSheetService.GetWorkDaysForCurrentPayPeriodAsync(currentUser);

            var model = new WorkDaysViewModel()
            {
                WorkDays = workDays
            };

            return View(model);
        }





        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
