namespace Loan.Leveling.TDD.Domain.Model;

public abstract class Entity
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdate { get; set; }
    public ushort Version { get; private set; }

    public Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    public void IncrementVersion()
    {
        Version += 1;
        LastUpdate = DateTime.Today;
    }
    
    public void DecrementVersion()
    {
        Version -= 1;
        LastUpdate = DateTime.Today;
    }
}