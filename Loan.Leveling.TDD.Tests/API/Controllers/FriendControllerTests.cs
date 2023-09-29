using FluentAssertions;
using Loan.Leveling.TDD.Contracts.v1.Requests;
using Loan.Leveling.TDD.Controllers;
using Loan.Leveling.TDD.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Loan.Leveling.TDD.Tests.API.Controllers;

public class FriendControllerTests
{
    private readonly FriendController _friendController;
    private readonly Mock<IMediator> _mediatorMock = new();

    public FriendControllerTests()
    {
        _friendController = new FriendController(_mediatorMock.Object);
    }

    [Fact]
    public async Task UpdateBirthDateFriend_GivenValidData_ShouldReturnOkAndSendCommand()
    {
        // Arrange
        var friendId = Guid.NewGuid();
        var friendRequest = new UpdateBirthDateFriendRequest()
        {
            BirthDate = DateTime.Today
        };

        // Act
        var result = await _friendController.UpdateBirthDateFriend(friendId, friendRequest);

        // Assert
        _mediatorMock.Verify(
            x => x.Send(It.IsAny<UpdateBirthDateFriend>(), It.IsAny<CancellationToken>()),
            Times.Once
        );
        result.Should().BeOfType<OkResult>();
    }
}