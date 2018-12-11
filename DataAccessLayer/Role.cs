using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    [Table("Roles")]
    public class Role
    {
        public Role(string role)
        {
            RoleType = role;
        }

        public Role()
        {

        }
        [Key]
        public string RoleType { get; set; } 

        public ICollection<User> User { get; set; }
    }
}
