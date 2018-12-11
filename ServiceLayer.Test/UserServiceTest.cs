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
            var role = "general";
            var enable = true;

            var user = new User(username, password, dob, city, stateProvince, country, role,enable);
            var NewRole = new Role("general");

            var expected = true;
            var actual = false;

            var context = new BroadwayBuilderContext();

            var userService = new UserService(context);
            var roleService = new RoleService(context);


            // Act
            roleService.CreateRole(NewRole);
            context.SaveChanges();
            userService.CreateUser(user);
            var affectedRows = context.SaveChanges();

            if (affectedRows > 0)
                actual = true;

            // Assert
            userService.DeleteUser(user);
            roleService.DeleteRole(NewRole);
            context.SaveChanges();
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UserService_CreateUserAgain_Pass()
        {
            // Arrange
            var username = "abixcastro@gmail.com";
            var password = "abc123@@@!!!";
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var role = "general";
            var enable = true;

            var user = new User(username, password, dob, city, stateProvince, country, role, enable);

            // Expected should not pass because
            // you cannot create the same user again
            var expected = false;
            var actual = true;

            var context = new BroadwayBuilderContext();
            //var repository = new UserRepository(context);
            var service = new UserService(context);

            // Act
            // Create user the first time
            service.CreateUser(user);
            context.SaveChanges();
            // Create user again
            service.CreateUser(user);
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                actual = false;
            }

            // Assert
            context = new BroadwayBuilderContext();
            service = new UserService(context);
            service.DeleteUser(user);
            context.SaveChanges();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateUser_Pass()
        {
            //Arrange
            var context = new BroadwayBuilderContext();
            var userService = new UserService(context);

            var username = "abixcastro@gmail.com";
            var password = "abc123@@@!!!";
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var role = "general";
            var enable = true;

            var user = new User(username, password, dob, city, stateProvince, country, role, enable);

            userService.CreateUser(user);
            context.SaveChanges();
            user.password = "h@rDt0GeU$$P@$$word!!!";
            user.dateOfBirth = new DateTime(1992, 12, 7);
            user.city = "Irvine";


            var expected = user;

            //Act
            var actual = userService.UpdateUser(user);
            context.SaveChanges();

            userService.DeleteUser(user);
            context.SaveChanges();

            //Assert
            Assert.AreEqual(expected.username, actual.username);
            Assert.AreEqual(expected.password, actual.password);
            Assert.AreEqual(expected.Role, actual.Role);
            Assert.AreEqual(expected.country, actual.country);
            Assert.AreEqual(expected.city, actual.city);
            Assert.AreEqual(expected.stateProvince, actual.stateProvince);
            Assert.AreEqual(expected.dateOfBirth, actual.dateOfBirth);

        }

        [TestMethod]
        public void UpdateUserPrimaryKey_Pass()//NEEDS TO BE UPDATED
        {
            ////Arrange
            var context = new BroadwayBuilderContext();
            var userService = new UserService(context);

            var username = "abixcastro@gmail.com";
            var password = "abc123@@@!!!";
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var role = "general";
            var enable = true;

            var user = new User(username, password, dob, city, stateProvince, country, role, enable);

            userService.CreateUser(user);
            context.SaveChanges();


            var expected = false;
            var actual = true; ;

            //Act
            try
            {
                user.username = "fakeemail@gmail.com";
                context.SaveChanges();
            }
            catch (Exception)
            {
                actual = false;
            }
            user.username = "abixcastro@gmail.com";
            userService.DeleteUser(user);
            context.SaveChanges();

            //Assert
            Assert.AreEqual(expected, actual);
        }

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
            var country = "United States";
            var stateProvince = "California";
            var role = "general";
            var enable = true;

            var user = new User(username, password, dob, city, stateProvince, country, role, enable);

            userService.CreateUser(user);
            context.SaveChanges();

            var expected = true;
            var actual = false;

            //Act
            userService.DeleteUser(user);
            var save = context.SaveChanges();
            if (save > 0)
                actual = true;
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
            var role = "general";
            var enable = true;

            var user = new User(username, password, dob, city, stateProvince, country, role, enable);

            userService.CreateUser(user);
            context.SaveChanges();
            userService.DeleteUser(user);
            context.SaveChanges();

            var expected = false;
            var actual = true;

            //Act
            userService.DeleteUser(user);
            var save = context.SaveChanges();
            if (save == 0)
            {
                actual = false;
            }

            //Assert
            Assert.AreEqual(expected, actual);
        }



    }
}
