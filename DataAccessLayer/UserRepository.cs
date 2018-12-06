using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly BroadwayBuilderContext _context;

        public UserRepository(BroadwayBuilderContext context)
        {
            this._context = context;
        }

        public bool CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                int affectedRows = _context.SaveChanges();
                if (affectedRows > 0)
                {
                    return true;
                }

                return false;
            }
            catch(DbUpdateException)
            {
                return false;
            }
        }

        public bool DeleteUser(string username)
        {
            try
            {
                User UserToDelete = _context.Users.Find(username);
                if(UserToDelete != null)
                {
                    _context.Users.Remove(UserToDelete);
                    int affectedRows = _context.SaveChanges();
                    if (affectedRows > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public User GetUser(string username)
        {
            return _context.Users.Find(username);
        }

        public bool UpdateUser(User user)
        {
            try
            {
                if (user != null)
                {
                    int affectedRows = _context.SaveChanges();
                    if (affectedRows > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }
            
        }
    }
}
