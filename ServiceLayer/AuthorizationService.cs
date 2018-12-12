using DataAccessLayer;
using DataAccessLayer.Enums;
//using ServiceLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceLayer
{
    public class AuthorizationService : IAuthorizationService
    {
        
        private readonly BroadwayBuilderContext _dbContext;

        
        public AuthorizationService(BroadwayBuilderContext dbcontext)
        {
            //Initialize the DbContext
            this._dbContext = dbcontext;
        }
        

        /// <summary>
        /// Checks if a user is authorized to perform a action by checking if they have the permission needed
        /// </summary>
        /// <param name="user">User that must be checked if they are authorized</param>
        /// <param name="checkIfAuthorized">check if user has this permission</param>
        /// <returns>true if user has permission, false otherwise</returns>
        public bool HasPermission(User user, Permission checkIfAuthorized)
        {
            User getUser = _dbContext.Users.Find(user.Username);
            if (getUser != null)
            {
                Permission getUserPermission = getUser.Permissions.Where(s=>s.PermissionTitle==checkIfAuthorized.PermissionTitle).FirstOrDefault<Permission>();
                if (getUserPermission != null)
                    return true;
            }
            return false;

        }

        public bool HasPermission(string username, string permissionTitle)
        {
            User getUser = _dbContext.Users.Find(username);
            if (getUser != null)
            {
                Permission getUserPermission = getUser.Permissions.Where(s => s.PermissionTitle == permissionTitle).FirstOrDefault<Permission>();
                if (getUserPermission != null)
                    return true;
            }
            return false;

        }


    }
}
