using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class PermissionService
    {
        private readonly IPermissionRepository _Repository;
        private readonly BroadwayBuilderContext _DbContext;

        public PermissionService(BroadwayBuilderContext context)
        {
            this._DbContext = context;
            _Repository = new PermissionRepository(context);
        }

        public void CreatePermission(Permission permission)
        {
            _DbContext.Permissions.Add(permission);
        }

        public Permission GetUser(string permission)
        {
            return _DbContext.Permissions.Find(permission);
        }

        public void DeletePermission(Permission permission)
        {
            Permission permissionToDelete = _DbContext.Permissions.Find(permission.PermissionTitle);

            if (permissionToDelete != null)
            {
                _DbContext.Permissions.Remove(permissionToDelete);
            }

        }
    }
}
