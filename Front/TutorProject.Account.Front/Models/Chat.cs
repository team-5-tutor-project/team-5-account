namespace TutorProject.Account.Front.Models;

public class Chat
{
    public Guid ChatId { get; }
    public string TutorName { get; }
    public string ClientName { get; }

    public Chat(Guid id, string tutorName, string clientName)
    {
        ChatId = id;
        TutorName = tutorName;
        ClientName = clientName;
    }
}