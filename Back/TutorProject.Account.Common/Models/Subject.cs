using System;

namespace TutorProject.Account.Common.Models
{
    public class Subject
    {
        public Guid Id { get; init; }
        
        public string Name { get; init; }

        public Subject(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        private Subject()
        {
            
        }
    }
}