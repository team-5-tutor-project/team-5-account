using System;

namespace TutorProject.Account.Common.Models
{
    public class Tutor : User
    {
        public WorkFormat WorkFormat { get; private set; }
        
        public int PricePerHour { get; private set; }
        
        public int PupilMinClass { get; private set; }
        
        public int PupilMaxClass { get; private set; }
    }
}