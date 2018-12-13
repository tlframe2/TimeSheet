using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Data;
using TimeSheet.Models;

namespace TimeSheet.Initializers
{
    public class PayPeriodInitializer
    {
        private ApplicationDbContext _context;

        public PayPeriodInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            PayPeriod newPayPeriod = new PayPeriod()
            {
                PeriodStartDate = new DateTime(2018, 12, 2, 0, 0, 0),
                PeriodEndDate = new DateTime(2018, 12, 15, 23, 59, 59),
            };

            if (!_context.PayPeriods.Any())
            {
                await _context.PayPeriods.AddAsync(newPayPeriod);
            }
        }
    }
}
