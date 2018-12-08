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
        private readonly IUserRepository _repository;

        // Constructor
        public UserService(BroadwayBuilderContext Context)
        {
            _repository = new UserRepository(Context);
        }

        // Create User
        //User will always be valid due to data validation
        public bool CreateUser(User user)
        {

            return _repository.CreateUser(user);

        }

        // Read/Get User
        public User GetUser(string username)
        {
            var userEntity = _repository.GetUser(username);
            //var userReturned = new UserEntity(user);

            return userEntity;
        }

        // Update User

        //Suggestion - make these their own separate methods. UpdatePassword().. UpdateCity()...etc
        public User UpdateUser(User user)
        {
            var curUser = _repository.GetUser(user.Username);
            if (curUser != null)
            {
                curUser.Role = user.Role;
                curUser.Password = user.Password;
                curUser.StateProvince = user.StateProvince;
                curUser.Country = user.Country;
                curUser.City = user.City;
                curUser.DateOfBirth = user.DateOfBirth;

                if (_repository.UpdateUser(curUser))
                    return curUser;
            }
            return null;

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
