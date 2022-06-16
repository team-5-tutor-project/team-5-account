using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.BLL.Tutors.Data;
using TutorProject.Account.BLL.Tutors.Result;
using TutorProject.Account.BLL.Tutors.Services;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.TutorController.Data;
using TutorProject.Account.Web.Controllers.TutorController.Dto;

namespace TutorProject.Account.Web.Controllers.TutorController
{
    [Controller]
    [Route("api/tutors")]
    public class TutorController : Controller
    {
        private readonly ITutorService _tutorService;
        private readonly IMapper _mapper;
        
        public TutorController(ITutorService tutorService, IMapper mapper)
        {
            _tutorService = tutorService;
            _mapper = mapper;
        }

        [HttpPost("sign_up")]
        public async Task<ActionResult<TutorLogInResult>> SignUpTutor([FromBody] TutorSignUpDto TutorSignUp)
        {
            var tutorData = _mapper.Map<TutorSignUpData>(TutorSignUp);
            var tutor = await _tutorService.SignUp(tutorData);

            if (tutor == null)
                return BadRequest();

            return _mapper.Map<TutorLogInResult>(tutor);
        }

        [HttpPatch("sign_in")]
        public async Task<ActionResult<TutorLogInResult>> SignInTutor([FromBody] TutorSignInDto TutorSignIn)
        {
            var tutorData = _mapper.Map<TutorSignInData>(TutorSignIn);
            var tutor = await _tutorService.SignIn(tutorData);

            if (tutor == null)
                return BadRequest("Неверный логин или пароль");

            return _mapper.Map<TutorLogInResult>(tutor);
        }

        [HttpPatch("{tutorId:guid}")]
        public async Task ChangeDescription(Guid tutorId, [FromBody] ChangeDescriptionDto changeDescriptionDto)
        {
            var changeDescriptionData = _mapper.Map<ChangeDescriptionData>(changeDescriptionDto);
            await _tutorService.ChangeDescription(tutorId, changeDescriptionData);
        }
    }
}