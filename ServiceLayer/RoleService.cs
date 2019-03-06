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

        /// <summary>
        /// CreateRole is a method in the RoleService class.
        /// This enables us to create a new role in the DB if necessary
        /// </summary>
        /// <param name="role">The new role we want to create</param>
        public void CreateRole(Role role)
        {
            role.DateCreated = DateTime.Now;
            _dbContext.Roles.Add(role);
        }

        /// <summary>
        /// GetRole is a method in the RoleService class.
        /// This enables us to retrieve a role from the DB if necessary.
        /// </summary>
        /// <param name="role">The role we want to retrieve</param>
        /// <returns></returns>
        public Role GetRole(Guid role)
        {
            return _dbContext.Roles.Find(role);
        }

        /// <summary>
        /// DeleteRole is a method in the the RoleService class.
        /// This enables us to delete a role from the DB if necessary.
        /// </summary>
        /// <param name="role">The role that we want to delete</param>
        public void DeleteRole(Role role)
        {

            Role RoleToDelete = _dbContext.Roles.Find(role.RoleID);
            if (RoleToDelete != null)
            {
                _dbContext.Roles.Remove(RoleToDelete);
            }

        }
    }
}
