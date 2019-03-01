using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ProductionJobService
    {
        private readonly BroadwayBuilderContext _dbContext;

        public void CreateProductionJob(ProductionJobPosting productionJob)
        {
            _dbContext.ProductionJobPostings.Add(productionJob);
        }

        public ProductionJobPosting GetTheaterJob(ProductionJobPosting productionJob)
        {
            return _dbContext.ProductionJobPostings.Find(productionJob.HelpWantedID);
        }

        public void UpdateTheaterJob(TheaterJobPosting updatedProductionJob, TheaterJobPosting originalProductionJob)
        {
            if (originalProductionJob != null)
            {
                originalProductionJob.Title = updatedProductionJob.Title;
                originalProductionJob.Hours = updatedProductionJob.Hours;
                originalProductionJob.Position = updatedProductionJob.Position;
                originalProductionJob.Requirements = updatedProductionJob.Requirements;
                originalProductionJob.theater = updatedProductionJob.theater;
            }
        }

        public void DeleteTheaterJob(ProductionJobPosting jobToRemove)
        {
            if (jobToRemove != null)
            {
                _dbContext.ProductionJobPostings.Remove(jobToRemove);
            }
        }
    }
}
