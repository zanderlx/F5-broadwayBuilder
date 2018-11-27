using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Enums;
using ServiceLayer.Models;

namespace ServiceLayer.Test
{
    [TestClass]
    public class UserManagementTests
    {
        [TestMethod]
        public void UserManagement_CreateUser_Pass()
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

            var expected = true;
            var actual = false;

            // Create a fake IUserRepository object using Moq
            var repository = new Mock<IUserRepository>();

            // Set up the repo in order to return exactly
            // what we expect
            repository
                .Setup(m => m.CreateUser(user))
                .Returns(true);

            var service = new UserService(repository.Object);

            // Act
            actual = service.CreateUser(user);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UserManagement_CreateUserAgain_Pass()
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

            // Create a fake IUserRepository object using Moq
            var repository = new Mock<IUserRepository>();

            // Set up the repo in order to return exactly
            // what we expect
            repository
                .Setup(m => m.CreateUser(user))
                .Returns(true);

            var service = new UserService(repository.Object);

            // Act
            // Create user the first time
            var createUserFirstTime = service.CreateUser(user);

            // Create user again
            actual = service.CreateUser(user);

            // Assert
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void UserManagement_CheckNullUser_Pass()
        {
            // Arrange
            User user = null;
            var expected = false;
            var actual = false;

            // Create a fake IUserRepository object using Moq
            var repository = new Mock<IUserRepository>();

            // Set up the repo in order to return exactly
            // what we expect
            repository
                .Setup(m => m.CreateUser(user))
                .Returns(false);

            var service = new UserService(repository.Object);

            // Act
            actual = service.CreateUser(user);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // TODO: Create more test cases for UserManagement
        // TODO: Exception thrown from repository
        // TODO: UpdateUser() Test
        // 
    }
}
