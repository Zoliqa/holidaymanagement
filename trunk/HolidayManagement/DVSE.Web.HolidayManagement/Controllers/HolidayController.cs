using DVSE.DAL.HolidayManagement.EF.UnitOfWork;
using DVSE.DAL.HolidayManagement.Entity;
using DVSE.Web.HolidayManagement.Infrastructure;
using DVSE.Web.HolidayManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVSE.Web.HolidayManagement.Controllers
{
    [Authorize(Roles = "NormalUser, AdminUser")]
    public partial class HolidayController : BaseController
    {
        public HolidayController(IHMUnitOfWork hmUnitOfWork) 
            : base(hmUnitOfWork)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
        }

        public virtual ActionResult Index()
        {
            var months = new MonthlyCalendarViewModel[12];

            var now = DateTime.Now;

            for (var i = 0; i < 12; ++i)
            {
                var month = new DateTime(now.Year, i + 1, 1);

                months[i] = new MonthlyCalendarViewModel
                {
                    Month = month.ToString("MMMM"),
                    MonthIndex = i,
                    FirstDay = (int)month.DayOfWeek, 
                    NumberOfDays = DateTime.DaysInMonth(now.Year, i + 1),
                };
            }

            var vm = new HolidayOverviewViewModel
            {
                MonthlyCalendars = months,
                RequestViewModel = new RequestViewModel
                {
                    Purposes = new SelectList(_hmUnitOfWork.PurposeRepository.GetAll(), "Id", "Description"),
                }
            };

            return View(MVC.Holiday.Views.Index, vm);
        }

        [HttpPost]
        public virtual ActionResult CreateRequest(RequestViewModel requestVM)
        {
            var request = new Request
            {
                EmployeeId = CurrentEmployee.Id,
                StartDate = requestVM.StartDate,
                EndDate = requestVM.EndDate,
                PurposeId = requestVM.PurposeId,
                RequestDate = DateTime.Now,
            };

            _hmUnitOfWork.RequestRepository.Add(request);

            _hmUnitOfWork.Save();

            return Json(new { successed = true });
        }
    }
}
