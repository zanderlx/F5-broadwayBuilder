using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using ServiceLayer.Services;

namespace ServiceLayer.Test
{
    [TestClass]
    public class ProductionServiceTest
    {
        [TestMethod]
        public void ProductionService_CreateProduction_Pass()
        {
            var dbcontext = new BroadwayBuilderContext();
            var theaterService = new TheaterService(dbcontext);

            // Arrange
            var theater = new Theater("someTheater", "Regal", "theater st", "LA", "CA", "US", "323323");
            theaterService.CreateTheater(theater);
            dbcontext.SaveChanges();

            var productionName = "The Lion King";
            var directorFirstName = "Jane";
            var directorLastName = "Doe";
            var street = "Anahiem";
            var city = "Long Beach";
            var stateProvince = "California";
            var country = "United States";
            var zipcode = "919293";

            
            var production = new Production(theater.TheaterID, productionName, directorFirstName, directorLastName, street, city, stateProvince, country, zipcode);

            var expected = true;
            var actual = false;

            var productionService = new ProductionService(dbcontext);


            // Act
            productionService.CreateProduction(production);
            dbcontext.SaveChanges();

            if (production.ProductionID.HasValue)
                actual = true;

            // Assert

            var dbcontext_ = new BroadwayBuilderContext();
            var productionService_ = new ProductionService(dbcontext_);

            productionService.DeleteProduction(production);
            dbcontext.SaveChanges();
            theaterService.DeleteTheater(theater);
            dbcontext.SaveChanges();
            Assert.AreEqual(expected, actual);


        }

        [TestMethod]
        public void ProductionService_CreateProductionDateTime_Pass()
        {
            //Arrange
            var dbcontext = new BroadwayBuilderContext();
            var theaterService = new TheaterService(dbcontext);

            var theater = new Theater("The Magicians", "Regal", "theater st", "LA", "CA", "US", "323323");
            theaterService.CreateTheater(theater);
            dbcontext.SaveChanges();

            var productionService = new ProductionService(dbcontext);

            var productionName = "The Lion King";
            var directorFirstName = "Joan";
            var directorLastName = "Doe";
            var street = "123 Anahiem St";
            var city = "Long Beach";
            var stateProvince = "California";
            var country = "United States";
            var zipcode = "919293";

            var production = new Production(theater.TheaterID, productionName, directorFirstName, directorLastName, street, city, stateProvince, country, zipcode);
            productionService.CreateProduction(production);
            dbcontext.SaveChanges();

            var date = DateTime.Parse("3/23/2019 3:22:29 PM");
            var time = TimeSpan.Parse("10:30:00");
            
            /* Info: Had to cast to int because in production entity model int was made into a Nullable<int> or int? for data validation purposes
               If we make model in frontend then we can remove this cast to int and it will make things cleaner
           */
            var productionDateTime = new ProductionDateTime((int)production.ProductionID, date, time);

            var expected = true;
            var actual = false;


            // Act
            productionService.CreateProductionDateTime(productionDateTime);
            var affectedRows = dbcontext.SaveChanges();

            if (affectedRows > 0)
                actual = true;

            // Assert
            productionService.DeleteProduction(production);
            dbcontext.SaveChanges();
            theaterService.DeleteTheater(theater);
            dbcontext.SaveChanges();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ProductionService_UpdateProduction_Pass()
        {
            // Arrange
            var dbcontext = new BroadwayBuilderContext();
            var theaterService = new TheaterService(dbcontext);

            var theater = new Theater("The Magicians", "Regal", "theater st", "LA", "CA", "US", "323323");
            theaterService.CreateTheater(theater);
            dbcontext.SaveChanges();

            var productionService = new ProductionService(dbcontext);

            var productionName = "The Lion King";
            var directorFirstName = "Joan";
            var directorLastName = "Doe";
            var street = "123 Anahiem St";
            var city = "Long Beach";
            var stateProvince = "California";
            var country = "United States";
            var zipcode = "919293";

            var production = new Production(theater.TheaterID, productionName, directorFirstName, directorLastName, street, city, stateProvince, country, zipcode);
            productionService.CreateProduction(production);
            dbcontext.SaveChanges();


            production.ProductionName = "The Lion King 2";
            production.StateProvince = "Utah";
            production.DirectorLastName = "Mangos";

            var expected = production;
           
            // Act
            var actual = productionService.UpdateProduction(production);
            dbcontext.SaveChanges();

            productionService.DeleteProduction(production);
            theaterService.DeleteTheater(theater);
            dbcontext.SaveChanges();

        }


    }
}
