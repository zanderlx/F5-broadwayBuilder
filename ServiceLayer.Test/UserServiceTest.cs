using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer.Enums;
using DataAccessLayer;

namespace ServiceLayer.Test
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void UserService_CreateUser_Pass()
        {
            // Arrange
            var username = "abixcastro@gmail.com";
            var password = "abc123@@@!!!";
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var role = RoleType.GENERAL;

            var user = new User(username, password, dob, city, stateProvince, country, role);

            var expected = true;
            var actual = false;

            var context = new BroadwayBuilderContext();

            var service = new UserService(context);

            // Act
            actual = service.CreateUser(user);

            // Assert
            Assert.AreEqual(expected, actual);
            service.DeleteUser(user.Username);
        }

        [TestMethod]
        public void UserService_CreateUserAgain_Pass() //CreateUser_duplicateUsername_ThrowException()
        {
            // Arrange
            var username = "abixcastro@gmail.com";
            var password = "abc123@@@!!!";
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var role = RoleType.GENERAL;

            User user = new User(username, password, dob, city, stateProvince, country, role);

            // Expected should not pass because
            // you cannot create the same user again
            var expected = false;
            var actual = false;

            var context = new BroadwayBuilderContext();
            //var repository = new UserRepository(context);
            var service = new UserService(context);

            // Act
            // Create user the first time
            var createUserFirstTime = service.CreateUser(user);

            // Create user again
            actual = service.CreateUser(user);

            // Assert
            Assert.AreEqual(expected, actual);
            service.DeleteUser(user.Username);
        }

        [TestMethod]
        public void UpdateUser_Pass()//NEEDS TO BE UPDATED
        {
            //Arrange
            var context = new BroadwayBuilderContext();
            //var repository = new UserRepository(context);
            var userService = new UserService(context);

            var username = "abixcastro@gmail.com";
            var password = "abc123@@@!!!";
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var role = RoleType.GENERAL;
            

            User user = new User(username, password, dob, city, stateProvince, country, role);

            userService.CreateUser(user);
            user.Password = "h@rDt0GeU$$P@$$word!!!";
            user.DateOfBirth= new DateTime(1992, 12, 7);
            user.City= "Irvine";


            var expected = user;
            //var actual = null;

            //Act
            var actual = userService.UpdateUser(user);

            //Assert
            Assert.AreEqual(expected.Username, actual.Username);
            Assert.AreEqual(expected.Password, actual.Password);
            Assert.AreEqual(expected.Role, actual.Role);
            Assert.AreEqual(expected.Country, actual.Country);
            Assert.AreEqual(expected.City, actual.City);
            Assert.AreEqual(expected.StateProvince, actual.StateProvince);
            Assert.AreEqual(expected.DateOfBirth, actual.DateOfBirth);


            userService.DeleteUser(user.Username);

        }

        //[TestMethod]
        //public void UpdateUserPrimaryKey_Pass()//NEEDS TO BE UPDATED
        //{
        //    ////Arrange
        //    var context = new BroadwayBuilderContext();
        //    ////var repository = new UserRepository(context);
        //    var userService = new UserService(context);

        //    var username = "abixcastro@gmail.com";
        //    var password = "abc123@@@!!!";
        //    var dob = new DateTime(1994, 1, 7);
        //    var city = "San Diego";
        //    var stateProvince = "California";
        //    var country = "United States";
        //    var role = RoleType.GENERAL;


        //    User user = new User(username, password, dob, city, stateProvince, country, role);

        //    userService.CreateUser(user);
        //    user.Username = "fakeemail@gmail.com";


        //    var expected = false;
        //    var actual = true; ;

        //    //Act
        //    var updatedUser = userService.UpdateUser(user);

        //    if (updatedUser == null)
        //    {
        //        actual = false;
        //    }

        //    //Assert
        //    Assert.AreEqual(expected, actual);

        //    user.Username = "abixcastro@gmail.com";
        //    userService.DeleteUser(user.Username);
        //    //userService.DeleteUser("abixcastro@gmail.com");
        //    //userService.DeleteUser("fakeemail@gmail.com");

        //}

        [TestMethod]
        public void DeleteUser_Pass()
        {
            // Arrange
            var context = new BroadwayBuilderContext();
            //var repository = new UserRepository(context);
            var userService = new UserService(context);
            
            var username = "abixcastro@gmail.com";
            var password = "abc123@@@!!!";
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var role = RoleType.GENERAL;

            var user = new User(username, password, dob, city, stateProvince, country, role);

            userService.CreateUser(user);

            var expected = true;
            var actual = false;

            //Act
            actual = userService.DeleteUser(user.Username);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteUserAgain_Pass()
        {
            // Arrange
            var context = new BroadwayBuilderContext();
            //var repository = new UserRepository(context);
            var userService = new UserService(context);

            var username = "abixcastro@gmail.com";
            var password = "abc123@@@!!!";
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var role = RoleType.GENERAL;

            var user = new User(username, password, dob, city, stateProvince, country, role);

            userService.CreateUser(user);
            userService.DeleteUser(user.Username);

            var expected = false;
            var actual = false;

            //Act
            actual = userService.DeleteUser(user.Username);

            //Assert
            Assert.AreEqual(expected, actual);
        }



        // TODO: Create more test cases for UserManagement
        // TODO: Exception thrown from repository
        // TODO: UpdateUser() Test
        // 
    }
}
