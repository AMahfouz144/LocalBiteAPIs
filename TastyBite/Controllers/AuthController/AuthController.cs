using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Usecase.Auth.Commands;
using API.Responses;


namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AuthController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
		{
			var token = await _mediator.Send(command);
			return Ok(new { AccessToken = token });
		}
        [HttpPost("login")]
        public async Task<LoginResponse> Login([FromBody] LoginUserCommand command)
        {
            var token = await _mediator.Send(command);
            return new LoginResponse { token = token };
        }

    }
}