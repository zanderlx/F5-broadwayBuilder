using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;

namespace ServiceLayer.Test
{
    [TestClass]
    public class ProductionServiceTest
    {
        [TestMethod]
        public void ProductionService_CreateProduction_Pass()
        {
            var context = new BroadwayBuilderContext();
            var theaterService = new TheaterService(context);
            // Arrange
            var theater = new Theater("someTheater", "Regal", "theater st", "LA", "CA", "US", "323323");
            theaterService.CreateTheater(theater);
            context.SaveChanges();
            //var productionId = Guid.NewGuid();
            var productionName = "The Lion King";
            var directorFirstName = "Jane";
            var directorLastName = "Doe";
            var productionCity = "Long Beach";
            var productionState = "California";
            var productionCountry = "United States";


            var production = new Production(theater.TheaterID, productionName, directorFirstName, directorLastName, productionCity, productionState, productionCountry);

            var expected = true;
            var actual = false;

            var productionService = new ProductionService(context);


            // Act
            productionService.CreateProduction(production);
            var affectedRows = context.SaveChanges();

            if (affectedRows > 0)
                actual = true;

            // Assert
            productionService.DeleteProduction(production);
            context.SaveChanges();
            theaterService.DeleteTheater(theater);
            context.SaveChanges();
            Assert.AreEqual(expected, actual);


        }
    }
}
