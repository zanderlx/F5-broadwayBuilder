﻿using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using ServiceLayer.Services;

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
            var firstName = "Abi";
            var lastName = "Castro";
            int age = 24;
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var enable = true;

            var user = new User(username, firstName, lastName, age, dob, city, stateProvince, country, enable);

            var expected = true;
            var actual = false;

            var context = new BroadwayBuilderContext();

            var userService = new UserService(context);


            // Act
            userService.CreateUser(user);
            var affectedRows = context.SaveChanges();

            if (affectedRows > 0)
                actual = true;

            // Assert
            userService.DeleteUser(user);
            context.SaveChanges();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UserService_CreateUserAgain_Pass()
        {
            // Arrange
            var username = "abixcastro@gmail.com";
            var firstName = "Abi";
            var lastName = "Castro";
            int age = 24;
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var enable = true;

            var user = new User(username, firstName, lastName, age, dob, city, stateProvince, country, enable);
            //var NewRole = new Role("general");

            // Expected should not pass because
            // you cannot create the same user again
            var expected = false;
            var actual = true;

            var context = new BroadwayBuilderContext();
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
            var roleService = new RoleService(context);

            var username = "abixcastro@gmail.com";
            var firstName = "Abi";
            var lastName = "Castro";
            int age = 24;
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var enable = true;

            var user = new User(username, firstName, lastName, age, dob, city, stateProvince, country, enable);

            userService.CreateUser(user);
            context.SaveChanges();
            user.FirstName = "Lex";
            user.DateOfBirth = new DateTime(1992, 12, 7);
            user.City = "Irvine";

            var expected = user;

            //Act
            var actual = userService.UpdateUser(user);
            context.SaveChanges();

            userService.DeleteUser(user);
            context.SaveChanges();

            //Assert
            Assert.AreEqual(expected.Username, actual.Username);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.Country, actual.Country);
            Assert.AreEqual(expected.City, actual.City);
            Assert.AreEqual(expected.StateProvince, actual.StateProvince);
            Assert.AreEqual(expected.DateOfBirth, actual.DateOfBirth);

        }

        //[TestMethod]
        //public void UpdateUserPrimaryKey_Pass()//NEEDS TO BE UPDATED
        //{
        //    ////Arrange
        //    var context = new BroadwayBuilderContext();
        //    var userService = new UserService(context);

        //    var username = "abixcastro@gmail.com";
        //    var firstName = "Abi";
        //    var lastName = "Castro";
        //    int age = 24;
        //    var dob = new DateTime(1994, 1, 7);
        //    var city = "San Diego";
        //    var stateProvince = "California";
        //    var country = "United States";
        //    var enable = true;

        //    var user = new User(username, firstName, lastName, age, dob, city, stateProvince, country, enable);
        //    userService.CreateUser(user);
        //    context.SaveChanges();


        //    var expected = false;
        //    var actual = true; ;

        //    //Act
        //    try
        //    {
        //        user.Username = "fake@email.com";
        //        context.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        actual = false;
        //    }
        //    //user.Username = "abixcastro@gmail.com";
        //    var testuser = userService.GetUser(user);
        //    userService.DeleteUser(user);
        //    context.SaveChanges();

        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //    //Assert.AreEqual(user.UserId, testuser.UserId);
        //    //Assert.AreEqual(user.Username, testuser.Username);
        //}

        [TestMethod]
        public void DeleteUser_Pass()
        {
            // Arrange
            var context = new BroadwayBuilderContext();
            var userService = new UserService(context);

            var username = "abixcastro@gmail.com";
            var firstName = "Abi";
            var lastName = "Castro";
            int age = 24;
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var enable = true;

            var user = new User(username, firstName, lastName, age, dob, city, stateProvince, country, enable);

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
            var userService = new UserService(context);

            var username = "abixcastro@gmail.com";
            var firstName = "Abi";
            var lastName = "Castro";
            int age = 24;
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var enable = true;

            var user = new User(username, firstName, lastName, age, dob, city, stateProvince, country, enable);

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

        [TestMethod]
        public void EnableUser_Pass()
        {
            //Arrange
            var context = new BroadwayBuilderContext();
            var userService = new UserService(context);

            var username = "abixcastro@gmail.com";
            var firstName = "Abi";
            var lastName = "Castro";
            int age = 24;
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var enable = true;

            var user = new User(username, firstName, lastName, age, dob, city, stateProvince, country, enable);

            userService.CreateUser(user);
            context.SaveChanges();

            var expected = true;
            var actual = false;

            //Act
            User EnabledUser = userService.EnableAccount(user);
            context.SaveChanges();
            actual = EnabledUser.isEnabled;

            userService.DeleteUser(user);
            context.SaveChanges();
            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void DisableUser_Pass()
        {
            //Arrange
            var context = new BroadwayBuilderContext();
            var userService = new UserService(context);

            var username = "abixcastro@gmail.com";
            var firstName = "Abi";
            var lastName = "Castro";
            int age = 24;
            var dob = new DateTime(1994, 1, 7);
            var city = "San Diego";
            var stateProvince = "California";
            var country = "United States";
            var enable = true;

            var user = new User(username, firstName, lastName, age, dob, city, stateProvince, country, enable);

            userService.CreateUser(user);
            context.SaveChanges();

            var expected = false;
            var actual = true;

            //Act
            User DisabledUser = userService.DisableAccount(user);
            context.SaveChanges();
            actual = DisabledUser.isEnabled;

            userService.DeleteUser(user);
            context.SaveChanges();
            //Assert
            Assert.AreEqual(expected, actual);

        }

    }
}

