using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Data;
using TimeSheet.Models;
using TimeSheet.Services;
using TimeSheet.ViewModels.ClockViewModels;

namespace TimeSheet.Controllers
{
    // Used for clocking in employees
    public class ClockController : Controller
    {
        private readonly IWorkDayService _workDayService;
        private readonly UserManager<User> _userManager;

        public ClockController(IWorkDayService workDayService, UserManager<User> userManager)
        {
            _workDayService = workDayService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();

            var model = new ClockViewModel()
            {
                User = currentUser
            };

            return View(model);
        }

        // Records clock in/out times and calculates hours spent working
        public async Task<IActionResult> AddWorkDay(WorkDay newWorkDay)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await GetCurrentUserAsync();
            var successful = await _workDayService.AddWorkDayAsync(newWorkDay, currentUser);

            //if (!successful)
            //{
            //    return BadRequest("Could not add workday.");
            //}

            return RedirectToAction("Index");
        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
