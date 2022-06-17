using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Authorization
{
    public class RightsCheckResult
    {
        public User AuthorizedUser { get; set; }
        
        public bool IsSuccessful { get; set; }
        
        public string ErrorMessage { get; set; }
    }
}