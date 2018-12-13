using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Data;
using TimeSheet.Models;

namespace TimeSheet.Initializers
{
    public class DbInit : IDbInit
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInit(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void Initialize()
        {
            //_context.Database.Migrate();

            string defaultPassword = "P@ssword123";

            User les = new User
            {
                FirstName = "Les",
                LastName = "Claypool",
                UserName = "les_claypool@email.com",
                HourlyWage = 10.00,
                Exempt = false
            };

            User kim = new User
            {
                FirstName = "Kim",
                LastName = "Deal",
                UserName = "kim_deal@email.com",
                HourlyWage = 12.00,
                Exempt = false
            };

            User lemmy = new User
            {
                FirstName = "Lemmy",
                LastName = "Kilmister",
                UserName = "lemmy_kilmister@email.com",
                HourlyWage = 20.00,
                Exempt = true
            };

            await _userManager.CreateAsync(les, defaultPassword);
            await _userManager.CreateAsync(kim, defaultPassword);
            await _userManager.CreateAsync(lemmy, defaultPassword);

            PayPeriod newPayPeriod = new PayPeriod()
            {
                PeriodStartDate = new DateTime(2018, 12, 2, 0, 0, 0),
                PeriodEndDate = new DateTime(2018, 12, 15, 23, 59, 59),
            };

            _context.PayPeriods.Add(newPayPeriod);
            _context.SaveChanges();
        }

        
    }
}
