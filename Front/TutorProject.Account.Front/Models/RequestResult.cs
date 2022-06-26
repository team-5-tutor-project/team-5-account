namespace TutorProject.Account.Front.Models;

public class RequestResult<TResponseDto>
{
    public bool IsSuccessful { get; set; }
    
    public TResponseDto ResponseDto { get; set; }
}