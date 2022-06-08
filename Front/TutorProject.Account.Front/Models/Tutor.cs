using TutorProject.Account.Common.Models;

namespace TutorProject.Account.Front.Models;

public class Tutor : User
{
    public WorkFormat WorkFormat { get; init; }
        
    public string? Description { get; init; }
        
    public int? PricePerHour { get; init; }
        
    public int? PupilMinClass { get; init; }
        
    public int? PupilMaxClass { get; init; }

    public Tutor(Guid id, string name) : base(id, name)
    {
        
    }
}