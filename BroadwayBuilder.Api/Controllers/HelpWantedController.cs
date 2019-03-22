using DataAccessLayer;
using ServiceLayer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

//get all job posting, edit job posting, delete job posting, create job posting
//http get, put, delete, post
namespace BroadwayBuilder.Api.Controllers
{
    [RoutePrefix("helpwanted")]
    public class HelpWantedController : ApiController
    {
        public HelpWantedController() { }
        [HttpGet,Route("{theaterid}")]
        public IHttpActionResult GetTheaterJobs(int theaterid)//needs to be changed to string for encryption purposes
        {
            using(var dbcontext = new BroadwayBuilderContext())
            {
                TheaterJobService service = new TheaterJobService(dbcontext);
                var list = service.GetAllJobsFromTheater(theaterid);
                return Content((HttpStatusCode)200, list);
            }
        }

        [HttpPut,Route("edittheaterjob")]
        public IHttpActionResult EditTheaterJob(TheaterJobPosting job) //only one not tested - dont know how to include datetime in JSON
        {
            using(var dbcontext = new BroadwayBuilderContext())
            {
                TheaterJobService service = new TheaterJobService(dbcontext);
                //TheaterJobPosting job = service.GetTheaterJob(helpwantedid);
                if (job != null)
                {
                    service.UpdateTheaterJob(job);
                    var results = dbcontext.SaveChanges();
                    if (results > 0)
                    {
                        return Content((HttpStatusCode)202, "Updated Job Posting");//not sure to return object or just string response
                    }
                    return Content((HttpStatusCode)500,"Theater Job could not be added");//need to edit 
                }
                else
                {
                    return Content((HttpStatusCode)500, "Theater Job could not be added");//need to edit 
                }
            }
        }

        [HttpDelete, Route("deletetheaterjob/{helpWantedId}")]
        public IHttpActionResult DeleteTheaterJob(int helpWantedId)
        {
            using (var dbcontext = new BroadwayBuilderContext())
            {
                TheaterJobService service = new TheaterJobService(dbcontext);
                TheaterJobPosting job = service.GetTheaterJob(helpWantedId);
                service.DeleteTheaterJob(job);
                if(job == null)
                {
                    return Content((HttpStatusCode)404, "That Job Listing was not found within the database");
                }
                var results = dbcontext.SaveChanges();
                if (results > 0)
                {
                    return Content((HttpStatusCode)202, "Successfully Deleted Job Posting");
                }
                else
                {
                    return Content((HttpStatusCode)202, "Unable to Delete Job Posting");
                }

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
                catch(Exception e)//needs to be updated
                {
                    return Content((HttpStatusCode)400, e.Message);
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
                    return Content((HttpStatusCode)201, "Production Job Posting Created");
                }
                catch (Exception e)
                {
                    return Content((HttpStatusCode)400, "Production Job could not be created");
                }
            }
        }

    }
}
