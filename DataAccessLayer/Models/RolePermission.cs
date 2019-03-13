using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RolePermission
    {
        public RolePermission(int permissionId, int roleId, bool disabled)
        {
            this.PermissionID = permissionId;
            this.RoleID = roleId;
            this.isEnabled = disabled;
        }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool isEnabled { get; set; }

        [Key]
        [Required]
        [Column(Order =1)]
        public int PermissionID { get; set; }

        [Key]
        [Required]
        [Column(Order = 2)]
        public int RoleID { get; set; }

        public Role role { get; set; }
        public Permission permission { get; set; }
    }
}
