using Loan.Leveling.TDD.Domain.Commands;
using Loan.Leveling.TDD.Domain.Repository;
using MediatR;

namespace Loan.Leveling.TDD.Domain.CommandsHandlers;

public class UpdateBirthDateFriendCommandHandle : IRequestHandler<UpdateBirthDateFriend>
{
    private readonly IFriendRepository _friendRepository;

    public UpdateBirthDateFriendCommandHandle(IFriendRepository friendRepository)
    {
        _friendRepository = friendRepository;
    }

    public async Task<Unit> Handle(UpdateBirthDateFriend request, CancellationToken cancellationToken)
    {
        var friend = await _friendRepository.GetById(request.FriendId);
        friend.UpdateBirthDate(request.BirthDate);
        await _friendRepository.SaveChanges();

        return Unit.Task.Result;
    }
}