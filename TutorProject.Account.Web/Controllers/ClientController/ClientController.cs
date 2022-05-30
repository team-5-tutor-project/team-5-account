using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.BLL.Clients.Data;
using TutorProject.Account.BLL.Clients.Dto;
using TutorProject.Account.BLL.Clients.Services;
using TutorProject.Account.Common;
using TutorProject.Account.Web.Controllers.ClientController.Data;
using TutorProject.Account.Web.Controllers.ClientController.Dto;

namespace TutorProject.Account.Web.Controllers.ClientController
{
    [Controller]
    [Route("client")]
    public class ClientController : Controller
    {
        private readonly TutorContext _tutorContext;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        
        public ClientController(TutorContext tutorContext)
        {
            _tutorContext = tutorContext;
        }

        [HttpPost("/sign_up")]
        public Task<ClientLogInDto> SignUpClient(ClientSignUpDto ClientSignUp)
        {
            var clientData = _mapper.Map<ClientSignUpData>(ClientSignUp);
            var clientDto = _clientService.SignUp(clientData);

            if (clientDto == null)
            {
                throw new Exception(BadRequest().ToString());
            }

            return clientDto;
        }

        [HttpPatch("/sign_in")]
        public Task<ClientLogInDto> SignInClient(ClientSignInDto ClientSignIn)
        {
            var clientData = _mapper.Map<ClientSignInData>(ClientSignIn);
            var clientDto = _clientService.SignIn(clientData);

            if (clientDto == null)
            {
                throw new Exception(BadRequest().ToString());
            }

            return clientDto;
        }
    }
}