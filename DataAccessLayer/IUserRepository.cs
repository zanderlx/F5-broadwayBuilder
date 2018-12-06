using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IUserRepository

    {
        bool CreateUser(User user);
        User GetUser(string username);
        bool UpdateUser(User user);
        bool DeleteUser(string username);

    }
}
