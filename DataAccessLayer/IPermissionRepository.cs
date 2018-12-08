using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IPermissionRepository
    {
        bool CreatePermission(Permission user);
        Permission GetPermission(string username);
        bool UpdatePermission(Permission user);
        bool DeletePermission(Permission username);
        bool UserHasPermission(User user, Permission permission);
    }
}
