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
            _context = context;
        }

        public bool CreateUser(UserEntity user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return true;
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
                UserEntity UserToDelete = _context.Users.Find(username);
                if(UserToDelete != null)
                {
                    _context.Users.Remove(UserToDelete);
                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public UserEntity GetUser(string username)
        {
            return _context.Users.Find(username);
        }

        public bool UpdateUser(UserEntity user)
        {
            try
            {
                if (user != null)
                {
                    _context.SaveChanges();
                    return true;
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
