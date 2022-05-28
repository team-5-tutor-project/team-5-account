using System;
using System.Threading.Tasks;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.ClientController.Data;

namespace TutorProject.Account.BLL.Clients.Services
{
    public interface IClientService
    {
        Task<Guid> SignUp(ClientSignUpData clientData);
        Task<Guid> SignIn(ClientSignInData clientData);
    }
}