using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TutorProject.Account.BLL.Chats.Data;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Chats.Services
{
    public interface IChatService
    {
        Task<List<Chat>> GetChatsForClient(Guid clientID);
        Task<List<Chat>> GetChatsForTutor(Guid tutorID);
        Task<Chat> GetChatByID(Guid chatID);
        Task CreateChat(CreateChatData createChatData);
    }
}