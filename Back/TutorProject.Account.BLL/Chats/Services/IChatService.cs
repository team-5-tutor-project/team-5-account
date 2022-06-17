using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TutorProject.Account.BLL.Chats.Data;
using TutorProject.Account.Common.Models;

namespace TutorProject.Account.BLL.Chats.Services
{
    public interface IChatService
    {
        Task<List<Chat>> GetChatsByUserId(Guid userId);
        Task<Chat> GetChatByID(Guid chatID);
        Task CreateChat(CreateChatData createChatData);
    }
}