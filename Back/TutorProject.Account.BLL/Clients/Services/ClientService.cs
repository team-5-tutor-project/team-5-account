using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TutorProject.Account.BLL.Clients.Data;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Clients.Services
{
    public class ClientService : IClientService
    {
        private readonly TutorContext _context;

        public ClientService(TutorContext context)
        {
            _context = context;
        }

        public async Task<string> GetName(Guid clientID)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(client => client.Id == clientID);
            return client?.Name;
        }

        public async Task<Client> SignUp(ClientSignUpData clientData)
        {
            var isExists = await _context.Clients.AnyAsync(client => client.Login == clientData.Login);

            if (isExists)
            {
                return null;
            }

            var client = new Client()
            {
                Id = Guid.NewGuid(),
                Login = clientData.Login,
                Name = clientData.Name,
                Password = clientData.Password
            };

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return client;
        }
    }
}