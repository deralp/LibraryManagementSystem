using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Features.Loan
{
    [Authorize(Roles = "Admin, Librarian")]
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController
    {
        private readonly IMediator _mediator;

        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<Create.Response> Create(Create.Request request)
        {

            return await _mediator.Send(request);
        }
        [Authorize]
        [HttpPost("update")]
        public async Task<Update.Response> Create(Update.Request request)
        {

            return await _mediator.Send(request);
        }
    }
}
