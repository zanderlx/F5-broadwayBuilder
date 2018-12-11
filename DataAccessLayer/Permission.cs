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
        /// <summary>
        /// The default constructor that will add a null permission
        /// </summary>
        public Permission()
        {
            permissionTitle = null;
        }

        /// <summary>
        /// The permission constructor that will add a new permission
        /// </summary>
        /// <param name="permission"></param>
        public Permission(string permission)
        {
            permissionTitle = permission.ToLower();
        }

        [Key]
        public string permissionTitle { get; set; }

        public virtual ICollection<User> users { get; set; }
    }
}
