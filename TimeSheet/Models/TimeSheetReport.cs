using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using TimeSheet.Models.Base;
using System;

namespace TimeSheet.Models
{
    [Table("TimeSheetReports", Schema = "TimeSheet")]
    public class TimeSheetReport : EntityBase
    {
        //[Required]
        //[DataType(DataType.Date)]
        //public DateTime PeriodStartDate { get; set; }

        //[Required]
        //[DataType(DataType.Date)]
        //public DateTime PeriodEndDate { get; set; }

        [Required]
        [Display(Name = "Total Regular Hours")]
        public double? TotalRegHours { get; set; }

        [Required]
        [Display(Name = "Total Overtime Hours")]
        public double? TotalOTHours { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double? TotalPeriodPay { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Required]
        public int PayPeriodId { get; set; }

        [ForeignKey(nameof(PayPeriodId))]
        public PayPeriod PayPeriod { get; set; }

        [InverseProperty(nameof(WorkDay.TimeSheetReport))]
        public List<WorkDay> WorkDays { get; set; } = new List<WorkDay>();
    }
}
