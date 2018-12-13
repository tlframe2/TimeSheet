using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Services
{
    public interface IUserService
    {
        Task<IdentityResult> UpdateUserDetailsAsync(User newDetails, User currentUser);
    }
}

