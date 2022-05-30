using System;
using System.Threading.Tasks;
using TutorProject.Account.BLL.Clients.Data;
using TutorProject.Account.BLL.Clients.Result;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.ClientController.Data;

namespace TutorProject.Account.BLL.Clients.Services
{
    public interface IClientService
    {
        Task<ClientLogInDto> SignUp(ClientSignUpData clientData);
        Task<ClientLogInDto> SignIn(ClientSignInData clientData);
    }
}