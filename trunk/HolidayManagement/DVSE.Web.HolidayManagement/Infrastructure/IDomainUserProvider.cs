using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVSE.Web.HolidayManagement.Infrastructure
{
    public interface IDomainUserProvider
    {
        IEnumerable<DomainUser> GetAllUsers();
    }
}