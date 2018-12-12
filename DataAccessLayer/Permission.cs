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
        [Key]
        public string PermissionTitle { get; set; }

        public virtual ICollection<User> Users { get; set; }

        /// <summary>
        /// The default constructor that will add a null permission
        /// </summary>
        public Permission()
        {
            PermissionTitle = null;
        }

        /// <summary>
        /// The permission constructor that will add a new permission
        /// </summary>
        /// <param name="permission"></param>
        public Permission(string permission)
        {
            PermissionTitle = permission.ToLower();
        }
    }
}
