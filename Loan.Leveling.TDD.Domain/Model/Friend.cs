namespace Loan.Leveling.TDD.Domain.Model;

public class Friend : Entity
{
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }

    public Friend(Guid id, string name, DateTime birthDate)
    {
        Id = id;
        Name = name;
        BirthDate = birthDate;
    }

    public void UpdateBirthDate(DateTime birthDate)
    {
        if (birthDate == BirthDate)
        {
            return;
        }
        BirthDate = birthDate;
        IncrementVersion();
    }
}