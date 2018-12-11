using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    [Table("Permissions")]
    public class Permission
    {
        public Permission(string permission)
        {
            PermissionTitle = permission.ToLower();
        }
        public Permission()
        {

        }
        [Key]
        public string PermissionTitle { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
