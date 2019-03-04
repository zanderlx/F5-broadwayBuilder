using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    [Table("UserPermissions")]
    public class UserPermission
    {
        public UserPermission(string userName, Guid permissionId, Guid theaterId, bool disabled)
        {
            this.UserName = userName;
            this.PermissionID = permissionId;
            this.TheaterID = theaterId;
            this.isEnabled = disabled;
            DateCreated = DateTime.Now; //change
        }
        public UserPermission()
        {
            this.UserName = null;
            this.isEnabled = false;
            DateCreated = DateTime.Now;
        }
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool isEnabled { get; set; }

        [Key]
        [Column(Order =1)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid PermissionID { get; set; }

        [Key]
        [Column(Order = 3)]
        public Guid TheaterID { get; set; }

        public User user { get; set; }
        public Permission permission { get; set; }
        public Theater theater { get; set; }


    }
}
