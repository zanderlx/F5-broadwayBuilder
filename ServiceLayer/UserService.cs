using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    /// <summary>
    /// The UserService class deals with how users are managed such as
    /// Creating, Reading, Updating, and Deleting a user
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Readonly limits the field to the only thing that can set it is its constructor.
        /// Private and readonly gives the benefit of not accidentally changing the
        /// field from another part of that class after it is initialized.
        /// </summary>
        private readonly BroadwayBuilderContext _dbContext;

        /// <summary>
        /// Initializes the BroadwayBuilderContext to an instance of the context passed as an argument
        /// </summary>
        /// <param name="context"></param>
        public UserService(BroadwayBuilderContext context)
        {
            this._dbContext = context;
        }

        /// <summary>
        /// CreateUser is a method in the UserService class.
        /// The user gets created in the database.
        /// Safe to assume User will always be valid due to front-end data validation
        /// </summary>
        /// <param name="user">The user that we want to create</param>
        public void CreateUser(User user)
        {
            _dbContext.users.Add(user);
        }

        /// <summary>
        /// GetUser is a method in the UserSerivce class.
        /// </summary>
        /// <param name="username">The username we want to retrieve</param>
        /// <returns>The user that was obtained using the username</returns>
        public User GetUser(string username)
        {
            return _dbContext.users.Find(username);
        }

        /// <summary>
        /// UpdateUser is a method in the UserService class. 
        /// The user gets updated in the database.
        /// </summary>
        /// <param name="user">The user we want to update</param>
        /// <returns>The updated user</returns>
        public User UpdateUser(User user)
        {
            User userToUpdate = _dbContext.users.Find(user.username);
            // If the user found is not null, update the user attributes
            if (userToUpdate != null)
            {
                userToUpdate.password = user.password;
                userToUpdate.stateProvince = user.stateProvince;
                userToUpdate.country = user.country;
                userToUpdate.city = user.city;
                userToUpdate.role = user.role;
            }
            return userToUpdate;
        }

        /// <summary>
        /// DeleteUser is a method in the UserService class.
        /// The user gets deleted from the database.
        /// </summary>
        /// <param name="user">The user we want to delete</param>
        public void DeleteUser(User user)
        {
            User UserToDelete = _dbContext.users.Find(user.username);
            // If the user found is not null, delete the user
            if (UserToDelete != null)
            {
                _dbContext.users.Remove(UserToDelete);
            }
        }

        // TODO: Why do we have another DeleteUser with arugment string
        public void DeleteUser(string user)
        {
            User UserToDelete = _dbContext.users.Find(user);
            // If the user found is not null, delete the user
            if (UserToDelete != null)
            {
                _dbContext.users.Remove(UserToDelete);
            }
        }

        /// <summary>
        /// EnableAccount is a method in the UserService class.
        /// Enables an account of the user.
        /// </summary>
        /// <param name="user">The user whos account we want to enable</param>
        public void EnableAccount(User user)
        {
            User UserToEnable = _dbContext.users.Find(user.username);
            // If the user found is not null, enable the user's account
            if (UserToEnable != null)
            {
                UserToEnable.isEnabled = true;
            }
        }

        /// <summary>
        /// DisableAccount is a method in the UserService class.
        /// Disables the user account using the dbContext
        /// </summary>
        /// <param name="user">The user that we want to disable</param>
        public void DisableAccount(User user)
        {
            User UserToDisable = _dbContext.users.Find(user.username);
            // If the user found is not null, disable the user's account
            if (UserToDisable != null)
            {
                UserToDisable.isEnabled = false;
            }
        }

        /// <summary>
        /// AddUserPermission is a method in the UserService class.
        /// Adds a permission to a specific user.
        /// </summary>
        /// <param name="user">The user who we will be adding a permission to</param>
        /// <param name="permission">The permission we will be adding to a user</param>
        public void AddUserPermission(User user, Permission permission)
        {
            User UserToAddPermission = _dbContext.users.Find(user.username);
            Permission PermissionToAdd = _dbContext.permissions.Find(permission.permissionTitle);

            // If the user and the permission found is not null, add the permission to the user
            if (UserToAddPermission != null && PermissionToAdd != null)
            {
                UserToAddPermission.permissions.Add(PermissionToAdd);
            }
        }

        /// <summary>
        /// DeleteUserPermission is a method in the UserService class.
        /// This method removes the permission 
        /// </summary>
        /// <param name="user">The user whos permission we want to remove</param>
        /// <param name="permission">The permission to be removed from the user</param>
        public void DeleteUserPermission(User user, Permission permission)
        {
            User userToAddPermission = _dbContext.users.Find(user.username);
            Permission permissionToAdd = _dbContext.permissions.Find(permission.permissionTitle);

            // If the user and the permission found is not null, remove the permission from the user
            if (userToAddPermission != null && permissionToAdd != null)
            {
                userToAddPermission.permissions.Remove(permissionToAdd);
            }
        }
    }
}
