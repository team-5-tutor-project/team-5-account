using System;

namespace TutorProject.Account.Common.Models
{
    public class Chat
    {
        public Guid ChatId { get; init; }
        
        public Tutor Tutor { get; init; }
        
        public Client Client { get; init; }
    }
}