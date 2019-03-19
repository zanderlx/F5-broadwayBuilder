﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using BroadwayBuilder.Api.Controllers;
using System.Web.Http.Results;
using System.Net;
using ServiceLayer.Services;
using System.Collections;

namespace BroadwayBuilder.Api.Tests
{
    /// <summary>
    /// Summary description for TheaterControllerTest
    /// </summary>
    [TestClass]
    public class TheaterControllerTest
    {
        [TestMethod]
        public void PostShouldAddTheater()
        {
            //Arrange
            var dbcontext = new BroadwayBuilderContext();
            var theater = new Theater("createTheater", "Regal", "theater st", "LA", "CA", "US", "323323");
            var service = new TheaterService(dbcontext);
            var controller = new TheaterController();

            //Act
            var actionResult = controller.CreateTheater(theater);
            var response = actionResult as NegotiatedContentResult<string>;
            var content = response.Content;

            //Assert 
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual("Theater Created", content);
            Assert.AreEqual((HttpStatusCode)201, response.StatusCode);

            Theater gettheater = service.GetTheaterByName("createTheater");
            service.DeleteTheater(gettheater);
            dbcontext.SaveChanges();
        }

        [TestMethod]
        public void GetShouldGetTheaterByName()
        {
            //Arrange
            var dbcontext = new BroadwayBuilderContext();
            var theater = new Theater("createTheater", "Regal", "theater st", "LA", "CA", "US", "323323");
            var service = new TheaterService(dbcontext);
            service.CreateTheater(theater);
            dbcontext.SaveChanges();
            var controller = new TheaterController();

            //Act
            var actionResult = controller.GetTheaterByName(theater.TheaterName);
            var response = actionResult as NegotiatedContentResult<Theater>;
            var content = response.Content;

            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(theater.TheaterName, content.TheaterName);
            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);

            service.DeleteTheater(theater);
            dbcontext.SaveChanges();

        }

        [TestMethod]
        public void GetShouldGetAllTheaters()
        {
            //Arrange
            var dbcontext = new BroadwayBuilderContext();
            var theater = new Theater("createTheater", "Regal", "theater st", "LA", "CA", "US", "323323");
            var service = new TheaterService(dbcontext);
            service.CreateTheater(theater);
            dbcontext.SaveChanges();
            var controller = new TheaterController();

            //Act
            var actionResult = controller.GetAllTheaters();
            var response = actionResult as NegotiatedContentResult<IEnumerable>;
            var content = response.Content;
            //Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual((HttpStatusCode)200, response.StatusCode);

            service.DeleteTheater(theater);
            dbcontext.SaveChanges();
        }
    }
}
