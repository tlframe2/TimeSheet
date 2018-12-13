using System.Collections.Generic;
using TimeSheet.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel;

namespace TimeSheet.Models
{
    [Table("WorkDays", Schema = "TimeSheet")]
    public class WorkDay : EntityBase
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ClockIn { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ClockOut { get; set; }

        public double HoursWorked { get; set; }

        [Required]
        [DefaultValue(ApprovalStatus.Pending)]
        public ApprovalStatus Approved { get; set; }

        [Required]
        public int TimeSheetReportId { get; set; }

        [ForeignKey(nameof(TimeSheetReportId))]
        public TimeSheetReport TimeSheetReport { get; set; }
    }
}
