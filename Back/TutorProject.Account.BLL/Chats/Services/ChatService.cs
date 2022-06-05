using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TutorProject.Account.BLL.Chats.Data;
using TutorProject.Account.Common;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Chats.Services
{
    public class ChatService : IChatService
    {
        private readonly TutorContext _tutorContext;

        public ChatService(TutorContext tutorContext)
        {
            _tutorContext = tutorContext;
            _tutorContext.Chats
                .Include(chat => chat.Tutor)
                .Include(chat => chat.Client)
                .Load();
        }
        
        public async Task<List<Chat>> GetChatsForClient(Guid clientID)
        {
            Client client = await _tutorContext.Clients.SingleOrDefaultAsync(x => x.Id == clientID);

            var chats = await _tutorContext.Chats.Where(x => x.Client == client).ToListAsync();
            
            return chats;
        }

        public async Task<List<Chat>> GetChatsForTutor(Guid tutorID)
        {
            Tutor tutor = await _tutorContext.Tutors.SingleOrDefaultAsync(x => x.Id == tutorID);

            var chats = await _tutorContext.Chats.Where(x => x.Tutor == tutor).ToListAsync();
            
            return chats;
        }

        public async Task<Chat> GetChatByID(Guid chatID)
        {
            Chat chat = await _tutorContext.Chats.SingleOrDefaultAsync(x => x.ChatId == chatID);
            return chat;
        }

        public async Task CreateChat(CreateChatData createChatData)
        {
            Client client = await _tutorContext.Clients.SingleOrDefaultAsync(x => x.Id == createChatData.ClientID);
            Tutor tutor = await _tutorContext.Tutors.SingleOrDefaultAsync(x => x.Id == createChatData.TutorID);
            Chat chat = new Chat() {ChatId = createChatData.ChatID, Client = client, Tutor = tutor};
            await _tutorContext.Chats.AddAsync(chat);
            await _tutorContext.SaveChangesAsync();
        }
    }
}