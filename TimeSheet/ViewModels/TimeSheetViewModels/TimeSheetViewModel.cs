﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.ViewModels.TimeSheetViewModels
{
    public class TimeSheetViewModel
    {
        public TimeSheetReport Report { get; set; }
        public TimeSheetReport[] Reports { get; set; }
    }
}
