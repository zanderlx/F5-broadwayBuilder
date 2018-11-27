using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer.Enums;
using ServiceLayer.Models;

namespace ServiceLayer.Test
{
    [TestClass]
    public class AuthorizationTests
    {
        [TestMethod]
        public void Authorization_CheckUserRoleGeneral_Pass()
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

            var expected = "GENERAL";
            var actual = "";

            var service = new Authorization();

            // Act
            // Get actual user role
            actual = service.CheckUserRole(user);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authorization_CheckUserRoleAdmin_Pass()
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

            var expected = "THEATRE_ADMIN";
            var actual = "";


            var service = new Authorization();

            // Act
            // Get actual user role
            actual = service.CheckUserRole(user);

            // Assert
            Assert.AreNotEqual(expected, actual);
        }
    }
}
