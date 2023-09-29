using Loan.Leveling.TDD.Domain.Model;

namespace Loan.Leveling.TDD.Domain.Repository;

public class FriendRepository : IFriendRepository
{
    public Task<Friend> GetById(Guid id)
    {
        Thread.Sleep(500);
        return Task.FromResult(new Friend(id, "John Doe", new DateTime(2023, 09, 29)));
    }

    public async Task SaveChanges()
    {
        Thread.Sleep(500);
    }
}