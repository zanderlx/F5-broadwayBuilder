using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace ServiceLayer
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
            return _dbContext.Productions.Find(productionId);
        }

        public Production UpdateProduction(Production production)
        {
            Production currentProduction = _dbContext.Productions.Find(production.ProductionID);

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
            Production productionToDelete = _dbContext.Productions.Find(production.ProductionID);
            // If the production found is not null, delete the production
            if (productionToDelete != null)
            {
                _dbContext.Productions.Remove(productionToDelete);
            }
        }

        public void UploadProgram(int productionId, string extension, HttpPostedFile postedFile)
        {
            var filePath = HostingEnvironment.MapPath("~/ProductionPrograms/" + productionId + extension);
            postedFile.SaveAs(filePath);
        }


    }
}
