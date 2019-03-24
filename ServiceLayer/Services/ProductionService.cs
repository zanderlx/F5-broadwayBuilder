using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace ServiceLayer.Services
{
   public class ProductionService
    {
        private readonly BroadwayBuilderContext _dbContext;

        public ProductionService(BroadwayBuilderContext dbcontext)
        {
            _dbContext = dbcontext;
        } 

        public void CreateProduction(Production production)
        {
            _dbContext.Productions.Add(production);
        }

        public Production GetProduction(int productionId)
        {
            return _dbContext.Productions
                .Where(o => o.ProductionID == productionId)
                //.Include(o => o.ProductionDateTime) //  Only Needed if lazy loading is off and you need to get the production date times
                .FirstOrDefault(); //if item doesn't exist it returns null Todo: throw a specific exception
        }

        public IEnumerable<Production> GetProductionsByPreviousDate(DateTime previousDate)
        {
            return _dbContext.Productions
                .Include(production => production.ProductionDateTime)
                .Where(production => production.ProductionDateTime.Where(productionDateTime => productionDateTime.Date <= previousDate).Any())
                .ToList();
        }

        public IEnumerable<Production> GetProductionsByCurrentAndFutureDate(DateTime currentDate)
        {
            return _dbContext.Productions
                .Include(production => production.ProductionDateTime)
                .Where(production => production.ProductionDateTime.Where(productionDateTime => productionDateTime.Date >= currentDate).Any())
                .ToList();
        }

        public Production UpdateProduction(Production production)
        {
            Production currentProduction = _dbContext.Productions
                 .Where(o => o.ProductionID == production.ProductionID)
                 .FirstOrDefault(); //gives you first production that satisfies the where

            if (currentProduction != null)
            {
                currentProduction.ProductionName = production.ProductionName;
                currentProduction.DirectorFirstName = production.DirectorFirstName;
                currentProduction.DirectorLastName = production.DirectorLastName;
                currentProduction.Street = production.Street;
                currentProduction.City = production.City;
                currentProduction.StateProvince = production.StateProvince;
                currentProduction.Country = production.Country;
                currentProduction.Zipcode = production.Zipcode;
            }

            return currentProduction;
        }


        public void DeleteProduction(Production production)
        {
            Production productionToDelete = _dbContext.Productions
                .Where(o => o.ProductionID == production.ProductionID)
                .FirstOrDefault(); //gives you first production that satisfies the where
            
            // If the production found is not null, delete the production
            if (productionToDelete != null)
            {
                _dbContext.Productions.Remove(productionToDelete);
            } else
            {
                //throw an exception
            }
        }

        public void UploadProgram(int productionId, string extension, HttpPostedFile postedFile)
        {
            var filePath = HostingEnvironment.MapPath("~/ProductionPrograms/" + productionId + extension);
            postedFile.SaveAs(filePath);
        }

        public void UploadPhoto(int productionId, int count, string extension, HttpPostedFile postedFile)
        {
            var filePath = HostingEnvironment.MapPath("~/ProductionPhotos/" + productionId + "-" + count + extension);
            postedFile.SaveAs(filePath);
        }

        public void CreateProductionDateTime(ProductionDateTime productionDateTime)
        {
            _dbContext.ProductionDateTimes.Add(productionDateTime);
        }
    }
}
