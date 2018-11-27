using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IUserRepository
    {
        bool CreateUser(User user);
        User GetUser(string username);
        User UpdateUser(string username);
        bool DeleteUser(string username);
    }
}
