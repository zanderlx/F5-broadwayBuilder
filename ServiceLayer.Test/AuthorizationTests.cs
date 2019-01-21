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
            var role = "general";
            var enable = true;

            var user = new User(username, password, dob, city, stateProvince, country, role, enable);
            var permission = new Permission("CreateUser");
            user.Permissions.Add(permission);
            var NewRole = new Role("general");

            BroadwayBuilderContext broadwayBuilderContext = new BroadwayBuilderContext();

            var expected = true;
            var actual = false;
            

            var service = new AuthorizationService(broadwayBuilderContext);
            var userService = new UserService(broadwayBuilderContext);
            var roleService = new RoleService(broadwayBuilderContext);
            var permissionService = new PermissionService(broadwayBuilderContext);

            //Adding data into tables
            permissionService.CreatePermission(permission);
            broadwayBuilderContext.SaveChanges();
            roleService.CreateRole(NewRole);
            broadwayBuilderContext.SaveChanges();
            userService.CreateUser(user);
            broadwayBuilderContext.SaveChanges();

            // Act 
            actual = service.HasPermission(user,permission);

            
            userService.DeleteUserPermission(user, permission);
            userService.DeleteUser(user);
            roleService.DeleteRole(NewRole);
            permissionService.DeletePermission(permission);
            broadwayBuilderContext.SaveChanges();

            // Assert
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
            var role = "general";
            var enable = true;

            var user = new User(username, password, dob, city, stateProvince, country, role, enable);
            var permission = new Permission("CreateUser");
            var NewRole = new Role("general");

            BroadwayBuilderContext broadwayBuilderContext = new BroadwayBuilderContext();

            var expected = false;
            var actual = true;


            var service = new AuthorizationService(broadwayBuilderContext);
            var userService = new UserService(broadwayBuilderContext);
            var roleService = new RoleService(broadwayBuilderContext);
            var permissionService = new PermissionService(broadwayBuilderContext);

            permissionService.CreatePermission(permission);
            broadwayBuilderContext.SaveChanges();
            roleService.CreateRole(NewRole);
            broadwayBuilderContext.SaveChanges();
            userService.CreateUser(user);
            broadwayBuilderContext.SaveChanges();

            // Act 
            actual = service.HasPermission(user, permission);

            
            userService.DeleteUser(user);
            roleService.DeleteRole(NewRole);
            permissionService.DeletePermission(permission);
            broadwayBuilderContext.SaveChanges();

            // Assert
            Assert.AreEqual(expected, actual);


        }


    }
}
