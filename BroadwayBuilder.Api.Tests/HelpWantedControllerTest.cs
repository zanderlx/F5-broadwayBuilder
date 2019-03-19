using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http.Results;
using BroadwayBuilder.Api.Controllers;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Services;

namespace BroadwayBuilder.Api.Tests
{
    [TestClass]
    public class HelpWantedControllerTest
    {
        [TestMethod]
        public void GetShouldReturnAddTheaterJob()
        {
            //Arrange
            var controller = new HelpWantedController();
            TheaterJobPosting job = new TheaterJobPosting(7,"test", "test", "test", "test", "test");
            //Act
            var actionResult = controller.CreateTheaterJob(job);
            var response = actionResult as NegotiatedContentResult<string>;
            var content = response.Content;

            ////Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual("Theater Job Posting Created",content);
            Assert.AreEqual((HttpStatusCode)201,response.StatusCode);
        }

        [TestMethod]
        public void PutShouldUpdateTheaterJob() {
            var dbcontext = new BroadwayBuilderContext();
            var theaterService = new TheaterService(dbcontext);
            var theaterJobService = new TheaterJobService(dbcontext);
            //var expected = true;
            //var actual = false;

            var theater = new Theater("someTheater", "Regal", "theater st", "LA", "CA", "US", "323323");
            theaterService.CreateTheater(theater);
            dbcontext.SaveChanges();
            var jobPosting = new TheaterJobPosting(theater.TheaterID, "intern", "some decription", "title", "hours", "some requirements");
            theaterJobService.CreateTheaterJob(jobPosting);
            dbcontext.SaveChanges();
            var controller = new HelpWantedController();

            //Act
            jobPosting.Description = "testing";
            var actionResult = controller.EditTheaterJob(jobPosting);
            var response = actionResult as NegotiatedContentResult<string>;
            var content = response.Content;

            theaterJobService.DeleteTheaterJob(jobPosting);
            theaterService.DeleteTheater(theater);
            dbcontext.SaveChanges();
            ////Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual("Updated Job Posting", content);
            Assert.AreEqual((HttpStatusCode)202,response.StatusCode);
        }

        [TestMethod]
        public void DeleteShouldDeleteTheaterJob()
        {
            var dbcontext = new BroadwayBuilderContext();
            var theaterService = new TheaterService(dbcontext);
            var theaterJobService = new TheaterJobService(dbcontext);
            //var expected = true;
            //var actual = false;

            var theater = new Theater("someTheater", "Regal", "theater st", "LA", "CA", "US", "323323");
            theaterService.CreateTheater(theater);
            dbcontext.SaveChanges();
            var jobPosting = new TheaterJobPosting(theater.TheaterID, "intern", "some decription", "title", "hours", "some requirements");
            theaterJobService.CreateTheaterJob(jobPosting);
            dbcontext.SaveChanges();
            var controller = new HelpWantedController();

            //Act
            var actionResult = controller.DeleteTheaterJob(8);
            var response = actionResult as NegotiatedContentResult<string>;
            var content = response.Content;
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual("Successfully Deleted Job Posting", content);
            Assert.AreEqual((HttpStatusCode)202, response.StatusCode);

            
            theaterService.DeleteTheater(theater);
            dbcontext.SaveChanges();
        }
    }
}
