using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.BLL.Clients.Data;
using TutorProject.Account.BLL.Clients.Result;
using TutorProject.Account.BLL.Clients.Services;
using TutorProject.Account.Common;
using TutorProject.Account.Web.Controllers.ClientController.Data;
using TutorProject.Account.Web.Controllers.ClientController.Dto;

namespace TutorProject.Account.Web.Controllers.ClientController
{
    [Controller]
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        
        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpPost("sign_up")]
        public async Task<ActionResult<ClientLogInResult>> SignUpClient([FromBody] ClientSignUpDto ClientSignUp)
        {
            var clientData = _mapper.Map<ClientSignUpData>(ClientSignUp);
            var client = await _clientService.SignUp(clientData);

            if (client == null)
                return BadRequest();

            return _mapper.Map<ClientLogInResult>(client);
        }

        [HttpPatch("sign_in")]
        public async Task<ActionResult<ClientLogInResult>> SignInClient([FromBody] ClientSignInDto ClientSignIn)
        {
            var clientData = _mapper.Map<ClientSignInData>(ClientSignIn);
            var client = await _clientService.SignIn(clientData);

            if (client == null)
                return BadRequest("Неверный логин или пароль");

            return _mapper.Map<ClientLogInResult>(client);
        }
    }
}