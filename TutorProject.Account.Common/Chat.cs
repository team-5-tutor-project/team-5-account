namespace TutorProject.Account.Common
{
    public class Chat
    {
        public int ChatId { get; private init; }
        public Tutor Tutor { get; private init; }
        public Client Client { get; private init; }
    }
}