using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Tutors.Result
{
    public class TutorLogInResult
    {
        public string Name { get; set; }
        
        public WorkFormat WorkFormat { get; set; }
        
        public int PricePerHour { get; set; }
        
        public int PupilMinClass { get; set; }
        
        public int PupilMaxClass { get; set; }
    }
}