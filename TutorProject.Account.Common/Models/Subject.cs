using System;

namespace TutorProject.Account.Common.Models
{
    public class Subject
    {
        public Guid Id { get; private init; }
        
        public string Name { get; private init; }
    }
}