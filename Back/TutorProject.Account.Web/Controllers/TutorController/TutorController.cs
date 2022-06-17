using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TutorProject.Account.BLL.Authorization;
using TutorProject.Account.BLL.Tutors.Data;
using TutorProject.Account.BLL.Tutors.Services;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.Authorization.Dto;
using TutorProject.Account.Web.Controllers.TutorController.Dto;

namespace TutorProject.Account.Web.Controllers.TutorController
{
    [Controller]
    [Route("api/tutors")]
    public class TutorController : Controller
    {
        private readonly ITutorService _tutorService;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public TutorController(ITutorService tutorService, IMapper mapper, IAuthorizationService authorizationService)
        {
            _tutorService = tutorService;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        [HttpPost("sign_up")]
        public async Task<ActionResult<AuthorizationResponseDto>> SignUpClient([FromBody] TutorSignUpDto TutorSignUp)
        {
            var tutorData = _mapper.Map<TutorSignUpData>(TutorSignUp);
            var tutor = await _tutorService.SignUp(tutorData);

            if (tutor == null)
                return BadRequest();

            var authorizationToken = await _authorizationService.Authorize(tutor);

            return new AuthorizationResponseDto
            {
                AuthorizationToken = authorizationToken.Token
            };
        }
        
        [HttpGet]
        [SwaggerOperation(Summary = "Получить репетитора по токену")]
        public async Task<ActionResult<TutorDto>> GetByToken(string authorizationToken)
        {
            var user = await _authorizationService.GetUserByToken(authorizationToken);
            
            if (user is null or not Tutor)
                return BadRequest("Не найден репетитор с указанным токеном авторизации");

            return _mapper.Map<TutorDto>((Tutor)user);
        }
        
        [HttpPatch("{tutorId:guid}")]
        [SwaggerOperation(Summary = "Изменить описание репетитора")]
        public async Task ChangeDescription(Guid tutorId, [FromBody] ChangeDescriptionDto changeDescriptionDto)
        {
            var changeDescriptionData = _mapper.Map<ChangeDescriptionData>(changeDescriptionDto);
            await _tutorService.ChangeDescription(tutorId, changeDescriptionData);
        }
    }
}