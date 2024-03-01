using MediatR;
using Medical.Application.UseCase.Features.Auth.Commands.CreateCommand;
using Medical.Application.UseCase.Features.Auth.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator mediator;

        public DoctorController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("{DoctorId}")]
        public async Task<ActionResult> Get(string DoctorId)
        {
            var result = await mediator.Send(new GetUserByIdQuery()
            {
                Id = DoctorId
            });

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateDoctorCommand command)
        {
            var result = await mediator.Send(command);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);

                }

                return BadRequest(ModelState);
            }

            return NoContent();
        }

     
    }
}
