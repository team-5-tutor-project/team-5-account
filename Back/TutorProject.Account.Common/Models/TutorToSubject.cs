using System;

namespace TutorProject.Account.Common.Models
{
    public class TutorToSubject
    {
        public Guid Id { get; init; }
        
        public Tutor Tutor { get; init; }
        
        public Subject Subject { get; init; }
    }
}