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
        private readonly BroadwayBuilderContext _context;

        // Constructor
        public UserService(BroadwayBuilderContext Context)
        {
            this._context = Context;
        }

        // Create User
        //User will always be valid due to data validation
        public void CreateUser(User user)
        {

            _context.Users.Add(user);

        }

        // Read/Get User
        public User GetUser(string username)
        {
            return _context.Users.Find(username);
        }

        // Update User

        //Suggestion - make these their own separate methods. UpdatePassword().. UpdateCity()...etc
        public User UpdateUser(User user)
        {
            User userToUpdate = _context.Users.Find(user.Username);
            if (userToUpdate != null)
            {
                userToUpdate.Role = user.Role;
                userToUpdate.Password = user.Password;
                userToUpdate.StateProvince = user.StateProvince;
                userToUpdate.Country = user.Country;
                userToUpdate.City = user.City;
                userToUpdate.DateOfBirth = user.DateOfBirth;
                
            }
            return userToUpdate;

        }

        // Delete User
        public void DeleteUser(User user)
        {
            User UserToDelete = _context.Users.Find(user.Username);
            if (UserToDelete != null)
            {
                _context.Users.Remove(UserToDelete);
            }
        }

        public void DeleteUser(string user)
        {
            User UserToDelete = _context.Users.Find(user);
            if (UserToDelete != null)
            {
                _context.Users.Remove(UserToDelete);
            }
        }

        // Admin Permission - Enable Account
        public bool EnableAccount(string username)
        {
            return true;
        }

        // Admin Permission - Disable Account
        public bool DisableAccount(string username)
        {
            return true;
        }

        //public bool AddPermission(User user, Permission permission)
        //{
        //    return _repository.AddPermissionToUser(permission, user);
        //}

        //public bool DeletePermission(User user, Permission permission)
        //{
        //    return _repository.AddPermissionToUser(permission, user);
        //}
    }
}
