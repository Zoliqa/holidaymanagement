// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace DVSE.Web.HolidayManagement.Controllers
{
    public partial class ManagementController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ManagementController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult UpdateEmployee()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UpdateEmployee);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ManagementController Actions { get { return MVC.Management; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Management";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Management";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string GetEmployees = "GetEmployees";
            public readonly string UpdateEmployee = "UpdateEmployee";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string GetEmployees = "GetEmployees";
            public const string UpdateEmployee = "UpdateEmployee";
        }


        static readonly ActionParamsClass_UpdateEmployee s_params_UpdateEmployee = new ActionParamsClass_UpdateEmployee();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UpdateEmployee UpdateEmployeeParams { get { return s_params_UpdateEmployee; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UpdateEmployee
        {
            public readonly string employeeVM = "employeeVM";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _Employee = "_Employee";
                public readonly string Index = "Index";
            }
            public readonly string _Employee = "~/Views/Management/_Employee.cshtml";
            public readonly string Index = "~/Views/Management/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ManagementController : DVSE.Web.HolidayManagement.Controllers.ManagementController
    {
        public T4MVC_ManagementController() : base(Dummy.Instance) { }

        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        partial void GetEmployeesOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Web.Mvc.ActionResult GetEmployees()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetEmployees);
            GetEmployeesOverride(callInfo);
            return callInfo;
        }

        partial void UpdateEmployeeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, DVSE.Web.HolidayManagement.Models.EmployeeViewModel employeeVM);

        public override System.Web.Mvc.ActionResult UpdateEmployee(DVSE.Web.HolidayManagement.Models.EmployeeViewModel employeeVM)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UpdateEmployee);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "employeeVM", employeeVM);
            UpdateEmployeeOverride(callInfo, employeeVM);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
