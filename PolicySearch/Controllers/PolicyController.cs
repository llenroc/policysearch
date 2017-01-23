using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PolicySearch.Controllers
{
    public class PolicyController : ApiController
    {        
        [HttpPost]
        public IHttpActionResult PostPolicies(Models.SearchDetails searchDetails)
        {
            return Ok();
        }
    }
}
