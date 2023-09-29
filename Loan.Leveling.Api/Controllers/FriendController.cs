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
}