using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BroadwayBuilder.Api.Controllers
{
    public class UserHelpWantedController : ApiController
    {
        [HttpPost]
        [Route("helpwanted/upload_resume")]
        public IHttpActionResult UploadResume()
        {
            // Max file size is 1MB
            int MaxFileSize = 1024 * 1024 * 1;

            // Obtains the request when this endpoint is called
            var httpRequest = HttpContext.Current.Request;

            // List of allowed file extensions. Increases scalability when we
            // want to allow more file extensions.
            IList<string> AllowedFileExtensions = new List<string> { ".pdf" };

            // Loops through the files from the request
            foreach (string file in httpRequest.Files)
            {
                // Gets the current file from the request
                var postedFile = httpRequest.Files[file];

                // Continue with the file upload if the current file has content
                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    // Checks the current extension of the current file
                    var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();

                    // File extension is not valid
                    if (!AllowedFileExtensions.Contains(extension))
                    {
                        return Content((HttpStatusCode)400, postedFile.FileName);
                    }
                    // File size is too big
                    else if (postedFile.ContentLength > MaxFileSize)
                    {
                        return Content((HttpStatusCode)400, postedFile.ContentLength);
                    }
                    // Save file in the directory chosen
                    else
                    {
                        //Resume resume = new Resume(User.UserID,Guid.NewGuid());
                        //userService.CreateResume(resume);
                        //var results = dbcontext.SaveChanges();

                        // Directory of where the uploaded files will be stored
                        var filePath = HttpContext.Current.Server.MapPath("~/Resumes/" + postedFile.FileName);
                        postedFile.SaveAs(filePath);
                        return Content((HttpStatusCode) 200, "File Uploaded!");
                    }
                }
            }
            // File not uploaded to form
            return Content((HttpStatusCode)200, "Please upload a file!");
        }
    }
}
