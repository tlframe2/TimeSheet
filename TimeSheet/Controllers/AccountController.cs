using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;
using TimeSheet.Services;
using TimeSheet.ViewModels.AccountViewModels;

namespace TimeSheet.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public AccountController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> EditUserDetails(User model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await GetCurrentUserAsync();
            var result = await _userService.UpdateUserDetailsAsync(model, currentUser);

            if (!result.Succeeded)
            {
                return BadRequest("Could not update user.");
            }

            return RedirectToAction("Index");
        }
    }
}

