using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Data;
using TimeSheet.Models;

namespace TimeSheet.Initializers
{
    public class Initializer
    {
        private UserManager<User> _userManager;
        private ApplicationDbContext _context;

        public Initializer(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task Seed()
        {
            string defaultPassword = "P@ssword123";

            User les = new User
            {
                FirstName = "Les",
                LastName = "Claypool",
                Email = "les_claypool@email.com",
                UserName = "les_claypool@email.com",
                HourlyWage = 10.00,
                Exempt = false
            };

            User kim = new User
            {
                FirstName = "Kim",
                LastName = "Deal",
                Email = "kim_deal@email.com",
                UserName = "kim_deal@email.com",
                HourlyWage = 12.00,
                Exempt = false
            };

            User lemmy = new User
            {
                FirstName = "Lemmy",
                LastName = "Kilmister",
                Email = "lemmy_kilmister@email.com",
                UserName = "lemmy_kilmister@email.com",
                HourlyWage = 20.00,
                Exempt = true
            };

            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(les, defaultPassword);
                await _userManager.CreateAsync(kim, defaultPassword);
                await _userManager.CreateAsync(lemmy, defaultPassword);
            }

            PayPeriod newPayPeriod = new PayPeriod()
            {
                PeriodStartDate = new DateTime(2018, 11, 18, 0, 0, 0),
                PeriodEndDate = new DateTime(2018, 12, 1, 23, 59, 59),
            };

            if (!_context.PayPeriods.Any())
            {
                await _context.PayPeriods.AddAsync(newPayPeriod);
                await _context.SaveChangesAsync();
            }
        }
    }
}
