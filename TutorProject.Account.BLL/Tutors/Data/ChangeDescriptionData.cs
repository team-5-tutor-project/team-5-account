using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Tutors.Data
{
    public class ChangeDescriptionData
    {
        public WorkFormat? WorkFormat { get; set; }
        
        public string Description { get; set; }
        
        public int? PricePerHour { get; set; }
        
        public int? PupilMinClass { get; set; }
        
        public int? PupilMaxClass { get; set; }
    }
}