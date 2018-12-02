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
            throw new NotImplementedException();
        }

        public UserEntity GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public UserEntity UpdateUser(UserEntity user)
        {
            throw new NotImplementedException();
        }
    }
}
