using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; // For doing async (async Task<>) await
using System.Net.Http;
using System.Web.Http;

namespace BroadwayBuilder.Api
{
    public class UserController : ApiController
    {

        [Route("RegisterUser")]
        [HttpPost]

        public string RegisterUser()
        {
            return "testing";
        }
    }
}
