namespace TutorProject.Account.Front.Models;

public class RequestResult<TRequestDto>
{
    public bool IsSuccessful { get; set; }
    
    public TRequestDto Result { get; set; }
}