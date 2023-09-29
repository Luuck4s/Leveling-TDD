using Loan.Leveling.TDD.Contracts.v1.Requests;
using Loan.Leveling.TDD.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Loan.Leveling.TDD.Controllers;

[ApiController]
[Route("[controller]")]
public class FriendController : ControllerBase
{
    private readonly IMediator _mediator;

    public FriendController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateBirthDateFriend(
        Guid friendId,
        UpdateBirthDateFriendRequest request
    )
    {
        var command = new UpdateBirthDateFriend(friendId, request.BirthDate);
        await _mediator.Send(command);
        return Ok();
    }
}