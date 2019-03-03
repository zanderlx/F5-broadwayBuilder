using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BroadwayBuilder.Api.Controllers
{
    public class ProductionController : ApiController
    {
        [Route("production/{productionId}/uploadProgram")]
        [HttpPut]
        // Author: Debendra Dash
        // Date: 02-17-16
        //Edited: Abi
        public IHttpActionResult UploadProductionProgram(Guid productionId)
        {
            //try to upload pdf and save to server
            try
            {
                //get the content, headers, etc the full request of the current http request
                var httpRequest = HttpContext.Current.Request;

                foreach (string filename in httpRequest.Files)
                {   
                    var putFile = httpRequest.Files[filename];
                    if (putFile != null && putFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB

                        //A list in case we want to accept more than one file type
                        IList<string> AllowedFileExtension = new List<string> { ".pdf" };
                        var ext = putFile.FileName.Substring(putFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        // If its not an appropriate file extension
                        if (!AllowedFileExtension.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .pdf only");

                            //dict.Add("error", message);
                            // Log the error that occurs
                            return BadRequest();
                        }
                        else if (putFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            //dict.Add("error", message);
                            //log the error that occurs
                            return BadRequest();
                        }
                        else
                        {

                            //if needed write the code to update the table

                            var filePath = HttpContext.Current.Server.MapPath("~/ProductionPrograms/" + productionId + extension);
                            //Userimage myfolder name where i want to save my image
                            putFile.SaveAs(filePath);

                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    //return Created(insert path);
                    //return Created("C:\\Users\\ProductionPrograms");
                    return Ok("Pdf Uploaded");
                }
                var res = string.Format("Please Upload an image.");
                //dict.Add("error", res);
                //log the error that occurs
                return BadRequest();
            }

                catch (Exception ex) {
                //log error
                return BadRequest();
               
                }
        }


    }
}
