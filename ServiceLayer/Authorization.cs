using ServiceLayer.Enums;
using ServiceLayer.Models;
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
        private Dictionary<RoleType,List<Permission>> permissions;
        public Authorization(Dictionary<RoleType, List<Permission>> authorizedPermissions)
        {
            permissions = authorizedPermissions;
        }

        public Dictionary<RoleType, List<Permission>> Permissions
        {
            get
            {
                return permissions;
            }
            set
            {
                permissions = value;
            }
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
