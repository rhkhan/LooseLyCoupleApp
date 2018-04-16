using LooselyCouple.Model.Models;
using LooslyCouple.Service;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LooseLyCoupleApp.Controllers.API
{
    [RoutePrefix("api")]
    public class AppointmentApiController : ApiController
    {
        private IAppointmentService appService;

        public AppointmentApiController(IAppointmentService appServ)
        {
            appService = appServ;
        }


        [HttpGet]
        [Route("appointment")]
        public IEnumerable<Appointment> getAppointmentList()
        {
            IEnumerable<Appointment> allAppointments;
            allAppointments = appService.GetAppointments();
            return allAppointments;
        }

        // POST api/<controller>
        [HttpPost]
        [Route("appointment")]
       public async Task<IHttpActionResult> Post(HttpRequestMessage request,Appointment appoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                if (appoint != null)
                {
                    appService.saveAppointment(appoint);
                }
                return Ok();
            }
        }

        [HttpGet]
        [Route("appointment/info/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var app = appService.GetAppointById(id);
            if (app == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return Request.CreateResponse<Appointment>(HttpStatusCode.OK, app);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("appointment")]
        public void Put(HttpRequestMessage request, Appointment appo)
        {
            appService.UpdateAppointment(appo);
        }


    }
}