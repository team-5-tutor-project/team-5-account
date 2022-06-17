using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.BLL.Authorization;
using TutorProject.Account.BLL.Clients.Data;
using TutorProject.Account.BLL.Clients.Services;
using TutorProject.Account.Web.Controllers.Authorization.Dto;
using TutorProject.Account.Web.Controllers.ClientController.Dto;

namespace TutorProject.Account.Web.Controllers.ClientController
{
    [Controller]
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        
        public ClientController(IClientService clientService, IMapper mapper, IAuthorizationService authorizationService)
        {
            _clientService = clientService;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        [HttpPost("sign_up")]
        public async Task<ActionResult<AuthorizationResponseDto>> SignUpClient([FromBody] ClientSignUpDto ClientSignUp)
        {
            var clientData = _mapper.Map<ClientSignUpData>(ClientSignUp);
            var client = await _clientService.SignUp(clientData);

            if (client == null)
                return BadRequest();

            var authorizationToken = await _authorizationService.Authorize(client);

            return new AuthorizationResponseDto
            {
                AuthorizationToken = authorizationToken.Token
            };
        }
    }
}