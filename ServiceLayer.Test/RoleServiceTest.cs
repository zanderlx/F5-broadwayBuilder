using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using ServiceLayer.Services;

namespace ServiceLayer.Test
{
    [TestClass]
    public class RoleServiceTest
    {
        [TestMethod]
        public void RoleService_CreateRole_Pass()
        {
            // Arrange
            var NewRole = new Role("GENERAL",true);

            bool expected = true;
            bool actual = false;

            var context = new BroadwayBuilderContext();
            var roleService = new RoleService(context);

            // Act
            roleService.CreateRole(NewRole);
            var numOfAffectedRows = context.SaveChanges();

            if (numOfAffectedRows > 0)
            {
                actual = true;
            }


            // Assert
            roleService.DeleteRole(NewRole);
            context.SaveChanges();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void RoleService_GetRole_Pass()
        {
            // Arrange

            string role = "ADMIN";

            var NewRole = new Role(role,true);

            var expected = NewRole;

            var context = new BroadwayBuilderContext();
            var roleService = new RoleService(context);

            // Act
            roleService.CreateRole(NewRole);
            context.SaveChanges();

            var actual = roleService.GetRole(NewRole.RoleID);

            roleService.DeleteRole(NewRole);
            context.SaveChanges();


            // Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void RoleService_DeleteRole_Pass()
        {
            // Arrange
            var NewRole = new Role("GENERAL",true);

            bool expected = true;
            bool actual = false;

            var context = new BroadwayBuilderContext();
            var roleService = new RoleService(context);

            // Act
            roleService.CreateRole(NewRole);
            context.SaveChanges();

            roleService.DeleteRole(NewRole);
            var numOfAffectedRows = context.SaveChanges();

            if (numOfAffectedRows > 0)
            {
                actual = true;
            }

            // Assert
            Assert.AreEqual(expected, actual);

        }
    }
}


