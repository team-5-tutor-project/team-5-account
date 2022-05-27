using System;

namespace TutorProject.Account.Web.Controllers.Dto.Client
{
    public class ClientSignInDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }
    }
}