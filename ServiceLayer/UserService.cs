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
           
            return _repository.CreateUser(user);
           
        }

        // Read/Get User
        public User GetUser(string username)
        {
            return _repository.GetUser(username);
        }

        // Update User

        //Suggestion - make these their own separate methods. UpdatePassword().. UpdateCity()...etc
        public User UpdateUser(User user) 
        {
            var curUser = _repository.GetUser(user.Username);

            curUser.Role = user.Role; //Make sure it won't run unless the permission is valid
            curUser.StateProvince = user.Password;
            curUser.StateProvince = user.StateProvince;
            curUser.StateProvince = user.Country;
            curUser.StateProvince = user.City;

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
