﻿using System;
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
using BroadwayBuilder.Api.Models;

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

                //A list in case we want to accept more than one file type
                IList<string> AllowedFileExtension = new List<string> { ".pdf" };
                
                // Todo: Check if length of httpRequest.Files == 1 to ensure only 1 file is uploaded

                // Max file size is 1MB
                int MaxContentLength = 1024 * 1024 * 1;

                foreach (string filename in httpRequest.Files)
                {
                    // Grab current file of the request
                    var putFile = httpRequest.Files[filename];
                    
                    // Continue if the file has content
                    if (putFile != null && putFile.ContentLength > 0) 
                    {
                        // Checks the current extension of the current file
                        var ext = putFile.FileName.Substring(putFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();

                        // File extension is not valid
                        if (!AllowedFileExtension.Contains(extension))
                        {
                            //var message = string.Format("Please Upload image of type .pdf only");
                            // Todo: Log the error that occurs
                            return BadRequest();
                        }
                        // File size is too big
                        else if (putFile.ContentLength > MaxContentLength)
                        {            
                            //var message = string.Format("Please Upload a file upto 1 mb.");
                            // Todo: log the error that occurs
                            return BadRequest();
                        }
                        // Send to production service where functinality to save the file is
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

        [Route("{productionId}/create")]
        [HttpPost]
        public IHttpActionResult createProductionDateTime([FromUri] int productionId, [FromBody] ProductionDateTime productionDateTime )
        {
            try
            {
                using(var dbcontext = new BroadwayBuilderContext())
                {
                    var productionService = new ProductionService(dbcontext);

                    try
                    {
                        if (productionDateTime == null)
                        {
                            return BadRequest("no production date time object provided");
                        }
                        productionDateTime.ProductionID = productionId;
                        productionService.CreateProductionDateTime(productionDateTime);
                        dbcontext.SaveChanges();

                        // Todo: Change this to a 201 Created(insert url of resource) once get productiondate time route is created
                        return Ok(productionDateTime);
                    }
                    catch (Exception e)
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception e )
            {
                return BadRequest("Something went wrong!");
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

        [Route("getProductions")]
        [HttpGet]
        public IHttpActionResult GetProductions(DateTime? currentDate = null, DateTime? previousDate = null)
        {
            try
            {
                using (var dbcontext = new BroadwayBuilderContext())
                {
                    var productionService = new ProductionService(dbcontext);

                    try
                    {
                        if (previousDate != null) {

                            // List of past productions
                            var pastProductions  = productionService.GetProductionsByPreviousDate((DateTime)previousDate);

                            // List to hold production responses
                            var productionResponses = new List<ProductionResponseModel>();

                            /* Looping over productions entities, 
                             * converting to production response models 
                             * and adding them to the production response model list
                             */
                            foreach (var production in pastProductions)
                            {
                                // List to hold production date time responses
                                var productionDateTimeResponseModel = new List<ProductionDateTimeResponseModel>();

                                /* Looping over the production date time entities,
                                 * Converting to production date time response models 
                                 * and adding them to the production date time reponse model list
                                 */
                                foreach (var datetime in production.ProductionDateTime)
                                {
                                    // Converting to production response models and adding them to the production response model list
                                    productionDateTimeResponseModel.Add(new ProductionDateTimeResponseModel()
                                    {
                                        Date = datetime.Date,
                                        Time = datetime.Time,
                                        ProductionDateTimeId = datetime.ProductionDateTimeId
                                    });
                                }

                                // Converting to production response models and adding them to the production response model list
                                productionResponses.Add(new ProductionResponseModel() {

                                    ProductionID = production.ProductionID,
                                    DirectorFirstName = production.DirectorFirstName,
                                    DirectorLastName = production.DirectorLastName,

                                });
                            }


                            return Ok(productionResponses);
                        }
                        else if (currentDate != null)
                        {
                            // List of productions
                            var currentAndFutureProductions = productionService.GetProductionsByCurrentAndFutureDate((DateTime)currentDate);
                           
                            // List of production response models
                            var productionResponseModels = new List<ProductionResponseModel>();

                            /* Looping over productions entities, 
                             * converting to production response models 
                             * and adding them to the production response model list
                             */
                            foreach (var production in currentAndFutureProductions)
                            {
                                // A list to hold production date time response models
                                var productionDateTimeResponseModels = new List<ProductionDateTimeResponseModel>();

                                /* Looping over the production date time entities,
                                 * Converting to production date time response models 
                                 * and adding them to the production date time reponse model list
                                 */
                                foreach (var datetime in production.ProductionDateTime)
                                {
                                    // Converting to production date time response models and adding them to the production date time reponse model list
                                    productionDateTimeResponseModels.Add(new ProductionDateTimeResponseModel()
                                    {
                                        ProductionDateTimeId = datetime.ProductionDateTimeId,
                                        Date = datetime.Date,
                                        Time = datetime.Time
                                    });
                                }

                                // Converting to production response models and adding them to the production response model list
                                productionResponseModels.Add(new ProductionResponseModel()
                                {
                                    ProductionID = production.ProductionID,
                                    ProductionName = production.ProductionName,
                                    DirectorFirstName = production.DirectorFirstName,
                                    DirectorLastName = production.DirectorLastName,
                                    Street = production.Street,
                                    City = production.City,
                                    StateProvince = production.StateProvince,
                                    Zipcode = production.Zipcode,
                                    Country = production.Country,
                                    TheaterID = production.TheaterID,
                                    DateTimes = productionDateTimeResponseModels
                                });
                            }

                            return Ok(productionResponseModels);
                        }
                        
                        // none of the if conditions were met therfore...
                        return BadRequest("PreviousDate and Current date were both null");
                    }
                    // Todo: Add proper exception handling for getting a production
                    catch (Exception e)
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception e) // Todo: Catch a SqlException ... or Sqlconnection exception?
            {
                return BadRequest("Something big went bad!");
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

                // A list in case we want to accept more than one file type
                IList<string> AllowedFileExtension = new List<string> { ".jpg" };

                // Max file size is 1MB
                int MaxContentLength = 1 * 1024 * 1024 * 5; //Size = 5 MB

                var count = 0;

                foreach (string filename in httpRequest.Files)
                {
                    // Grab current file of the request
                    var putFile = httpRequest.Files[filename];

                    // Continue if the file has content
                    if (putFile != null && putFile.ContentLength > 0)
                    {

                        // Checks the current extension of the current file
                        var ext = putFile.FileName.Substring(putFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        
                        // File extension is not valid
                        if (!AllowedFileExtension.Contains(extension))
                        {

                            //var message = string.Format("Please Upload image of type .jpg only");
                            // Todo: Log the error that occurs
                            return BadRequest();
                        }
                        // File size is too big
                        else if (putFile.ContentLength > MaxContentLength)
                        {

                            //var message = string.Format("Please Upload a file upto 1 mb.");

                            // Todo: log the error that occurs
                            return BadRequest();
                        }
                        // Send to production service where functinality to save the file is
                        else
                        {
                            productionService.UploadPhoto(productionId, count, extension, putFile);
                        }
                    }

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
