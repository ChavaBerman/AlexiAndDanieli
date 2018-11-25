using BLL;
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
    public class TaskController : ApiController
    {
        [HttpPost]
        [Route("api/Tasks/AddTask")]
        public HttpResponseMessage Post([FromBody] Task value)
        {
            if (ModelState.IsValid)
            {
                if (LogicTask.CheckIfExists(value))
                    return Request.CreateResponse(HttpStatusCode.Found, "Worker already exists in this project.");
                return (LogicTask.AddTask(value)) ?
                    Request.CreateResponse(HttpStatusCode.Created) :
                    Request.CreateResponse(HttpStatusCode.BadRequest, "Can not add to DB.");
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorList);

        }

        [HttpGet]
        [Route("api/Tasks/GetTasksWithUserAndProjectByProjectId/{projectId}")]
        public HttpResponseMessage GetTasksWithUserAndProjectByProjectId(int projectId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicTask.GetTasksWithUserAndProjectByProjectId(projectId));
        }

        [HttpGet]
        [Route("api/Tasks/GetTasksWithUserAndProjectByUserId/{userId}")]
        public HttpResponseMessage GetTasksWithUserAndProjectByUserId(int userId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicTask.GetTasksWithUserAndProjectByUserId(userId));
        }
        [HttpGet]
        [Route("api/Tasks/GetWorkersDictionary/{projectId}")]
        public HttpResponseMessage GetWorkersDictionary(int projectId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicTask.GetWorkersDictionary(projectId));
        }

        [HttpPut]
        [Route("api/Tasks/UpdateTask")]
        public HttpResponseMessage Put([FromBody]Task value)
        {

            if (ModelState.IsValid)
            {
                return (LogicTask.UpdateTask(value)) ?
                     Request.CreateResponse(HttpStatusCode.OK) :
                    Request.CreateResponse(HttpStatusCode.BadRequest, "Can not update in DB");
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorList);
        }

        [HttpGet]
        [Route("api/Tasks/GetWorkerTasksDictionary/{workerId}")]
        public HttpResponseMessage GetWorkerTasksDictionary(int workerId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicTask.GetWorkerTasksDictionary(workerId));
        }
    }
}
