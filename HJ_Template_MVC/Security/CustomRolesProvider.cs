using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HJ_Template_MVC.Security
{
    public class CustomRolesProvider:RoleProvider
    {
        private DataBaseContext db = new DataBaseContext();
        public CustomRolesProvider() : base()
        {

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

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
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
                return db.Roles.Select(r => r.Name).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            var Role = db.Users
                           .Where(r => r.Name == username)
                           .SelectMany(x => x.Roles)
                           ;
            var re = Role.Select(C => C.Name).ToArray();
            return  re;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var user = db.Users.SingleOrDefault(u => u.Name == username);
            var userRoles = db.Roles.Select(r => r.Name);

            if (user == null)
                return false;
            return user.Roles != null &&
                userRoles.Any(r => r == roleName);
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