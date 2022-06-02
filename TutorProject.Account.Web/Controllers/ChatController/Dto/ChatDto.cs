using System;

namespace TutorProject.Account.Web.Controllers.ChatController.Dto
{
    public class ChatDto
    {
        public Guid ChatId { get; set; }
        public string TutorName { get; set; }
        public string ClientName { get; set; }
    }
}