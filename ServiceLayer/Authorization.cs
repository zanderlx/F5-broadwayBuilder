using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class Authorization : IAuthorization
    {
        //Key = RoleType(General,Admin,SysAdmin) Value = List of permissions for that roletype
        Dictionary<RoleType,List<Permission>> permissions;
        public Authorization(Dictionary<RoleType, List<Permission>> authorizedPermissions)
        {
            permissions = authorizedPermissions;
        }
        // Checks user's role
        public string CheckUserRole(User user)
        {
            if (user.Role.Equals(RoleType.SYS_ADMIN))
                return "SYS_ADMIN";
            else if (user.Role.Equals(RoleType.THEATRE_ADMIN))
                return "THEATRE_ADMIN";
            else
                return "GENERAL";
        }

        /// <summary>
        /// Checks if a user is authorized to perform a action
        /// </summary>
        /// <param name="user">User that must be checked if they are authorized</param>
        /// <param name="CheckIfAuthorized">check if user has this permission</param>
        /// <returns>true if user has permission, false otherwise</returns>
        public bool HasPermission(User user, Permission CheckIfAuthorized)
        {
            if (permissions.ContainsKey(user.Role))
            {
                List<Permission> RolePermissions = permissions[user.Role];
                if (RolePermissions.Contains(CheckIfAuthorized))
                    return true;
            }
            return false;
        }


    }
}
