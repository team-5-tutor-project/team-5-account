using System;

namespace TutorProject.Account.Common.Models
{
    public class User
    {
        public Guid Id { get; init; }
        
        public string Name { get; init; }
        
        public string Login { get; init; }

        public string Password { get; init; }
    }
}