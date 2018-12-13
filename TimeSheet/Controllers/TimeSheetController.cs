using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;
using TimeSheet.Services;

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





        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
