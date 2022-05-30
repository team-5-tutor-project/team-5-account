using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.BLL.Tutors.Data;
using TutorProject.Account.BLL.Tutors.Dto;
using TutorProject.Account.BLL.Tutors.Services;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.TutorController.Data;
using TutorProject.Account.Web.Controllers.TutorController.Dto;

namespace TutorProject.Account.Web.Controllers.TutorController
{
    [Controller]
    [Route("api/TutorController")]
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
        public Task<TutorLogInDto> SignUpTutor(TutorSignUpDto TutorSignUp)
        {
            var tutorData = _mapper.Map<TutorSignUpData>(TutorSignUp);
            var tutorDto = _tutorService.SignUp(tutorData);

            if (tutorDto == null)
            {
                throw new Exception(BadRequest().ToString());
            }

            return tutorDto;
        }

        [HttpPatch("/sign_in")]
        public Task<TutorLogInDto> SignInTutor(TutorSignInDto TutorSignIn)
        {
            var tutorData = _mapper.Map<TutorSignInData>(TutorSignIn);
            var tutorDto = _tutorService.SignIn(tutorData);

            if (tutorDto == null)
            {
                throw new Exception(BadRequest().ToString());
            }

            return tutorDto;
        }
    }
}