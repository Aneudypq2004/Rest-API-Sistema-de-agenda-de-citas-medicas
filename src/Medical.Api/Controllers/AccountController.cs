using Medical.Application.Contracts;
using Medical.Application.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace Medical.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.Login(user);

            if(result == null)
            {
                return BadRequest();
            }


            return Ok(result);
        }

        [HttpGet("/confirm")]
        public async Task<IActionResult> ConfirmAccount(UserForCreationDto userCreation)
        {
            throw new NotImplementedException();
        }

            [HttpPost]
        public async Task<IActionResult> Register(UserForCreationDto userCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.Register(userCreation);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);

                    return BadRequest(ModelState);
                }

            }

            return CreatedAtRoute("GetUser", new { UserId = "1111111111111111111111" }, new { });
        }

        [HttpGet("{UserId}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string UserId)
        {


            return Ok();
        }


    }
}
