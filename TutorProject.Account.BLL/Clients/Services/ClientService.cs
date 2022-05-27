using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Clients.Services
{
    public class ClientService : IClientService
    {
        private List<Client> _clients;

        public async Task<Guid> SignUp(Client client)
        {
            //заглушка
            return client.Id;
        }

        public async Task<Guid> SignIn(Client client)
        {
            //заглушка
            return client.Id;
        }
    }
}