using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVSE.Web.HolidayManagement.Controllers
{
    [Authorize(Roles = "AdminUser")]
    public partial class ManagementController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
