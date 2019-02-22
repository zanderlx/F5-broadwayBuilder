using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
   public class ProductionService
    {
        private readonly BroadwayBuilderContext _dbContext;

        public ProductionService(BroadwayBuilderContext dbcontext)
        {
            this._dbContext = dbcontext;
        }

        public void CreateProduction(Production production)
        {
            _dbContext.Productions.Add(production);
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

        // TODO: Incomplete service - Must finish adding other methods
    }
}
