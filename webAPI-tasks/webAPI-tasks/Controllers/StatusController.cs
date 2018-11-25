using BLL;
using BOL;
using BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace webAPI_tasks.Controllers
{
    [EnableCors("*", "*", "*")]
    public class StatusController : ApiController
    {
        [HttpGet]
        [Route("api/Status/GetAllstatuses")]
        public HttpResponseMessage GetAllstatuses()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Logicstatus.GetAllstatuses());
        }

    }
}
