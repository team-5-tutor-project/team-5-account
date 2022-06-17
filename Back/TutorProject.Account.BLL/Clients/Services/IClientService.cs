using System.Threading.Tasks;
using TutorProject.Account.BLL.Clients.Data;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Clients.Services
{
    public interface IClientService
    {
        Task<Client> SignUp(ClientSignUpData clientData);
    }
}