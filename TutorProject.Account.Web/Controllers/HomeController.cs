using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.Common;
using TutorProject.Account.BLL.Clients.Services;
using TutorProject.Account.BLL.Tutors.Services;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.Dto;
using TutorProject.Account.Web.Controllers.Dto.Client;
using TutorProject.Account.Web.Controllers.Dto.Tutor;

namespace TutorProject.Account.Web.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly TutorContext _tutorContext;
        private readonly IClientService _clientService;
        private readonly ITutorService _tutorService;
        
        public HomeController(TutorContext tutorContext)
        {
            _tutorContext = tutorContext;
        }
        
        [HttpGet("/hello")]
        public string Hello()
        {
            return "Hello World!";
        }
        
        [HttpGet("/sign_up")]
        public Task<Guid> SignUpClient(ClientSignUpDto ClientSignUp)
        {
            var client = new Client
            {
                Id = Guid.NewGuid(),
                Login = ClientSignUp.Login,
                Name = ClientSignUp.Name,
                Password = ClientSignUp.Password
            };

            return _clientService.SignUp(client);
        }
        
        [HttpGet("/sign_up")]
        public Task<Guid> SignUpTutor(TutorSignUpDto TutorSignUp)
        {
            var tutor = new Tutor
            {
                Id = Guid.NewGuid(),
                Login = TutorSignUp.Login,
                Name = TutorSignUp.Name,
                Password = TutorSignUp.Password
            };

            return _tutorService.SignUp(tutor);
        }
        
        [HttpGet("/sign_in")]
        public Task<Guid> SignInClient(ClientSignInDto ClientSignIn)
        {
            var client = new Client
            {
                Id = ClientSignIn.Id,
                Login = ClientSignIn.Login,
                Name = ClientSignIn.Name,
                Password = ClientSignIn.Password
            };

            return _clientService.SignIn(client);
        }
        
        [HttpGet("/sign_in")]
        public Task<Guid> SignInTutor(TutorSignInDto TutorSignIn)
        {
            var tutor = new Tutor
            {
                Id = TutorSignIn.Id,
                Login = TutorSignIn.Login,
                Name = TutorSignIn.Name,
                Password = TutorSignIn.Password
            };

            return _tutorService.SignIn(tutor);
        }
    }
}