using DataAccessLayer;
using ServiceLayer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BroadwayBuilder.Api.Controllers
{
    [Route("helpwanted")]
    public class HelpWantedController : ApiController
    {
        [HttpGet,Route("{theaterid}")]
        public IQueryable GetTheaterJobs(int theaterid)//needs to be changed to string for encryption purposes
        {
            using(var dbcontext = new BroadwayBuilderContext())
            {
                return dbcontext.TheaterJobPostings.Where(job => job.TheaterID == theaterid).Select(job => new { Position = job.Position,
                    Hours = job.Hours, Description = job.Description, Requirement = job.Requirements});
            }
        }

        [HttpPost,Route("createtheaterjob")]
        public IHttpActionResult CreateTheaterJob([FromBody]TheaterJobPosting theaterJob)
        {
            using(var dbcontext = new BroadwayBuilderContext())
            {
                TheaterJobService jobService = new TheaterJobService(dbcontext);
                try
                {
                    jobService.CreateTheaterJob(theaterJob);
                    dbcontext.SaveChanges();
                    return Content((HttpStatusCode)201, "Theater Job Posting Created");
                }
                catch(Exception e)
                {
                    return BadRequest();
                }
            }
        }

        [HttpPost, Route("createproductionjob")]
        public IHttpActionResult CreateProductionJob([FromBody]ProductionJobPosting productionJob)
        {
            using (var dbcontext = new BroadwayBuilderContext())
            {
                ProductionJobService jobService = new ProductionJobService(dbcontext);
                try
                {
                    jobService.CreateProductionJob(productionJob);
                    dbcontext.SaveChanges();
                    return Content((HttpStatusCode)201, "Theater Job Posting Created");
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
        }

    }
}
