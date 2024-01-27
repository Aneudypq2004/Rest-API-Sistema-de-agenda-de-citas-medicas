using MediatR;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.UseCases.Appointment.Commands.CreateCommand;
using Medical.Application.UseCase.UseCases.Appointment.Queries.GetAllQuery;
using Medical.Application.UseCase.UseCases.Appointment.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{

    [Route("api/appoinment/{DoctorId}")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;


        public AppointmentController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllAppointment(string DoctorId)
        {

            var result = await _mediator.Send(new GetAllAppoinmentsQuery()
            {
                DoctorId = DoctorId
            });

            if (!result.IsSuccess) return NotFound(new { msg = result.Message });

            return Ok(result.Data); ;
        }


        [HttpGet("{AppoinmentId}")]
        public async Task<ActionResult> GetAppoinmentById(string DoctorId, int AppoinmentId)
        {
            var result = await _mediator.Send(new GetAppoinmentByIdQuery()
            {
                Id = DoctorId,
                AppoinmentId = AppoinmentId
            });

            if (!result.IsSuccess) return NotFound(new { msg = result.Message });

            return Ok(result.Data); ;

        }

        [HttpPost]
        public async Task<ActionResult> CreateAppoinment(AppoinmentCreationDto appoinmentCreation, string DoctorId)
        {

            await _mediator.Send(new CreateAppoinmentCommand
            {
                DoctorId = DoctorId,
                AppoinmentCreation = appoinmentCreation
            });

            return NoContent();
        }
    }
}
