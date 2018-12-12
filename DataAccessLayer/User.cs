using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer
{
    [Table("Users")]
    public class User
    {
        /// <summary>
        /// The defauly constructor that the User instance needs to work.
        /// Sets all the variables to be null.
        /// </summary>
        public User()
        {
            this.Username = null;
            this.Password = null;
            this.DateOfBirth = new DateTime();
            this.City = null;
            this.StateProvince = null;
            this.Country = null;
            this.RoleType = null;
            this.IsEnabled = false;
        }

        /// <summary>
        /// The constructor for creating a new User instance.
        /// </summary>
        /// <param name="email">The username that a user will use</param>
        /// <param name="password">The password of the user</param>
        /// <param name="dob">The date of birth of the user</param>
        /// <param name="city">The city that the user lives at</param>
        /// <param name="stateProvince">The state or province that the user lives at</param>
        /// <param name="country">The country that the user lives at</param>
        /// <param name="role">The role that the user will have</param>
        /// <param name="isEnabled">The status that the user account can have</param>
        public User(string email, string password, DateTime dob, string city, string stateProvince, string country, string role, bool isEnabled)
        {
            this.Username = email.ToLower();
            this.Password = password;
            this.DateOfBirth = dob;
            this.City = city;
            this.StateProvince = stateProvince;
            this.Country = country;
            this.RoleType = role;
            this.IsEnabled = isEnabled;
            Permissions = new Collection<Permission>();
        }

        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string StateProvince { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        [Required]
        public string RoleType { get; set; }

        [Required]
        public Role Role { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
