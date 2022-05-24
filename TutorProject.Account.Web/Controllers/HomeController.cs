using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.Common;

namespace TutorProject.Account.Web.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly TutorContext _tutorContext;
        
        public HomeController(TutorContext tutorContext)
        {
            _tutorContext = tutorContext;
        }
        
        [HttpGet("/hello")]
        public string Hello()
        {
            return "Hello World!";
        }
    }
}