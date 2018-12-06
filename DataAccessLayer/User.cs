using DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    [Table("Users")]
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

        // Constructor
        public User()
        {

        }

        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public RoleType Role { get; set; }

        //public virtual ICollection<Permission> Permissionss { get; set; }
    }
}
