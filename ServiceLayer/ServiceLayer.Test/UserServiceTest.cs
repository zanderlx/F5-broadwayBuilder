using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServiceLayer.Test
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void CreateUser()
        {
            //Arrange
            var userService = new UserService();

            var username = "abixcastro@gmail.com";
            var password = "abc123@@@!!!";
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var role = RoleType.GENERAL;

            //Act
            User user = new User(username, password, dob, city, stateProvince, country, role);
            userService.CreateUser(user);

            //Asert
            var userFromService = userService.GetUser(username);
            Assert.AreEqual(username, userFromService.Username);
            Assert.IsNotNull(userFromService);


        }

        [TestMethod]
        public void CreateUser2()
        {
            //Arrange
            var userService = new UserService();

            var username = "abixcastro@gmail.com";
            var password = "abc123@@@!!!";
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var role = RoleType.GENERAL;

            //Act
            User user = new User(username, password, dob, city, stateProvince, country, role);
            userService.CreateUser(user);

            //Asert
            var userFromService = userService.GetUser(username);
            Assert.AreEqual(username, userFromService.Username);
            Assert.IsNotNull(userFromService);

            //Case 2 : User tries to re-register with the same credentials
            userService.CreateUser(user);//should not pass
        }

        [TestMethod]
        public void CreateUser3()
        {
            //Arrange
            var userService = new UserService();

            var username = "abixcastro@gmail.com";
            var password = "abc123@@@!!!";
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var role = RoleType.GENERAL;

            //Act
            User user = new User(username, password, dob, city, stateProvince, country, role);
            userService.CreateUser(user);

            //Asert
            var userFromService = userService.GetUser(username);
            Assert.AreEqual(username, userFromService.Username);
            Assert.IsNotNull(userFromService);

            //Case 3 Test for case sensitive UserName 
            user.Username = "Abixcastro@gmail.com";
            userService.CreateUser(user);//should not pass
        }
    }
}
