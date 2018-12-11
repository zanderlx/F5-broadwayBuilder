using System;
using System.Collections.Generic;
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
            this.username = null;
            this.password = null;
            this.dateOfBirth = new DateTime();
            this.city = null;
            this.stateProvince = null;
            this.country = null;
            this.roleType = null;
            this.isEnabled = false;
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
            this.username = email.ToLower();
            this.password = password;
            this.dateOfBirth = dob;
            this.city = city;
            this.stateProvince = stateProvince;
            this.country = country;
            this.roleType = role;
            this.isEnabled = isEnabled;
        }

        [Key]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime dateOfBirth { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string stateProvince { get; set; }

        [Required]
        public string country { get; set; }

        [Required]
        public bool isEnabled { get; set; }

        [Required]
        public string roleType { get; set; }

        [Required]
        public Role role { get; set; }

        public virtual ICollection<Permission> permissions { get; set; }
    }
}
