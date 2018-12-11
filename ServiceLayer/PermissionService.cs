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
        private readonly IPermissionRepository _repository;
        private readonly BroadwayBuilderContext _dbContext;

        // Constructor
        public PermissionService(BroadwayBuilderContext Context)
        {
            this._dbContext = Context;
            _repository = new PermissionRepository(Context);
        }

        public void CreatePermission(Permission permission)
        {

            _dbContext.Permissions.Add(permission);

        }

        public Permission GetUser(string permission)
        {
            return _dbContext.Permissions.Find(permission);
        }

        public void DeletePermission(Permission permission)
        {

            Permission permissionToDelete = _dbContext.Permissions.Find(permission.PermissionTitle);
            if (permissionToDelete != null)
            {
                _dbContext.Permissions.Remove(permissionToDelete);
            }

        }
    }
}
