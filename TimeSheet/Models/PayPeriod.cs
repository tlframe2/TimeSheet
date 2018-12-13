using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using TimeSheet.Models.Base;
using System;

namespace TimeSheet.Models
{
    [Table("PayPeriods", Schema = "TimeSheet")]
    public class PayPeriod : EntityBase
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime PeriodStartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PeriodEndDate { get; set; }

        [InverseProperty(nameof(TimeSheetReport.PayPeriod))]
        public List<TimeSheetReport> TimeSheetReports { get; set; } = new List<TimeSheetReport>();
    }
}
