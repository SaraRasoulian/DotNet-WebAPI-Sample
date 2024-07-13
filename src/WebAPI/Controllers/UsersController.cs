using Application.RequestModels;
using Application.Users.Commands;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId:long}")]
    [Authorize]
    public async Task<IActionResult> Get(long userId)
    {
        var query = new GetUserQuery(userId);
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpPost("{userId:long}/earn")]
    [Authorize]
    public async Task<IActionResult> EarnPoints(long userId, [FromBody] EarnPointsRequest request)
    {
        var command = new EarnPointsCommand(userId, request.Points);
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}