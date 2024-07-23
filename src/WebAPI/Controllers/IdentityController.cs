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
        var query = request.Adapt<LoginQuery>();
        var response = await _mediator.Send(query);

        return Ok(response);
    }
}
