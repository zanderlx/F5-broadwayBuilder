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
        // Declared a readonly context for usage of the database
        private readonly BroadwayBuilderContext _DbContext;

        /// <summary>
        /// The RoleService constructor that enables us to Create, Get, and Delete a role
        /// </summary>
        /// <param name="dbContext"></param>
        public RoleService(BroadwayBuilderContext dbContext)
        {
            this._DbContext = dbContext;
        }

        /// <summary>
        /// CreateRole is a method in the RoleService class.
        /// This enables us to create a new role in the DB if necessary
        /// </summary>
        /// <param name="role">The new role we want to create</param>
        public void CreateRole(Role role)
        {
            _DbContext.Roles.Add(role);
        }

        /// <summary>
        /// GetRole is a method in the RoleService class.
        /// This enables us to retrieve a role from the DB if necessary.
        /// </summary>
        /// <param name="role">The role we want to retrieve</param>
        /// <returns></returns>
        public Role GetRole(string role)
        {
            return _DbContext.Roles.Find(role);
        }

        /// <summary>
        /// DeleteRole is a method in the the RoleService class.
        /// This enables us to delete a role from the DB if necessary.
        /// </summary>
        /// <param name="role">The role that we want to delete</param>
        public void DeleteRole(Role role)
        {
            Role roleToDelete = _DbContext.Roles.Find(role.RoleType);
            if (roleToDelete != null)
            {
                _DbContext.Roles.Remove(roleToDelete);
            }
        }
    }
}
