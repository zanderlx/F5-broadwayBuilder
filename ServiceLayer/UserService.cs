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
        public User UpdateUser(string username)
        {
            return _repository.UpdateUser(username);
        }

        // Delete User
        public bool DeleteUser(string username)
        {
            return _repository.DeleteUser(username);
        }

        // TODO: Create more methods that a user uses
        // OLD METHODS - COMMENTED BECAUSE WANTED TO JUST HAVE CRUD OPS
        // Uncomment these if you want to use them
        /*
        public void UpdatePassword(string username, string password)
        {
            var user = _userRepository.GetUser(username);
            user.Password = password;

            _userRepository.UpdateUser(user);
        }

        public void UpdateCity(string username, string city)
        {
            var user = _userRepository.GetUser(username);
            user.City = city;

            _userRepository.UpdateUser(user);
        }
        */
    }
}
