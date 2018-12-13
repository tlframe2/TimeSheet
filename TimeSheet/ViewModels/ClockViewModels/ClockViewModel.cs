using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TimeSheet.Models;
using TimeSheet.Data;

namespace TimeSheet.ViewModels.ClockViewModels
{
    public class ClockViewModel
    {
        public User User { get; set; }
    }
}
