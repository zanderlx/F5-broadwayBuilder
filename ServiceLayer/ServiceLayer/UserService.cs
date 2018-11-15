using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserService
    {
        /*private and readonly gives the benefit of not being able to accidentally change the field from another part of that class after it is initialized.
         * readonly limits the field to the only thing that can set it is the constructor...
         google it to go more into detail*/
        private readonly TemporaryUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new TemporaryUserRepository();
        }

        public User GetUser(string username)
        {
            return _userRepository.GetUser(username);
        }

        public void CreateUser(User user)
        {
            string name = user.Username.ToLower();
            user.Username = name;
            _userRepository.CreateUser(user);

        }

        public void UpdatePassword(string username, string password)
        {
            var user = _userRepository.GetUser(username);
            user.Password = password;

            _userRepository.UpdateUser(user);
        }

        public void UpdateCity(string username, string city)
        {
            var user = _userRepository.GetUser(username);
            user.City = city;

            _userRepository.UpdateUser(user);
        }

        //add more methods below

        // Lex
        public void PurchaseTicket(User user)
        {
            _userRepository.PurchaseShow(user);
        }

        // Lex
        public void LeaveReview(string username)
        {
            _userRepository.MakeReview(username);
        }
    }
}
