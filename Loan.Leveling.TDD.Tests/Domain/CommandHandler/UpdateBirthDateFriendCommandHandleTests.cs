using FluentAssertions;
using Loan.Leveling.TDD.Domain.Commands;
using Loan.Leveling.TDD.Domain.CommandsHandlers;
using Loan.Leveling.TDD.Domain.Model;
using Loan.Leveling.TDD.Domain.Repository;
using Moq;

namespace Loan.Leveling.TDD.Tests.Domain.CommandHandler;

public class UpdateBirthDateFriendCommandHandleTests
{
    private readonly Mock<IFriendRepository> _friendRepository = new();
    private readonly UpdateBirthDateFriendCommandHandle _sut;

    public UpdateBirthDateFriendCommandHandleTests()
    {
        _sut = new UpdateBirthDateFriendCommandHandle(_friendRepository.Object);
    }

    [Fact]
    public async Task Handle_GivenValidDataWithSameBirthDate_ShouldNotUpdateEntity()
    {
        var friend = new Friend(Guid.NewGuid(), "Jr", DateTime.Today);
        _friendRepository.Setup(x => x.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(friend);

        var actualVersion = friend.Version;
        var actualLastUpdate = friend.LastUpdate;

        var command = new UpdateBirthDateFriend(friend.Id, DateTime.Today);

        await _sut.Handle(command, new CancellationToken());

        friend.Version.Should().Be(actualVersion);
        friend.LastUpdate.Should().Be(actualLastUpdate);
    }
    
    [Fact]
    public async Task Handle_GivenValidData_ShouldUpdateEntity()
    {
        var friend = new Friend(Guid.NewGuid(), "Jr", DateTime.Today.AddDays(-1));
        _friendRepository.Setup(x => x.GetById(It.IsAny<Guid>()))
            .ReturnsAsync(friend);

        var actualVersion = friend.Version;
        var actualLastUpdate = friend.LastUpdate;

        var command = new UpdateBirthDateFriend(friend.Id, DateTime.Today);

        await _sut.Handle(command, new CancellationToken());

        friend.Version.Should().NotBe(actualVersion);
        friend.LastUpdate.Should().NotBe(actualLastUpdate);
        friend.BirthDate.Should().Be(DateTime.Today);
    }

}