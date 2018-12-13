using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Models;

namespace TimeSheet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception)
            {

            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TimeSheet_Tyrell_Brian;Trusted_Connection=True;MultipleActiveResultSets=true;",
                options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().Property(e => e.HourlyWage).HasColumnType("money");

            builder.Entity<TimeSheetReport>().Property(e => e.TotalPeriodPay).HasColumnType("money");
        }

        public DbSet<PayPeriod> PayPeriods { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<TimeSheetReport> TimeSheetReports { get; set; }
    }
}
