using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PermissionRepository : IPermissionRepository
    {
        public PermissionRepository(BroadwayBuilderContext context)
        {

        }
        public bool CreatePermission(Permission user)
        {
            throw new NotImplementedException();
        }

        public bool DeletePermission(Permission username)
        {
            throw new NotImplementedException();
        }

        public Permission GetPermission(string username)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePermission(Permission user)
        {
            throw new NotImplementedException();
        }

        public bool UserHasPermission(User user, Permission permission)
        {
            throw new NotImplementedException();
        }
    }
}
