using BOL;
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
    public class PresentDayController : ApiController
    {
        [HttpGet]
        [Route("api/PresentDay/getAllPressentGroupByUser")]
        public HttpResponseMessage GetAllPressentGroupByUser()
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicPresentDay.GetAllPresents());
        }


        [HttpGet]
        [Route("api/getAllPressentGroupByUserAndProject")]
        public HttpResponseMessage getAllPressentGroupByUserAndProject()
        {
            return Request.CreateResponse(HttpStatusCode.OK, LogicPresentDay.GetAllPresents());
        }

        [HttpPost]
        [Route("api/PresentDay/AddPresent")]
        public HttpResponseMessage AddPresent([FromBody]PresentDay value)
        {
            if (ModelState.IsValid)
            {
                int id = LogicPresentDay.AddPresent(value);
                return id != 0 ?
                      Request.CreateResponse(HttpStatusCode.OK, id) :
                      Request.CreateResponse(HttpStatusCode.BadRequest, "Can not add to DB");
            };

            List<string> ErrorList = new List<string>();

            //if the code reached this part - the user is not valid
            foreach (var item in ModelState.Values)
                foreach (var err in item.Errors)
                    ErrorList.Add(err.ErrorMessage);

            return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorList);

        }

        [HttpPut]
        [Route("api/PresentDay/UpdatePresentDay")]
        public HttpResponseMessage UpdatePresentDay([FromBody]PresentDay value)
        {
            if (ModelState.IsValid)
            {
                return LogicPresentDay.UpdatePresent(value) ?
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
        [Route("api/PresentDay/RemovePresent")]
        public HttpResponseMessage Delete(int id)
        {
            return LogicPresentDay.RemovePresent(id) ?
                Request.CreateResponse(HttpStatusCode.OK) :
                     Request.CreateResponse(HttpStatusCode.BadRequest, "Can not remove from DB");

        }
    }
}
