using LibraryManagementSystem.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Features.User;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class UserController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Authorize(Roles = "Admin")]
    [HttpPost("create")]
    public async Task<Create.Response> Create(Create.Request request)
    {

        return await _mediator.Send(request);
    }

}