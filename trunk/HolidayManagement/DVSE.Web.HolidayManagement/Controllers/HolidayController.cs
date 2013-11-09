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
    public partial class HolidayController : Controller
    {
        private IHMUnitOfWork _hmUnitOfWork;

        public HolidayController(IHMUnitOfWork hmUnitOfWork)
        {
            _hmUnitOfWork = hmUnitOfWork;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
        }

        public virtual ActionResult Index()
        {
            var username = HttpContext.User.Identity.Name;

            var employee = _hmUnitOfWork.EmployeeRepository.FindBy(x => x.ADName == username).SingleOrDefault();

            if (employee == null)
            {
                var adminADName = ConfigurationManager.AppSettings["AdminADName"];

                var roleName = username == adminADName ? "AdminUser" : "NormalUser";

                var role = _hmUnitOfWork.RoleRepository.FindBy(x => x.Name == roleName).SingleOrDefault();

                employee = new Employee
                {
                    ADName = username,
                    RoleId = role.Id 
                };

                _hmUnitOfWork.EmployeeRepository.Add(employee);

                _hmUnitOfWork.Save();
            }

            return RedirectToAction(MVC.Holiday.Overview());
        }

        [Authorize(Roles = "NormalUser, AdminUser")]
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

            return View(MVC.Holiday.Views.Overview, vm);
        }

        [Authorize(Roles = "NormalUser, AdminUser")]
        [HttpPost]
        public virtual ActionResult CreateRequest(RequestViewModel requestVM)
        {
            return null;
        }
    }
}
