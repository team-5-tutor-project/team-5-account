using System;

namespace TutorProject.Account.Common.Models
{
    public class User
    {
        public Guid Id { get; private init; }
        
        public string Name { get; private init; }
        
        public string Login { get; private init; }
        
        public string Password { get; private init; }
    }
}