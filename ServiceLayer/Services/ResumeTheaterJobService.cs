using DataAccessLayer;
using System.Linq;
using DataAccessLayer.Models;
using System.Data.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ResumeTheaterJobService
    {
        private readonly BroadwayBuilderContext _dbContext;

        public ResumeTheaterJobService(BroadwayBuilderContext context)
        {
            this._dbContext = context;
        }

        public void CreateResumeTheaterJob(ResumeTheaterJob resumeTheaterJob)
        {
            this._dbContext.ResumeTheaterJobs.Add(resumeTheaterJob);
        }

        public IEnumerable GetAllResumeForTheater(int theaterID)
        {
            return _dbContext.ResumeTheaterJobs.Include(job => job.theaterJobPosting)
                .Where(job => job.theaterJobPosting.TheaterID == theaterID)
                .Select(submittedResumes => new
                {
                    HelpWantedID = submittedResumes.HelpWantedID,
                    ResumeID = submittedResumes.ResumeID,
                    DateUploaded = submittedResumes.DateUploaded
                }).ToList();
        }
    }
}
