using DataAccessLayer;
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
        private readonly IUserRepository _repository;

        // Constructor
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        // Create User
        //User will always be valid due to data validation
        public bool CreateUser(User user)
        {
            var userEntity = new UserEntity()
            {
                Username = user.Username,
                City = user.City,
                Country = user.Country,
                DateOfBirth = user.DateOfBirth,
                Password = user.Password,
                Role = user.Role,
                StateProvince = user.StateProvince
            };

            return _repository.CreateUser(userEntity);
           
        }

        // Read/Get User
        public User GetUser(string username)
        {
            var userEntity = _repository.GetUser(username);
            var userReturned = new User(userEntity);

            return userReturned;
        }

        // Update User

        //Suggestion - make these their own separate methods. UpdatePassword().. UpdateCity()...etc
        public User UpdateUser(User user) 
        {
            var curUser = _repository.GetUser(user.Username);

            curUser.Role = user.Role;
            curUser.StateProvince = user.Password;
            curUser.StateProvince = user.StateProvince;
            curUser.StateProvince = user.Country;
            curUser.StateProvince = user.City;

            return new User(curUser);
       
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
