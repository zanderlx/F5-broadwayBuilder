using System;
using DataAccessLayer;
using DataAccessLayer.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ServiceLayer.Test
{
    [TestClass]
    public class AuthorizationTests
    {
        [TestMethod]
        public void AuthorizationService_UserHasPermission_Pass()
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
            var permission = new Permission("CreateUser");

            BroadwayBuilderContext broadwayBuilderContext = new BroadwayBuilderContext();

            var expected = true;
            var actual = false;
            

            var test = new Mock<IPermissionRepository>();
            test
                .Setup(m => m.UserHasPermission(user, permission))
                .Returns(true);

            var service = new AuthorizationService(test.Object);

            //Act 
            actual = service.HasPermission(user,permission);

            //Assert
            Assert.AreEqual(expected, actual);

            
        }

        [TestMethod]
        public void AuthorizationService_UserDoesNotHavePermission_Pass()
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
            var permission = new Permission("CreateUser");

            BroadwayBuilderContext broadwayBuilderContext = new BroadwayBuilderContext();

            var expected = false;
            var actual = true;


            var test = new Mock<IPermissionRepository>();
            test
                .Setup(m => m.UserHasPermission(user, permission))
                .Returns(false);

            var service = new AuthorizationService(test.Object);

            //Act 
            actual = service.HasPermission(user, permission);

            //Assert
            Assert.AreEqual(expected, actual);


        }
    }
}
