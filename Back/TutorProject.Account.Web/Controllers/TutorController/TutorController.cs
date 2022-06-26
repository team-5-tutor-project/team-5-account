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
        [SwaggerOperation(Summary = "Зарегистрироваться как репетитор")]
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
        public async Task<ActionResult<TutorDto>> GetByToken(string token)
        {
            var user = await _authorizationService.GetUserByToken(token);
            
            if (user is null or not Tutor)
                return BadRequest("Не найден репетитор с указанным токеном авторизации");

            return _mapper.Map<TutorDto>((Tutor)user);
        }
        
        [HttpPatch]
        [SwaggerOperation(Summary = "Изменить описание репетитора")]
        public async Task<ActionResult> ChangeDescription(
            [FromBody] ChangeDescriptionDto changeDescriptionDto, 
            string token)
        {
            var checkResult = await _authorizationService.CheckRights(token);
            
            if (!checkResult.IsSuccessful)
                return BadRequest(checkResult.ErrorMessage);

            if (checkResult.AuthorizedUser is not Tutor)
                return BadRequest("Операция недоступна");
            
            var changeDescriptionData = _mapper.Map<ChangeDescriptionData>(changeDescriptionDto);
            await _tutorService.ChangeDescription(checkResult.AuthorizedUser.Id, changeDescriptionData);
            return Ok();
        }
        
        [HttpGet("{tutorID}/name")]
        [SwaggerOperation(Summary = "Получить имя репетитора по ID")]
        public async Task<ActionResult<TutorNameDto>> GetTutorName([FromRoute]Guid tutorID)
        {
            var name = await _tutorService.GetName(tutorID);
            
            if (name is null)
                return BadRequest("Не найдено имя репетитора");

            TutorNameDto tutorNameDto = new TutorNameDto()
            {
                Name = name
            };

            return tutorNameDto;
        }
    }
}