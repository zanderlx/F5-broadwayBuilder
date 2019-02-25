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
            // Arrange
            var productionId = Guid.NewGuid();
            var productionName = "The Lion King";
            var directorFirstName = "Jane";
            var directorLastName = "Doe";
            var productionCity = "Long Beach";
            var productionState = "California";
            var productionCountry = "United States";


            var production = new Production(productionId, productionName, directorFirstName, directorLastName, productionCity, productionState, productionCountry);

            var expected = true;
            var actual = false;

            var context = new BroadwayBuilderContext();

            var productionService = new ProductionService(context);


            // Act
            productionService.CreateProduction(production);
            var affectedRows = context.SaveChanges();

            if (affectedRows > 0)
                actual = true;

            // Assert
            //productionService.DeleteProduction(production);
            //context.SaveChanges();
            Assert.AreEqual(expected, actual);


        }
    }
}
