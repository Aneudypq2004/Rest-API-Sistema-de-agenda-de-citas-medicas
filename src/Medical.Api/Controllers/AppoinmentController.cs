using MediatR;
using Medical.Application.Dtos.Appoinment.Request;
using Medical.Application.UseCase.Features.Appoinments.Commands.CreateCommand;
using Medical.Application.UseCase.Features.Appoinments.Commands.DeleteCommand;
using Medical.Application.UseCase.Features.Appoinments.Commands.UpdateCommand;
using Medical.Application.UseCase.Features.Appoinments.Queries.GetAllQuery;
using Medical.Application.UseCase.Features.Appoinments.Queries.GetByIdQuery;
using Microsoft.AspNetCore.Mvc;


namespace Medical.Api.Controllers
{
    [Route("api/{DoctorId}/appoinment")]
    [ApiController]
    public class AppoinmentController : ControllerBase
    {
        private readonly IMediator mediator;

        public AppoinmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        

        [HttpGet("{id}", Name = "GetAppoinmetById")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await mediator.Send(new GetAppointmentByIdQuery()
            {
                Id = id
            });

            return Ok(result);
        }

        [HttpGet(Name = "GetAllAppoinmet")]
        public async Task<ActionResult> GetAll(string DoctorId)
        {
            var result = await mediator.Send(new GetAllAppoinmentQuery
            {
                Id = DoctorId
          
            });

            return Ok(result.Data);
        }


        [HttpPost("{Id}")]
        public async Task<ActionResult> Post([FromBody] AppoinmentCreationDto appoinment, string DoctorId, string Id)
        {
           var result = await  mediator.Send(new CreateAppoinmentCommand
            {
                NewAppoinment = appoinment,
                DoctorId = DoctorId,
                PatientId = Id
            });

            return CreatedAtRoute("GetAppoinmetById", new { DoctorId, id = result.Data!.Id}, result.Data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id)
        {
            var result = await mediator.Send(new UpdateAppoinmentCommand());

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteAppoinmentCommand()
            {
                AppointmentId = id
            });

            return Ok(result);
        }
    }
}
