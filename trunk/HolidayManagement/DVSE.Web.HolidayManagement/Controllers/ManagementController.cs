using DVSE.DAL.HolidayManagement.EF.UnitOfWork;
using DVSE.Web.HolidayManagement.Infrastructure.Authentication;
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
        public ManagementController(IHMUnitOfWork hmUnitOfWork, IDomainUserProvider domainUserProvider)
            : base(hmUnitOfWork, domainUserProvider)
        {
        }

        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
