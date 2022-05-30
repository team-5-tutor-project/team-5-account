using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using TutorProject.Account.BLL.Clients.Data;
using TutorProject.Account.BLL.Clients.Result;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.ClientController.Data;
using TutorProject.Account.Web.Controllers.TutorController.Data;

namespace TutorProject.Account.BLL.Clients.Services
{
    public class ClientService : IClientService
    {
        private readonly TutorContext _context;
        private readonly Mapper _mapper;

        public async Task<ClientLogInResult> SignUp(ClientSignUpData clientData)
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
            
            var clientLogIn = _mapper.Map<ClientLogInResult>(client);
            
            return clientLogIn;
        }

        public async Task<ClientLogInResult> SignIn(ClientSignInData clientData)
        {
            var isExists = await _context.Clients.AnyAsync(client => client.Login == clientData.Login &&
                                                                     client.Password == clientData.Password);
            if (!isExists)
            {
                return null;
            }

            var client = await _context.Clients.FindAsync(clientData.Login);
                
            var clientLogIn = _mapper.Map<ClientLogInResult>(client);    
                
            return clientLogIn;
        }
    }
}