using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> UpdateUserDetailsAsync(User newDetails, User currentUser)
        {
            currentUser.FirstName = newDetails.FirstName;
            currentUser.LastName = newDetails.LastName;
            currentUser.HourlyWage = newDetails.HourlyWage;

            return await _userManager.UpdateAsync(currentUser);
        }

        
    }
}

