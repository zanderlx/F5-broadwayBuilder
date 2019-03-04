using System;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServiceLayer.Test
{
    [TestClass]
    public class ProductionJobTest
    {
        [TestMethod]
        public void ProductionJobService_CreateProductionJobPosting_Pass()
        {
            //Arrange
            var dbcontext = new BroadwayBuilderContext();
            var theaterService = new TheaterService(dbcontext);
            var productionService = new ProductionService(dbcontext);
            var productionJobService = new ProductionJobService(dbcontext);
            var expected = true;
            var actual = false;

            var theater = new Theater("someTheater", "Regal", "theater st", "LA", "CA", "US", "323323");
            var production = new Production(theater.TheaterID, "someName","directorln", "directorfn", "street", "city", "state", "country", "zip");
            theaterService.CreateTheater(theater);
            productionService.CreateProduction(production);
            dbcontext.SaveChanges();
            var jobPosting = new ProductionJobPosting(production.ProductionID, "intern", "some decription", "title", "hours", "some requirements");
            //Act
            productionJobService.CreateProductionJob(jobPosting);
            var results = dbcontext.SaveChanges();
            if (results > 0)
            {
                actual = true;
            }

            productionJobService.DeleteProductionJob(jobPosting);
            productionService.DeleteProduction(production);
            theaterService.DeleteTheater(theater);
            dbcontext.SaveChanges();
            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductionJobService_DeleteProductionJobPosting_Pass()
        {
            //Arrange
            var dbcontext = new BroadwayBuilderContext();
            var theaterService = new TheaterService(dbcontext);
            var productionService = new ProductionService(dbcontext);
            var productionJobService = new ProductionJobService(dbcontext);
            var expected = true;
            var actual = false;

            var theater = new Theater("someTheater", "Regal", "theater st", "LA", "CA", "US", "323323");
            var production = new Production(theater.TheaterID, "someName", "directorln", "directorfn", "street", "city", "state", "country", "zip");
            theaterService.CreateTheater(theater);
            productionService.CreateProduction(production);
            dbcontext.SaveChanges();
            var jobPosting = new ProductionJobPosting(production.ProductionID, "intern", "some decription", "title", "hours", "some requirements");
            //Act
            productionJobService.CreateProductionJob(jobPosting);
            dbcontext.SaveChanges();
            productionJobService.DeleteProductionJob(jobPosting);
            var results = dbcontext.SaveChanges();
            if (results > 0)
            {
                actual = true;
            }

            productionService.DeleteProduction(production);
            theaterService.DeleteTheater(theater);
            dbcontext.SaveChanges();
            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductionJobService_ReadProductionJobPosting_Pass()
        {
            //Arrange
            var dbcontext = new BroadwayBuilderContext();
            var theaterService = new TheaterService(dbcontext);
            var productionService = new ProductionService(dbcontext);
            var productionJobService = new ProductionJobService(dbcontext);
            var expected = true;
            var actual = false;

            var theater = new Theater("someTheater", "Regal", "theater st", "LA", "CA", "US", "323323");
            var production = new Production(theater.TheaterID, "someName", "directorln", "directorfn", "street", "city", "state", "country", "zip");
            theaterService.CreateTheater(theater);
            productionService.CreateProduction(production);
            dbcontext.SaveChanges();
            var jobPosting = new ProductionJobPosting(production.ProductionID, "intern", "some decription", "title", "hours", "some requirements");
            //Act
            productionJobService.CreateProductionJob(jobPosting);
            dbcontext.SaveChanges();
            ProductionJobPosting productionJobPost = productionJobService.GetProductionJob(jobPosting);
            if (productionJobPost!=null)
            {
                actual = true;
            }

            productionJobService.DeleteProductionJob(jobPosting);
            productionService.DeleteProduction(production);
            theaterService.DeleteTheater(theater);
            dbcontext.SaveChanges();
            //Assert 
            Assert.AreEqual(expected, actual);
        }
    }
}
