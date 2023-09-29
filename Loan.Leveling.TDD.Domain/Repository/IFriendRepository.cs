using Loan.Leveling.TDD.Domain.Model;

namespace Loan.Leveling.TDD.Domain.Repository;

public interface IFriendRepository
{
    public Task<Friend> GetById(Guid id);
    public Task SaveChanges();
}