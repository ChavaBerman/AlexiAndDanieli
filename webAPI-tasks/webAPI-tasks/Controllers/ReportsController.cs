using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace webAPI_tasks.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ReportsController : ApiController
    {
        [HttpGet]
        [Route("api/Reports/GetReportData")]
        public HttpResponseMessage GetReportData()
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicReports.CreateReport());
        }
        [HttpGet]
        [Route("api/Reports/FilterReport/{requiredMonth}/{projectName}/{teamHeadName}/{workerName}")]
        public HttpResponseMessage FilterReport([FromUri]int requiredMonth, [FromUri]string projectName, [FromUri] string teamHeadName, [FromUri]string workerName)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicReports.FilterReport( requiredMonth,  projectName,  teamHeadName, workerName));
        }
    }
}
