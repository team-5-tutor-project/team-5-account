using TutorProject.Account.Common.Models;

namespace TutorProject.Account.Web.Controllers.TutorController.Dto
{
    public class TutorDto
    {
        public string Name { get; set; }
        
        public string Login { get; set; }
        
        public WorkFormat WorkFormat { get; set; }
        
        public string Description { get; set; }
        
        public int PricePerHour { get; set; }
        
        public int PupilMinClass { get; set; }
        
        public int PupilMaxClass { get; set; }
    }
}