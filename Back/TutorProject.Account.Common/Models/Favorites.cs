using System;

namespace TutorProject.Account.Common.Models
{
    public class Favorites
    {
        public Guid Id { get; init; }
        
        public Client Client { get; init; }
        
        public Tutor Tutor { get; init; }
    }
}