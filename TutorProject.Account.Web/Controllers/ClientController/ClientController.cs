using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.BLL.Clients.Services;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.ClientController.Data;
using TutorProject.Account.Web.Controllers.ClientController.Dto;

namespace TutorProject.Account.Web.Controllers.ClientController
{
    [Controller]
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
        public Task<Guid> SignUpClient(ClientSignUpDto ClientSignUp)
        {
            var clientData = _mapper.Map<ClientSignUpData>(ClientSignUp);

            return _clientService.SignUp(clientData);
        }

        [HttpPatch("/sign_in")]
        public Task<Guid> SignInClient(ClientSignInDto ClientSignIn)
        {
            var clientData = _mapper.Map<ClientSignInData>(ClientSignIn);

            return _clientService.SignIn(clientData);
        }
    }
}