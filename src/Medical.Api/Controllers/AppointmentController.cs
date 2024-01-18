using MediatR;
using Medical.Application.Dtos.Appoinment.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Authorize()]
    [Route("api/{DoctorId}")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public ActionResult GetAllAppointment()
        {
            var result = _mediator.Send(new GetAppoinmentsDto());

            return Ok(result.Result); ;
        }
    }
}
