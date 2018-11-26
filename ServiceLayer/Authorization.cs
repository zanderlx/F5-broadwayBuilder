using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class Authorization
    {
        private IAuthorizable _authorization;

        public Authorization(IAuthorizable authorization)
        {
            _authorization = authorization;
        }

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
    }
}
