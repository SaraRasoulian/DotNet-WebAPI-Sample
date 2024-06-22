using Application.RequestModels;
using Application.Users.Commands;
using MediatR;
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

    //[Authorize]
    [HttpPost("{id:long}/earn")]
    public async Task<IActionResult> EarnPoints(long id, [FromBody] EarnPointsRequest request)
    {
        var command = new EarnPointsCommand(id, request.Points);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
