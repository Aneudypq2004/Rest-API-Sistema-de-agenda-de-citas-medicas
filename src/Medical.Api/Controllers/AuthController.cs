using MediatR;
using Medical.Application.Dtos.User;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medical.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IMediator mediator;

        [HttpPost]
        public void Login([FromBody] UserForLoginDto credentials)
        {

        }

        
    }
}
