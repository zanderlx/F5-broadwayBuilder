using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ServiceLayer;
using DataAccessLayer;

namespace BroadwayBuilder.Api.Controllers
{
    public class ProductionController : ApiController
    {
        [Route("production/{productionId}/uploadProgram")]
        [HttpPut]

        public IHttpActionResult UploadProductionProgram(int productionId)
        {
            var dbcontext = new BroadwayBuilderContext();
            var productionService = new ProductionService(dbcontext);

            //try to upload pdf and save to server filesystem
            try
            {
                //get the content, headers, etc the full request of the current http request
                var httpRequest = HttpContext.Current.Request;

                // Todo: Check if length of httpRequest.Files == 1 to ensure only 1 file is uploaded

                foreach (string filename in httpRequest.Files)
                {   
                    var putFile = httpRequest.Files[filename];
                    if (putFile != null && putFile.ContentLength > 0) //validates if file exists ContentLengh is # of bytes
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB

                        //A list in case we want to accept more than one file type
                        IList<string> AllowedFileExtension = new List<string> { ".pdf" };
                        var ext = putFile.FileName.Substring(putFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        
                        if (!AllowedFileExtension.Contains(extension))
                        {
                           
                            //var message = string.Format("Please Upload image of type .pdf only");

                            // Todo: Log the error that occurs
                            return BadRequest();
                        }
                        else if (putFile.ContentLength > MaxContentLength)
                        {
                            
                            //var message = string.Format("Please Upload a file upto 1 mb.");

                            // Todo: log the error that occurs
                            return BadRequest();
                        }
                        else
                        {
                            productionService.UploadProgram(productionId, extension, putFile);

                        }
                    }
                    
                    // Todo: Create an ErrorMessage model
                    //var message1 = string.Format("Image Updated Successfully.");
                    //return Created(insert path);
                    //return Created("C:\\Users\\ProductionPrograms");
                    return Ok("Pdf Uploaded");
                }
                // Todo: Create an ErrorMessage model
                //var res = string.Format("Please Upload an image.");

                // Todo: log the error that occurs
                return BadRequest();
            }

                catch (Exception ex) {
                // Todo: add proper error handling
                // Todo: log error
                return BadRequest();
               
                }
        }
        /*
         * BLOCKED: In order to continue with this endpoint, 
         * A theater in the database is needed in order to create a production.
         */
        [Route("production/createproduction")]
        [HttpPost]

        public IHttpActionResult CreateProduction([FromBody] Production production)
        {
            
            using (var dbcontext = new BroadwayBuilderContext())
            {
            var productionService = new ProductionService(dbcontext);

                try
                {
                    productionService.CreateProduction(production);
                    dbcontext.SaveChanges();

                    // Todo: Turn this into Created(201) once the get endpoint is done so we can return the url to get the item that was just created
                    return Ok("production created");

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
