using System;

namespace TutorProject.Account.Common.Models
{
    public class Chat
    {
        public Guid ChatId { get; private init; }
        
        public Tutor Tutor { get; private init; }
        
        public Client Client { get; private init; }
    }
}