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
        //private readonly BroadwayBuilderContext _context;
        //public PermissionRepository(BroadwayBuilderContext context)
        //{
        //    this._context = context;
        //}

        ////public bool CreatePermission(Permission user)
        ////{
        ////    try
        ////    {
        ////        _context.Permissions.Add(user);
        ////        int affectedRows = _context.SaveChanges();
        ////        if (affectedRows > 0)
        ////        {
        ////            return true;
        ////        }

        ////        return false;
        ////    }
        ////    catch (DbUpdateException)
        ////    {
        ////        return false;
        ////    }
        ////}

        //public bool DeletePermission(Permission permission)
        //{
        //    try
        //    {
        //        Permission PermissionToDelete = _context.Permissions.Find(permission);
        //        if (PermissionToDelete != null)
        //        {
        //            _context.Permissions.Remove(PermissionToDelete);
        //            int affectedRows = _context.SaveChanges();
        //            if (affectedRows > 0)
        //            {
        //                return true;
        //            }
        //        }

        //        return false;
        //    }
        //    catch (DbUpdateException)
        //    {
        //        return false;
        //    }

        //}

        ////public Permission GetPermission(string permissionTitle)
        ////{
        ////    return _context.Permissions.Find(permissionTitle);
        ////}

        //public bool UpdatePermission(Permission permission)
        //{
        //    try
        //    {
        //        if (permission != null)
        //        {
        //            int affectedRows = _context.SaveChanges();
        //            if (affectedRows > 0)
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //    catch (DbUpdateException)
        //    {
        //        return false;
        //    }
        //}

        //public bool UserHasPermission(User user, Permission permission)
        //{
        //    throw new NotImplementedException();
        //}

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
