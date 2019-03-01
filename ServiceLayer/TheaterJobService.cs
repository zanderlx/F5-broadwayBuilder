using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class TheaterJobService
    {
        private readonly BroadwayBuilderContext _dbContext;

        public void CreateTheaterJob(TheaterJobPosting theaterJob)
        {
            _dbContext.TheaterJobPostings.Add(theaterJob);
        }

        public TheaterJobPosting GetTheaterJob(TheaterJobPosting theaterJob)
        {
            return _dbContext.TheaterJobPostings.Find(theaterJob.HelpWantedID);
        }

        public void UpdateTheaterJob(TheaterJobPosting updatedTheaterJob, TheaterJobPosting originalTheaterJob)
        {
            if (originalTheaterJob != null)
            {
                originalTheaterJob.Title = updatedTheaterJob.Title;
                originalTheaterJob.Hours = updatedTheaterJob.Hours;
                originalTheaterJob.Position = updatedTheaterJob.Position;
                originalTheaterJob.Requirements = updatedTheaterJob.Requirements;
                originalTheaterJob.theater = updatedTheaterJob.theater;
            }
        }

        public void DeleteTheaterJob(TheaterJobPosting jobToRemove)
        {
            if (jobToRemove != null)
            {
                _dbContext.TheaterJobPostings.Remove(jobToRemove);
            }
        }
    }
}
