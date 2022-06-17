using System;

namespace TutorProject.Account.Web.Controllers.Authorization.Dto
{
    public class AuthorizedUserDto
    {
        public Guid UserId { get; set; }
        
        public string UserType { get; set; }
    }
}