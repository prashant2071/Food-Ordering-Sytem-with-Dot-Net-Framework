using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using AuthenticationAndAuthorizationPart2.Models;

namespace AuthenticationAndAuthorizationPart2
{
    public class MyRoleProvider : RoleProvider
    {
        NepalDBEntities db = new NepalDBEntities();
        
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (NepalDBEntities _db = new NepalDBEntities())
            {
                tblUser tb = _db.tblUsers.FirstOrDefault(x => x.Username == username);
                if (tb == null)
                {
                    return null;
                }
                else
                {
                    string[] ret = tb.tblUserRoles.Select(x => x.tblRole.Roles).ToArray();
                    return ret;
                }
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var userRole = GetRolesForUser(username);
            return userRole.Contains(roleName);
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