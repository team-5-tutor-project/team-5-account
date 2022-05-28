using System;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        
        public HomeController(TutorContext tutorContext)
        {
            _tutorContext = tutorContext;
        }
        
        [HttpGet("/hello")]
        public string Hello()
        {
            return "Hello World!";
        }
        
        [HttpPost("/sign_up")]
        public Task<Guid> SignUpClient(ClientSignUpDto ClientSignUp)
        {
            var client = new Client
            {
                Id = Guid.NewGuid(),
                Login = ClientSignUp.Login,
                Name = ClientSignUp.Name,
                Password = ClientSignUp.Password
            };
            
            //var client = _mapper.Map<Client>(ClientSignUp);

            return _clientService.SignUp(client);
        }
        
        [HttpPost("/sign_up")]
        public Task<Guid> SignUpTutor(TutorSignUpDto TutorSignUp)
        {
            var tutor = new Tutor
            {
                Id = Guid.NewGuid(),
                Login = TutorSignUp.Login,
                Name = TutorSignUp.Name,
                Password = TutorSignUp.Password
            };
            
            //var tutor = _mapper.Map<Tutor>(TutorSignUp);

            return _tutorService.SignUp(tutor);
        }
        
        [HttpPatch("/sign_in")]
        public Task<Guid> SignInClient(ClientSignInDto ClientSignIn)
        {
            var client = _mapper.Map<Client>(ClientSignIn);

            return _clientService.SignIn(client);
        }
        
        [HttpPatch("/sign_in")]
        public Task<Guid> SignInTutor(TutorSignInDto TutorSignIn)
        {
            
            var tutor = _mapper.Map<Tutor>(TutorSignIn);

            return _tutorService.SignIn(tutor);
        }
    }
}