using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using BroadwayBuilder.Api.Controllers;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BroadwayBuilder.Api.Tests
{
    [TestClass]
    public class HelpWantedControllerTest
    {
        [TestMethod]
        public void GetShouldReturnAllTheaterJob()
        {
            //Arrange
            //var controller = new HelpWantedController();
            //TheaterJobPosting job = new TheaterJobPosting
            //{
            //    TheaterID = 2,
            //    Position = "test",
            //    Description = "test",
            //    Title = "test",
            //    Hours = "test",
            //    Requirements = "test"
            //};
            ////Act
            //var actionResult = controller.CreateTheaterJob(job);
            //var response = actionResult as OkNegotiatedContentResult<string>;
            //var content = response.Content;
            ////Assert
            //Assert.IsNotNull(response);
            //Assert.Equals("Theater Job Posting Created",content);
            //Assert.Equals(2);
        }
    }
}
