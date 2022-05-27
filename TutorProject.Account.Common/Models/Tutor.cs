using System;

namespace TutorProject.Account.Common.Models
{
    public class Tutor : User
    {
        public WorkFormat WorkFormat { get; set; }
        
        public int PricePerHour { get; set; }
        
        public int PupilMinClass { get; set; }
        
        public int PupilMaxClass { get; set; }
    }
}