using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVSE.Web.HolidayManagement.Models
{
    public class HolidayOverviewViewModel
    {
        public MonthlyCalendarViewModel[] MonthlyCalendars { get; set; }
    }
}