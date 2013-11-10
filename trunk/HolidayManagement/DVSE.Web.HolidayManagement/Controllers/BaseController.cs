﻿using DVSE.DAL.HolidayManagement.EF.UnitOfWork;
using DVSE.DAL.HolidayManagement.Entity;
using DVSE.Web.HolidayManagement.Infrastructure.Authentication;
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

        protected IDomainUserProvider _domainUserProvider;

        protected Employee CurrentEmployee
        {
            get
            {
                var loggedInUsername = _domainUserProvider.GetLoggedInUsername();

                return 
                    _hmUnitOfWork
                        .EmployeeRepository
                        .FindBy(x => x.ADName == loggedInUsername)
                        .SingleOrDefault();
            }
        }

        public BaseController()
        { }

        public BaseController(IHMUnitOfWork hmUnitOfWork, IDomainUserProvider domainUserProvider)
        {
            _hmUnitOfWork = hmUnitOfWork;

            _domainUserProvider = domainUserProvider;
        }
    }
}
