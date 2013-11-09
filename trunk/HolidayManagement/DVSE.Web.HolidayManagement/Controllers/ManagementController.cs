using DVSE.DAL.HolidayManagement.EF.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVSE.Web.HolidayManagement.Controllers
{
    [Authorize(Roles = "AdminUser")]
    public partial class ManagementController : BaseController
    {
        public ManagementController(IHMUnitOfWork hmUnitOfWork)
            : base(hmUnitOfWork)
        {
        }

        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
