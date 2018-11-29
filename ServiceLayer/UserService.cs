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
            //User will always be valid when this code is called upon
           
                string name = user.Username.ToLower();
                user.Username = name;
                return _repository.CreateUser(user);
           
        }

        // Read/Get User
        public User GetUser(string username)
        {
            return _repository.GetUser(username);
        }

        // Update User
        public User UpdateUser(User user, string password, string city, string stateProvince, string country) 
        {
            return _repository.UpdateUser(user);
        }

        // Delete User
        public bool DeleteUser(string username)
        {
            return _repository.DeleteUser(username);
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
    }
}
