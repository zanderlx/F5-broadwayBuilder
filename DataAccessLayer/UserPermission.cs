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
        public UserPermission(int userName, int permissionId, int theaterId, bool disabled)
        {
            this.UserId = userName;
            this.PermissionID = permissionId;
            this.TheaterID = theaterId;
            this.isEnabled = disabled;
            DateCreated = DateTime.Now; //change
        }
        public UserPermission()
        {
            //this.UserId = null;
            this.isEnabled = false;
            DateCreated = DateTime.Now;
        }
        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool isEnabled { get; set; }

        [Key]
        [Column(Order =1)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int PermissionID { get; set; }

        [Key]
        [Column(Order = 3)]
        public int TheaterID { get; set; }

        public User user { get; set; }
        public Permission permission { get; set; }
        public Theater theater { get; set; }


    }
}
