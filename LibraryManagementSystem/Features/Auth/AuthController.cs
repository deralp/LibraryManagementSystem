using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Features.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<Login.Response> Login(Login.Request request)
        {
          return await _mediator.Send(request);
        }
    }
}
