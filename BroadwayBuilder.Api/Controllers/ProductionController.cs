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
using ServiceLayer.Services;

namespace BroadwayBuilder.Api.Controllers
{
    [RoutePrefix("production")]
    public class ProductionController : ApiController
    {
        [Route("{productionId}/uploadProgram")]
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

        [Route("create")]
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

        [Route("{productionId}")]
        [HttpGet]

        public IHttpActionResult GetProductionById(int productionId)
        {
            using (var dbcontext = new BroadwayBuilderContext())

            {
                var productionService = new ProductionService(dbcontext);

                try
                {
                    Production current_production = productionService.GetProduction(productionId);

                    return Ok(current_production);
                }
                // Hack: Need to add proper exception handling
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
  
        }

        [Route("update")]
        [HttpPut]

        public IHttpActionResult UpdateProduction([FromBody] Production production_to_update)
        {
            using (var dbcontext = new BroadwayBuilderContext())
            {
                var productionService = new ProductionService(dbcontext);

                try
                {
                    if (production_to_update == null)
                    {
                        return BadRequest("no production object provided");
                    }
                    else if (production_to_update.ProductionID == null)
                    {
                        return BadRequest("Production id is null");
                    }


                    Production updated_production = productionService.UpdateProduction(production_to_update);
                    dbcontext.SaveChanges();

                    return Ok(updated_production);

                }
                // Hack: Need to add proper exception handling
                catch (Exception e)
                {
                    return BadRequest();
                }
            }

        }

        [Route("delete")]
        [HttpDelete]

        public IHttpActionResult deleteProduction(Production productionToDelete)
        {
            using (var dbcontext = new BroadwayBuilderContext())
            {
                var productionService = new ProductionService(dbcontext);

                try
                {
                    if (productionToDelete == null)
                    {
                        return BadRequest("no production object provided");
                    }
                    else if (productionToDelete.ProductionID == null)
                    {
                        return BadRequest("Production id is null");
                    }

                    productionService.DeleteProduction(productionToDelete);
                    dbcontext.SaveChanges();

                    return Ok("Production deleted succesfully");

                } 
                // Hack: Need to add proper exception handling
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
        }

        [Route("{productionId}/uploadPhoto")]
        [HttpPost]

        public IHttpActionResult uploadPhoto(int productionId)
        {
            var dbcontext = new BroadwayBuilderContext();
            var productionService = new ProductionService(dbcontext);

            //try to upload pdf and save to server filesystem
            try
            {
                //get the content, headers, etc the full request of the current http request
                var httpRequest = HttpContext.Current.Request;

                // Todo: Check if length of httpRequest.Files <= 10 to ensure only 10 photos is uploaded

                var count = 0;
                foreach (string filename in httpRequest.Files)
                {
                    var putFile = httpRequest.Files[filename];
                    if (putFile != null && putFile.ContentLength > 0) //validates if file exists ContentLengh is # of bytes
                    {

                        int MaxContentLength = 1 * 1024 * 1024 * 5; //Size = 5 MB

                        //A list in case we want to accept more than one file type
                        IList<string> AllowedFileExtension = new List<string> { ".jpg" };
                        var ext = putFile.FileName.Substring(putFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();

                        if (!AllowedFileExtension.Contains(extension))
                        {

                            //var message = string.Format("Please Upload image of type .jpg only");

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
                            productionService.UploadPhoto(productionId, count, extension, putFile);
                        }
                    }

                    // Todo: Create an ErrorMessage model
                    //var message1 = string.Format("Image Updated Successfully.");
                    //return Created(insert path);
                    //return Created("C:\\Users\\ProductionPrograms");
                    count++;
                }

                return Ok("Photo Uploaded");
            }

            catch (Exception ex)
            {
                // Todo: add proper error handling
                // Todo: log error
                return BadRequest();

            }
        }

    }
}
