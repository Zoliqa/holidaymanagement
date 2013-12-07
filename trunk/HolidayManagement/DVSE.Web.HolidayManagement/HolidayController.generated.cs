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
    public partial class HolidayController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected HolidayController(Dummy d) { }

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
        public virtual System.Web.Mvc.ActionResult CreateRequest()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateRequest);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult EditRequest()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditRequest);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public HolidayController Actions { get { return MVC.Holiday; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Holiday";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Holiday";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Overview = "Overview";
            public readonly string CreateRequest = "CreateRequest";
            public readonly string GetRequests = "GetRequests";
            public readonly string EditRequest = "EditRequest";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Overview = "Overview";
            public const string CreateRequest = "CreateRequest";
            public const string GetRequests = "GetRequests";
            public const string EditRequest = "EditRequest";
        }


        static readonly ActionParamsClass_CreateRequest s_params_CreateRequest = new ActionParamsClass_CreateRequest();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CreateRequest CreateRequestParams { get { return s_params_CreateRequest; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CreateRequest
        {
            public readonly string requestVM = "requestVM";
        }
        static readonly ActionParamsClass_EditRequest s_params_EditRequest = new ActionParamsClass_EditRequest();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_EditRequest EditRequestParams { get { return s_params_EditRequest; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_EditRequest
        {
            public readonly string oper = "oper";
            public readonly string id = "id";
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
                public readonly string _Request = "_Request";
                public readonly string Overview = "Overview";
            }
            public readonly string _Request = "~/Views/Holiday/_Request.cshtml";
            public readonly string Overview = "~/Views/Holiday/Overview.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_HolidayController : DVSE.Web.HolidayManagement.Controllers.HolidayController
    {
        public T4MVC_HolidayController() : base(Dummy.Instance) { }

        partial void OverviewOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Web.Mvc.ActionResult Overview()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Overview);
            OverviewOverride(callInfo);
            return callInfo;
        }

        partial void CreateRequestOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, DVSE.Web.HolidayManagement.Models.RequestViewModel requestVM);

        public override System.Web.Mvc.ActionResult CreateRequest(DVSE.Web.HolidayManagement.Models.RequestViewModel requestVM)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateRequest);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "requestVM", requestVM);
            CreateRequestOverride(callInfo, requestVM);
            return callInfo;
        }

        partial void GetRequestsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        public override System.Web.Mvc.ActionResult GetRequests()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetRequests);
            GetRequestsOverride(callInfo);
            return callInfo;
        }

        partial void EditRequestOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string oper, int id);

        public override System.Web.Mvc.ActionResult EditRequest(string oper, int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.EditRequest);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "oper", oper);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            EditRequestOverride(callInfo, oper, id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
