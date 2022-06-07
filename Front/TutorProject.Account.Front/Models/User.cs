namespace TutorProject.Account.Front.Models;

public abstract class User
{
    protected User(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }
        
    public string Name { get; }
}