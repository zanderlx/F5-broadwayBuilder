using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserService
    {
 
        /// <summary>
        /// Readonly limits the field to the only thing that can set it is its constructor.
        /// Private and readonly gives the benefit of not
        /// accidentally changing the field from another part of that class after it is initialized.
        /// </summary>
        private readonly BroadwayBuilderContext _dbContext;


        public UserService(BroadwayBuilderContext Context)
        {
            this._dbContext = Context;
        }

        /// <summary>
        /// CreateUser is a method in the UserService class.
        /// Safe to Assume User will always be valid due to data validation
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {

            _dbContext.Users.Add(user);

        }

        /// <summary>
        /// GetUser is a method in the UserSerivce class.
        /// <para>Get User by username</para>
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUser(string username)
        {
            return _dbContext.Users.Find(username);
        }

        /// <summary>
        /// UpdateUser is a method in the UserService class. 
        /// <para>update users properties</para>
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User UpdateUser(User user)
        {
            User userToUpdate = _dbContext.Users.Find(user.Username);
            if (userToUpdate != null)
            {
                userToUpdate.Role = user.Role;
                userToUpdate.Password = user.Password;
                userToUpdate.StateProvince = user.StateProvince;
                userToUpdate.Country = user.Country;
                userToUpdate.City = user.City;
                // TODO: Remove this line:
                // Should not be able to update date of birth
                userToUpdate.DateOfBirth = user.DateOfBirth;
                
            }
            return userToUpdate;

        }

        // Delete User
        // Note: DeleteUser(User user) already has the user. Why find again?
        public void DeleteUser(User user)
        {
            User UserToDelete = _dbContext.Users.Find(user.Username);
            if (UserToDelete != null)
            {
                _dbContext.Users.Remove(UserToDelete);
            }
        }

        public void DeleteUser(string user)
        {
            User UserToDelete = _dbContext.Users.Find(user);
            if (UserToDelete != null)
            {
                _dbContext.Users.Remove(UserToDelete);
            }
        }

        /// <summary>
        /// EnableAccount is a method in the UserService class.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public void EnableAccount(User user)
        {
            User UserToEnable = _dbContext.Users.Find(user.Username);
            if (UserToEnable != null)
            {
                UserToEnable.isEnabled = true;
            }
        }

        /// <summary>
        /// DisableAccount is a method in the UserService class.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public void DisableAccount(User user)
        {
            User UserToDisable = _dbContext.Users.Find(user.Username);
            if (UserToDisable != null)
            {
                UserToDisable.isEnabled = false;
            }
        }

        public void AddUserPermission(User user, Permission permission)
        {
            User UserToAddPermission = _dbContext.Users.Find(user.Username);
            Permission PermissionToAdd = _dbContext.Permissions.Find(permission.PermissionTitle);

            if(UserToAddPermission!=null && PermissionToAdd!=null)
            {
                UserToAddPermission.Permissionss.Add(PermissionToAdd);
            }
        }

        public void DeleteUserPermission(User user, Permission permission)
        {
            User UserToAddPermission = _dbContext.Users.Find(user.Username);
            Permission PermissionToAdd = _dbContext.Permissions.Find(permission.PermissionTitle);

            if (UserToAddPermission != null && PermissionToAdd != null)
            {
                UserToAddPermission.Permissionss.Remove(PermissionToAdd);
            }
        }
    }
}
