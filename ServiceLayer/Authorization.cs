using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class Authorization : IAuthorization
    {
        // Checks user's role
        public string CheckUserRole(User user)
        {
            if (user.Role.Equals(RoleType.SYS_ADMIN))
                return "SYS_ADMIN";
            else if (user.Role.Equals(RoleType.THEATRE_ADMIN))
                return "THEATRE_ADMIN";
            else
                return "GENERAL";
        }

        public string HasPermission(User user)
        {
            throw new NotImplementedException();
        }

        //emulating a db
        private Dictionary<Guid, User> _rolePermissions { get; set; }

        public Authorization()
        {
            _rolePermissions = new Dictionary<RoleType, ;
        }

    }
}
