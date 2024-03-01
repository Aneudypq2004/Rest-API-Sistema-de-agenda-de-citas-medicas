using MediatR;
using Medical.Application.UseCase.Features.Auth.Commands.CreateCommand;
using Microsoft.AspNetCore.Mvc;


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

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DoctorController>
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

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
