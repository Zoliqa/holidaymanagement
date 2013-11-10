using DVSE.DAL.HolidayManagement.EF.UnitOfWork;
using DVSE.DAL.HolidayManagement.Entity;
using DVSE.Web.HolidayManagement.Infrastructure;
using DVSE.Web.HolidayManagement.Infrastructure.Authentication;
using DVSE.Web.HolidayManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVSE.Web.HolidayManagement.Helpers;

namespace DVSE.Web.HolidayManagement.Controllers
{
    [Authorize(Roles = "NormalUser, AdminUser")]
    public partial class HolidayController : BaseController
    {
        public HolidayController(IHMUnitOfWork hmUnitOfWork, IDomainUserProvider domainUserProvider) 
            : base(hmUnitOfWork, domainUserProvider)
        {
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
                    MonthIndex = i,
                    FirstDay = (int)month.DayOfWeek, 
                    NumberOfDays = DateTime.DaysInMonth(now.Year, i + 1),
                };
            }

            var vm = new HolidayOverviewViewModel
            {
                LoggedInUserName = _domainUserProvider.GetLoggedInUsername(),
                MonthlyCalendars = months,
                RequestViewModel = new RequestViewModel
                {
                    Purposes = new SelectList(_hmUnitOfWork.PurposeRepository.GetAll(), "Id", "Description"),
                }
            };

            return View(MVC.Holiday.Views.Overview, vm);
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

            var result = new
            {
                successed = true,
                requestsResult = this.RenderRazorViewToString(MVC.Holiday.Views._RequestsList, CreateRequestsViewModel()),
            };

            return Json(result);
        }

        public virtual ActionResult GetRequests()
        {
            var vm = CreateRequestsViewModel();

            return PartialView(MVC.Holiday.Views._RequestsList, vm);
        }

        private RequestsListViewModel CreateRequestsViewModel()
        {
            var requests = _hmUnitOfWork.RequestRepository.FindBy(x => x.EmployeeId == CurrentEmployee.Id);

            var vm = new RequestsListViewModel
            {
                Requests = requests.Select(x => new RequestViewModel
                {
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                }).AsEnumerable()
            };

            return vm;
        }
    }
}
