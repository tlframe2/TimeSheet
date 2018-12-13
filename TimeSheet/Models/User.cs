using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TimeSheet.Models
{
    [Table("Users", Schema = "TimeSheet")]
    public class User : IdentityUser
    {
        [Required]
        [DataType(DataType.Text), MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text), MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double HourlyWage { get; set; }

        [DefaultValue(true)]
        public bool Exempt { get; set; }

        [InverseProperty(nameof(TimeSheetReport.User))]
        public List<TimeSheetReport> TimeSheetReports { get; set; } = new List<TimeSheetReport>();
    }
}
