using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TutorProject.Account.BLL.Authorization;
using TutorProject.Account.BLL.Users;
using TutorProject.Account.Web.Controllers.Authorization.Dto;

namespace TutorProject.Account.Web.Controllers.Authorization
{
    [Controller]
    [Route("api/authorization")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserService _userService;

        public AuthorizationController(IAuthorizationService authorizationService, IUserService userService)
        {
            _authorizationService = authorizationService;
            _userService = userService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Авторизоваться по логину и паролю (получить токен)")]
        public async Task<ActionResult<AuthorizationResponseDto>> Authorize([FromBody] AuthorizationRequestDto dto)
        {
            var user = await _userService.Authenticate(dto.Login, dto.Password);

            if (user is null)
                return BadRequest("Неверный логин или пароль.");

            var token = await _authorizationService.Authorize(user);
            
            return new AuthorizationResponseDto
            {
                AuthorizationToken = token.Token
            };
        }
        
        [HttpGet]
        [SwaggerOperation(Summary = "Получить ID и тип пользователя по токену авторизации")]
        public async Task<ActionResult<AuthorizedUserDto>> GetAuthorizedUser(string token)
        {
            var user = await _authorizationService.GetUserByToken(token);
            
            if (user is null)
                return BadRequest("Не удалось найти авторизованного пользователя либо токен авторизации устарел.");

            return new AuthorizedUserDto
            {
                UserId = user.Id,
                UserType = user.Discriminator
            };
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Прервать авторизацию по токену")]
        public async Task<ActionResult> CancelAuthorization(string token)
        {
            await _authorizationService.CancelAuthorization(token);

            return Ok();
        }
    }
}