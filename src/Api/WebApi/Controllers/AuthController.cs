using Application.Features.Auths.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator  _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand request)
        {
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            var result = await _mediator.Send(request);
            switch (result.StatusCode)
            {
                case 404:
                    return NotFound(result);
                    break;
                case 401:
                    return Unauthorized(result);
                    break;
                default:
                    break;
            }
            return Ok(result);
        }

        
    }
}
