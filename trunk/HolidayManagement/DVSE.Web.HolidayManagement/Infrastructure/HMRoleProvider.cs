using DVSE.DAL.HolidayManagement.EF;
using DVSE.DAL.HolidayManagement.EF.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DVSE.Web.HolidayManagement.Infrastructure
{
    public class HMRoleProvider : RoleProvider
    {
        private IHMUnitOfWork _hmUnitOfWork;

        public HMRoleProvider()
        {
            _hmUnitOfWork = new HMUnitOfWork(new HMContext()); 
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var employee = _hmUnitOfWork.EmployeeRepository.FindBy(x => x.ADName == username).SingleOrDefault();

            return new[] { employee != null ? employee.Role.Name : "" }; 
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}