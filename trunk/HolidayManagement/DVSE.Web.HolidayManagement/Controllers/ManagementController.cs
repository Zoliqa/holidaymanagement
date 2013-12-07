using DVSE.DAL.HolidayManagement.EF.UnitOfWork;
using DVSE.DAL.HolidayManagement.Entity;
using DVSE.Web.HolidayManagement.Infrastructure.Authentication;
using DVSE.Web.HolidayManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVSE.Web.HolidayManagement.Helpers;

namespace DVSE.Web.HolidayManagement.Controllers
{
    [Authorize(Roles = "AdminUser")]
    public partial class ManagementController : BaseController
    {
        public ManagementController(IHMUnitOfWork hmUnitOfWork, IDomainUserProvider domainUserProvider)
            : base(hmUnitOfWork, domainUserProvider)
        {
        }

        public virtual ActionResult Index()
        {
            return View();
        }

        public int GetWorkDaysBetween(DateTime startDate, DateTime endDate)
        {
            var result = endDate - startDate;

            return result.Days;
        }

        public virtual ActionResult GetEmployees()
        {
            var employees = _hmUnitOfWork.EmployeeRepository.GetAll().ToList();

            var currentYear = DateTime.Now.Year;

            var vm = new GridDataJson
            {
                records = employees.Count(),
                rows = employees.Select(x =>
                {
                    var currentHolidayInformation = x.HolidayInformations.SingleOrDefault(y => y.Year == currentYear);

                    var days = 
                        x.HolidayPeriods
                            .Where(y => y.CancelDate == null)
                            .Select(y => GetWorkDaysBetween(y.StartDate, y.EndDate))
                            .Sum();

                    var row = new GridRowJson
                    {
                        id = x.Id,
                        cell = new object[] 
                        {
                            x.FirstName,
                            x.LastName,
                            x.EmailAddress,
                            x.Team != null ? x.Team.Name : "na",
                            currentHolidayInformation != null ? currentHolidayInformation.DaysAvailable.ToString () : "na",
                            currentHolidayInformation != null ? (currentHolidayInformation.DaysAvailable - days).ToString() : "na"
                        }
                    };

                    return row;
                }).ToList()
            };

            return Json(vm, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult UpdateEmployee(int id)
        {
            var employee = _hmUnitOfWork.EmployeeRepository.GetSingle(id);

            if (employee == null)
            {
                return Json(new { success = false, message = "Employee is not found." });
            }

            var currentHolidayInformation = employee.HolidayInformations.SingleOrDefault(x => x.Year == DateTime.Now.Year);

            var employeeVM = new EmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                EmailAddress = employee.EmailAddress,
                HireDate = employee.HireDate,
                TeamId  = employee.TeamId,
                Teams = new SelectList(_hmUnitOfWork.TeamRepository.GetAll(), "Id", "Name"),
                DaysAvailable = currentHolidayInformation != null ? currentHolidayInformation.DaysAvailable : (int?)null
            };

            var result = new 
            {
                success = true,
                content = base.RenderRazorViewToString(MVC.Management.Views._Employee, employeeVM)
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual ActionResult UpdateEmployee(EmployeeViewModel employeeVM) 
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Data is not valid." });
            }

            var employee = _hmUnitOfWork.EmployeeRepository.GetSingle(employeeVM.Id);

            if (employee == null)
            {
                return Json(new { success = false, message = "Employee is not found." });
            }

            employee.FirstName = employeeVM.FirstName;
            employee.LastName = employeeVM.LastName;
            employee.EmailAddress = employeeVM.EmailAddress;
            employee.HireDate = employeeVM.HireDate;
            employee.TeamId = employeeVM.TeamId;

            var currentHolidayInformation = employee.HolidayInformations.SingleOrDefault(x => x.Year == DateTime.Now.Year);

            if (currentHolidayInformation == null)
            {
                currentHolidayInformation = new HolidayInformation
                {
                    DaysAvailable = employeeVM.DaysAvailable.Value,
                    Employee = employee
                };

                _hmUnitOfWork.HolidayInformationRepository.Add(currentHolidayInformation);
            }
            else
                currentHolidayInformation.DaysAvailable = employeeVM.DaysAvailable.Value;

            _hmUnitOfWork.Save();

            return Json(new { success = true });
        }
    }
}
