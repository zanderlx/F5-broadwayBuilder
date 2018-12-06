using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PermissionRepository
    {
        private readonly BroadwayBuilderContext _context;
        public PermissionRepository(BroadwayBuilderContext context)
        {
            this._context = context;
        }

        //public bool CreatePermission(Permission user)
        //{

        //}

        //public bool DeletePermission(string username)
        //{

        //}

        //public UserEntity GetUser(string username)
        //{

        //}

        //public User UpdateUser(User user)
        //{

        //}

    }
}
