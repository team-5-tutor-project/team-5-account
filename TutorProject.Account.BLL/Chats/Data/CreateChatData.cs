using System;

namespace TutorProject.Account.BLL.Chats.Data
{
    public class CreateChatData
    {
        public Guid ChatID { get; set; }
        public Guid TutorID { get; set; }
        public Guid ClientID { get; set; }
    }
}