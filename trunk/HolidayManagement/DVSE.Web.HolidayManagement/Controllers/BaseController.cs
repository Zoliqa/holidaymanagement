using DVSE.DAL.HolidayManagement.EF.UnitOfWork;
using DVSE.DAL.HolidayManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVSE.Web.HolidayManagement.Controllers
{
    public partial class BaseController : Controller
    {
        protected IHMUnitOfWork _hmUnitOfWork;

        protected Employee CurrentEmployee
        {
            get
            {
                return _hmUnitOfWork.EmployeeRepository.FindBy(x => x.ADName == User.Identity.Name).SingleOrDefault();
            }
        }

        public BaseController()
        { }

        public BaseController(IHMUnitOfWork hmUnitOfWork)
        {
            _hmUnitOfWork = hmUnitOfWork;
        }
    }
}
