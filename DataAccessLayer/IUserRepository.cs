using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IUserRepository

    {
        bool CreateUser(UserEntity user);
        UserEntity GetUser(string username);
        bool UpdateUser(UserEntity user);
        bool DeleteUser(string username);

    }
}
