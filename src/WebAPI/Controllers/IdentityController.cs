using Application.RequestModels;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace WebAPI.Controllers;

[Route("api/identity")]
[ApiController]
public class IdentityController : ControllerBase
{
    private readonly IMediator _mediator;
    public IdentityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest request)
    {
        var command = request.Adapt<LoginQuery>();
        var response = await _mediator.Send(command);

        if (response is null) return NoContent();
        return Ok(response);
    }
}
