using System;
using System.Threading.Tasks;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Clients.Services
{
    public interface IClientService
    {
        Task<Guid> SignUp(Client client);
        Task<Guid> SignIn(Client client);
    }
}