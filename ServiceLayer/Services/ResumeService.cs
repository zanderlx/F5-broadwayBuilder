using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ResumeService
    {
        private readonly BroadwayBuilderContext _dbContext;

        public ResumeService(BroadwayBuilderContext context)
        {
            this._dbContext = context;
        }

        public void CreateResume(Resume resume)
        {
            resume.DateCreated = DateTime.Now;
            _dbContext.Resumes.Add(resume);
        }

        public Resume GetResumeById(int resumeID)
        {
            return _dbContext.Resumes.Find(resumeID);
        }

    }
}
