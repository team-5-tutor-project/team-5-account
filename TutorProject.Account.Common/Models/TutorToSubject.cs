using System;

namespace TutorProject.Account.Common.Models
{
    public class TutorToSubject
    {
        public Guid Id { get; private init; }
        
        public Tutor Tutor { get; private init; }
        
        public Subject Subject { get; private init; }
    }
}