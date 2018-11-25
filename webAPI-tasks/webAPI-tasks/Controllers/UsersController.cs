
using BOL;
using BLL;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using BOL.HelpModel;
using System.Web.Http.Cors;

namespace webAPI_tasks.Controllers
{


    //--------------------------------
    [EnableCors("*", "*", "*")]
    public class UsersController : ApiController
    {

     

        [HttpGet]
        [Route("api/Users/getAllUsers")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetAllUsers());
        }

        [HttpGet]
        [Route("api/Users/GetAllTeamHeads")]
        public HttpResponseMessage GetAllTeamHeads()
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetAllTeamHeads());
        }

        [HttpGet]
        [Route("api/Users/GetAllWorkers")]
        public HttpResponseMessage GetAllWorkers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetAllWorkers());
        }

        [HttpGet]
        [Route("api/Users/GetAllowedWorkers/{id}")]
        public HttpResponseMessage GetAllowedWorkers(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetAllowedWorkers(id));
        }


        [HttpGet]
        [Route("api/Users/GetWorkersByTeamhead/{id}")]
        public HttpResponseMessage GetWorkersByTeamhead(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetWorkersByTeamhead(id));
        }

        [HttpGet]
        [Route("api/Users/getUserDetails/{id}")]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetUserDetails(id));
        }


        [HttpPost]
        [Route("api/Users/sendMessageToManager")]
        public HttpResponseMessage sendMessageToManager([FromBody]EmailParams emailParams)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.sendEmailToManager(emailParams.idUser, emailParams.message, emailParams.subject));
        }

        [HttpPost]
        [Route("api/Users/addUser")]
        public HttpResponseMessage Post([FromBody]User value)
        {
            if (ModelState.IsValid)
            {
                return (LogicManager.AddUser(value)) ?
                    Request.CreateResponse(HttpStatusCode.OK) :
                    Request.CreateResponse(HttpStatusCode.BadRequest, "Can not add to DB");
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);
            return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorList);
        }

        [HttpPost]
        [Route("api/Users/loginByPassword")]

        public HttpResponseMessage LoginByPassword([FromBody]LoginUser value)
        {
            if (ModelState.IsValid)
            {
                User user = LogicManager.GetUserDetailsByPassword(value.Password, value.UserName);
                //TODO:TOKEN
                return user != null ?
                    Request.CreateResponse(HttpStatusCode.Created, user) :
                    Request.CreateResponse(HttpStatusCode.BadRequest, "This user does not exist");

            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorList);

        }
        [HttpPost]
        [Route("api/Users/LoginByComputerUser")]
        public HttpResponseMessage LoginByComputerUser([FromBody]ComputerLogin computerLogin)
        {

            User user = LogicManager.GetUserDetailsComputerUser(computerLogin.ComputerIp);
            //TODO:TOKEN
            return user != null ?
                 Request.CreateResponse(HttpStatusCode.Created, user) :
                    Request.CreateResponse(HttpStatusCode.BadRequest, "Can not add to DB");

        }

        [HttpPut]
        [Route("api/Users/UpdateUser")]
        public HttpResponseMessage UpdateUser([FromBody]User value)
        {

            if (ModelState.IsValid)
            {
                return LogicManager.UpdateUser(value) ?
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

        [HttpDelete]
        [Route("api/Users/RemoveUser/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            return LogicManager.RemoveUser(id) ?
                 Request.CreateResponse(HttpStatusCode.OK) :
                    Request.CreateResponse(HttpStatusCode.BadRequest, "Can not remove from DB");
        }

    }
}
