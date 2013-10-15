using DVSE.DAL.HolidayManagement.EF.UnitOfWork;
using DVSE.Web.HolidayManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVSE.Web.HolidayManagement.Controllers
{
    public partial class HolidayController : Controller
    {
        IHMUnitOfWork _hmUnitOfWork;

        public HolidayController(IHMUnitOfWork hmUnitOfWork)
        {
            _hmUnitOfWork = hmUnitOfWork;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
        }

        public virtual ActionResult Overview()
        {
            var months = new MonthlyCalendarViewModel[12];

            var now = DateTime.Now;

            for (var i = 0; i < 12; ++i)
            {
                var month = new DateTime(now.Year, i + 1, 1);

                months[i] = new MonthlyCalendarViewModel
                {
                    Month = month.ToString("MMMM"),
                    FirstDay = (int)month.DayOfWeek, 
                    NumberOfDays = DateTime.DaysInMonth(now.Year, i + 1),
                };
            }

            var vm = new HolidayOverviewViewModel
            {
                MonthlyCalendars = months,
            };

            return View(MVC.Holiday.Views.Overview, vm);
        }
    }
}
