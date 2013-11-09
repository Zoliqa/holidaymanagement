using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVSE.Web.HolidayManagement.Infrastructure
{
    public class FakeDomainUserProvider : IDomainUserProvider
    {
        public IEnumerable<DomainUser> GetAllUsers()
        {
            var users = new List<DomainUser>();

            users.Add(new DomainUser{Name=@"Zoliqa-PC\Zoliqa", EmailAddress = "azoliqa@gmail.com"});

            Enumerable
                .Range(1, 10)
                .ToList()
                .ForEach(x => users.Add(new DomainUser 
                    { 
                        Name = "Name" + x, 
                        EmailAddress = "Email" + x + "@address.com" 
                    }));

            return users;
        }
    }
}