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
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Worker already exists in this project.");
                return (LogicTask.AddTask(value)) ?
                    Request.CreateResponse(HttpStatusCode.Created) :
                    Request.CreateResponse(HttpStatusCode.BadRequest, "Can not add to DB.");
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the worker is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorList);

        }

        [HttpGet]
        [Route("api/Tasks/GetTasksWithWorkerAndProjectByProjectId/{projectId}")]
        public HttpResponseMessage GetTasksWithWorkerAndProjectByProjectId(int projectId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicTask.GetTasksWithWorkerAndProjectByProjectId(projectId));
        }

        [HttpGet]
        [Route("api/Tasks/GetTasksWithWorkerAndProjectByWorkerId/{workerId}")]
        public HttpResponseMessage GetTasksWithWorkerAndProjectByWorkerId(int workerId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicTask.GetTasksWithWorkerAndProjectByWorkerId(workerId));
        }
        [HttpGet]
        [Route("api/Tasks/GetWorkersDictionary/{projectId}")]
        public HttpResponseMessage GetWorkersDictionary(int projectId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicTask.GetWorkersDictionary(projectId));
        }

        [HttpPut]
        [Route("api/Tasks/UpdateTask")]
        public HttpResponseMessage UpdateTask([FromBody]Task value)
        {

            if (ModelState.IsValid)
            {
                return (LogicTask.UpdateTask(value)) ?
                     Request.CreateResponse(HttpStatusCode.Created) :
                    Request.CreateResponse(HttpStatusCode.BadRequest, "Can not update in DB");
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the worker is not valid
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
