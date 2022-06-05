using System;

namespace TutorProject.Account.Web.Controllers.ChatController.Dto
{
    public class CreateChatDTO
    {
        public Guid ChatID { get; set; }
        public Guid TutorID { get; set; }
        public Guid ClientID { get; set; }
    }
}