
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

     
        //get asll users (manager-team heads- workers):
        [HttpGet]
        [Route("api/Users/getAllUsers")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetAllUsers());
        }

        //get all team heads:
        [HttpGet]
        [Route("api/Users/GetAllTeamHeads")]
        public HttpResponseMessage GetAllTeamHeads()
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetAllTeamHeads());
        }

        //get all workers(DEV-QA-UIUX):
        [HttpGet]
        [Route("api/Users/GetAllWorkers")]
        public HttpResponseMessage GetAllWorkers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetAllWorkers());
        }

        //get all workers that are not belong to this team head (gets team head id):
        [HttpGet]
        [Route("api/Users/GetAllowedWorkers/{teamHeadId}")]
        public HttpResponseMessage GetAllowedWorkers(int teamHeadId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetAllowedWorkers(teamHeadId));
        }

        //get all workers that are belong to this team head (gets team head id):
        [HttpGet]
        [Route("api/Users/GetWorkersByTeamhead/{teamHeadId}")]
        public HttpResponseMessage GetWorkersByTeamhead(int teamHeadId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetWorkersByTeamhead(teamHeadId));
        }

        //get user by id:
        [HttpGet]
        [Route("api/Users/getUserDetails/{id}")]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.GetUserDetails(id));
        }

        //send message to manager (gets EmailParams object that contains user id, subject and message):
        [HttpPost]                                                       
        [Route("api/Users/sendMessageToManager")]                        
        public HttpResponseMessage sendMessageToManager([FromBody]EmailParams emailParams)
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicManager.sendEmailToManager(emailParams.idUser, emailParams.message, emailParams.subject));
        }

        //add user to DB (gets User object):
        [HttpPost]
        [Route("api/Users/addUser")]
        public HttpResponseMessage Post([FromBody]User value)
        {
            if (ModelState.IsValid)
            {
                return (LogicManager.AddUser(value)) ?
                    Request.CreateResponse(HttpStatusCode.Created) :
                    Request.CreateResponse(HttpStatusCode.BadRequest, "Can not add to DB");
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);
            return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorList);
        }

        //login to system with user name and password (gets LoginUser object that contains name and password):
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
                    Request.CreateResponse(HttpStatusCode.BadRequest, "can not login with those details");

            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorList);

        }

        //login by computer (gets ComputerLogin object taht contains ComputerIp):
        [HttpPost]
        [Route("api/Users/LoginByComputerUser")]
        public HttpResponseMessage LoginByComputerUser([FromBody]ComputerLogin computerLogin)
        {
            User user = LogicManager.GetUserDetailsComputerUser(computerLogin.ComputerIp);
            return user != null ?
                 Request.CreateResponse(HttpStatusCode.Created, user) :
                    Request.CreateResponse(HttpStatusCode.BadRequest, "Can not add to DB");

        }

        //update user details (gets User object for updating);
        [HttpPut]
        [Route("api/Users/UpdateUser")]
        public HttpResponseMessage UpdateUser([FromBody]User value)
        {

            if (ModelState.IsValid)
            {
                return LogicManager.UpdateUser(value) ?
                     Request.CreateResponse(HttpStatusCode.Created) :
                    Request.CreateResponse(HttpStatusCode.BadRequest, "Can not update in DB");
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorList);
        }

        //delete user from DB (gets the userId):
        [HttpDelete]
        [Route("api/Users/RemoveUser/{userId}")]
        public HttpResponseMessage Delete(int userId)
        {
            return LogicManager.RemoveUser(userId) ?
                 Request.CreateResponse(HttpStatusCode.OK) :
                    Request.CreateResponse(HttpStatusCode.BadRequest, "Can not remove from DB");
        }

    }
}
