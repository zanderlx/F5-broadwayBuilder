using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class RoleService
    {
        private readonly BroadwayBuilderContext _dbContext;

        public RoleService(BroadwayBuilderContext dbcontext)
        {
            this._dbContext = dbcontext;
        }

        public void CreateRole(Role role)
        {
            _dbContext.Roles.Add(role);
        }

        public Role GetRole(string role)
        {
            return _dbContext.Roles.Find(role);
        }

        public void DeleteRole(Role role)
        {

            Role RoleToDelete = _dbContext.Roles.Find(role.RoleType);
            if (RoleToDelete != null)
            {
                _dbContext.Roles.Remove(RoleToDelete);
            }

        }
    }
}
