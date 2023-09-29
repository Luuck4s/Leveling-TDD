using MediatR;

namespace Loan.Leveling.TDD.Domain.Commands;

public class UpdateBirthDateFriend : IRequest
{
    public Guid FriendId { get; set; }
    public DateTime BirthDate { get; set; }

    public UpdateBirthDateFriend(Guid friendId, DateTime birthDate)
    {
        FriendId = friendId;
        BirthDate = birthDate;
    }
    
}