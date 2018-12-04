using DataAccessLayer;
using DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class User
    {
        // Constructor
        public User(string email, string password, DateTime dob, string city, string stateProvince, string country, RoleType role)
        {
            Username = email.ToLower(); 
            Password = password;
            DateOfBirth = dob;
            City = city;
            StateProvince = stateProvince;
            Country = country;
            Role = role;
        }

        public User(UserEntity userEntity)
        {
            Username = userEntity.Username;
            Password = userEntity.Password;
            DateOfBirth = userEntity.DateOfBirth;
            City = userEntity.City;
            StateProvince = userEntity.StateProvince;
            Country = userEntity.Country;
            Role = userEntity.Role;
        }

        // Defining Auto-Properties
        public string Username { get; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public RoleType Role { get; set; }
    }


}
