using LibraryManagementSystem.Features.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Features.Book
{
    [Authorize(Roles = "Admin, Librarian")]
    [ApiController]
    [Route("api/[controller]")]
    public class BookController
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<Create.Response> Create(Create.Request request)
        {
            return await _mediator.Send(request); 
        }
        [HttpPost("isavailable")]
        public async Task<IsAvailable.Response> IsAvailable(IsAvailable.Request request)
        {

            return await _mediator.Send(request);
        }
        [HttpGet("get")]
        public async Task<Get.Response> Get()
        {
            var request = new Get.Request();
            return await _mediator.Send(request);
        }
        [HttpDelete("delete")]
        public async Task<Delete.Response> Delete(Delete.Request request)
        {
            return await _mediator.Send(request);
        }
        [HttpPost("update")]
        public async Task<Update.Response> Update(Update.Request request)
        {

            return await _mediator.Send(request);
        }
    }
}
