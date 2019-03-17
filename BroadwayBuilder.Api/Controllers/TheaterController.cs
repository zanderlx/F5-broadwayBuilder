using DataAccessLayer;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BroadwayBuilder.Api.Controllers
{
    public class TheaterController : ApiController
    {
        [Route("theater/createtheater")]
        [HttpPost]

        public IHttpActionResult CreateTheater([FromBody] Theater theater)
        {

            using (var dbcontext = new BroadwayBuilderContext())
            {
                var theaterService = new TheaterService(dbcontext);

                try
                {
                    theaterService.CreateTheater(theater);
                    dbcontext.SaveChanges();

                    return Content((HttpStatusCode)201,"Theater Created");

                }
                // Todo: add proper error handling
                catch (Exception e)
                {
                    return BadRequest();
                }

            }

        }
    }
}
