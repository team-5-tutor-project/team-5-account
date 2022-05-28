using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.ClientController.Data;

namespace TutorProject.Account.BLL.Clients.Services
{
    public class ClientService : IClientService
    {
        private List<Client> _clients;

        public async Task<Guid> SignUp(ClientSignUpData clientData)
        {
            var client = new Client()
            {
                Id = Guid.NewGuid(),
                Login = clientData.Login,
                Name = clientData.Name,
                Password = clientData.Password
            };
            //заглушка
            return client.Id;
        }

        public async Task<Guid> SignIn(ClientSignInData clientData)
        {
            //заглушка
            return Guid.NewGuid();
        }
    }
}