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

        // Constructor
        public PermissionService(BroadwayBuilderContext Context)
        {
            _repository = new PermissionRepository(Context);
        }

        public bool CreatePermission(Permission permission)
        {

            return _repository.CreatePermission(permission);

        }

        public bool DeletePermission(Permission permission)
        {

            return _repository.DeletePermission(permission);

        }
    }
}
