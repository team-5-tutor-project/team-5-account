using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.BLL.Tutors.Services;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.TutorController.Data;
using TutorProject.Account.Web.Controllers.TutorController.Dto;

namespace TutorProject.Account.Web.Controllers.TutorController
{
    [Controller]
    public class TutorController : Controller
    {
        private readonly TutorContext _tutorContext;
        private readonly ITutorService _tutorService;
        private readonly IMapper _mapper;
        
        public TutorController(TutorContext tutorContext)
        {
            _tutorContext = tutorContext;
        }

        [HttpPost("/sign_up")]
        public Task<Guid> SignUpTutor(TutorSignUpDto TutorSignUp)
        {
            var clientData = _mapper.Map<TutorSignUpData>(TutorSignUp);

            return _tutorService.SignUp(clientData);
        }

        [HttpPatch("/sign_in")]
        public Task<Guid> SignInTutor(TutorSignInDto TutorSignIn)
        {
            var clientData = _mapper.Map<TutorSignInData>(TutorSignIn);

            return _tutorService.SignIn(clientData);
        }
    }
}