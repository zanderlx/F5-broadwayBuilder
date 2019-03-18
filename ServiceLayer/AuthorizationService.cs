using DataAccessLayer;
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
        public bool HasPermission(User user, Permission checkIfAuthorized,Theater theater)
        {
            UserPermission userPermission = _dbContext.UserPermissions.Find(user.UserId, checkIfAuthorized.PermissionID, theater.TheaterID);
            if (userPermission != null)
            {
                return true;
            }
            return false;

        }

        public bool HasPermission(int username, Permission checkIfAuthorized, Theater theater)
        {
            UserPermission userPermission = _dbContext.UserPermissions.Find(username, checkIfAuthorized.PermissionID, theater.TheaterID);
            if (userPermission != null)
            {
                return true;
            }
            return false;

        }


    }
}
