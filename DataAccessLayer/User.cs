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
        public User(string email, string password, DateTime dob, string city, string stateProvince, string country, string role,bool isEnable)
        {
            Username = email.ToLower();
            Password = password;
            DateOfBirth = dob;
            City = city;
            StateProvince = stateProvince;
            Country = country;
            RoleType = role;
            isEnabled = isEnable;
        }

        // Constructor
        public User()
        {

        }

        [Key]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string StateProvince { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public bool isEnabled { get; set; }

        public string RoleType { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<Permission> Permissionss { get; set; }
    }
}
