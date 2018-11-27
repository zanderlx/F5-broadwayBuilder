using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserService
    {
        private IUserRepository _repository;

        // Constructor
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        // Create User
        public bool CreateUser(User user)
        {
            // Convert username (email) to all lowercase
            // This is to prevent same email regardless of letter case
            if (user != null)
            {
                string name = user.Username.ToLower();
                user.Username = name;
                return _repository.CreateUser(user);
            }
            return false;
        }

        // Read/Get User
        public User GetUser(string username)
        {
            return _repository.GetUser(username);
        }

        // Update User
        public User UpdateUser(string username)
        {
            return _repository.UpdateUser(username);
        }

        // Delete User
        public bool DeleteUser(string username)
        {
            return _repository.DeleteUser(username);
        }

        // Admin Permission - Enable Account
        public bool EnableAccount(User account)
        {
            return true;
        }

        // Admin Permission - Disable Account
        public bool DisableAccount(User account)
        {
            return true; 
        }
    }
}
