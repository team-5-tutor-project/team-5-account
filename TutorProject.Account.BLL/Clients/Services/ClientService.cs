using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using TutorProject.Account.BLL.Clients.Data;
using TutorProject.Account.BLL.Clients.Dto;
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

        public async Task<ClientLogInDto> SignUp(ClientSignUpData clientData)
        {
            var isExists = _context.Clients.AnyAsync(client => client.Login == clientData.Login);

            if (isExists.Result)
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

            _context.Clients.AddAsync(client);
            _context.SaveChangesAsync();
            
            var clientLogIn = _mapper.Map<ClientLogInDto>(client);
            
            return clientLogIn;
        }

        public async Task<ClientLogInDto> SignIn(ClientSignInData clientData)
        {
            var isExists = _context.Clients.AnyAsync(client => client.Login == clientData.Login &&
                                                               client.Password == clientData.Password);
            if (!isExists.Result)
            {
                return null;
            }

            var client = _context.Clients.FindAsync(clientData.Login);
                
            var clientLogIn = _mapper.Map<ClientLogInDto>(client);    
                
            return clientLogIn;
        }
    }
}