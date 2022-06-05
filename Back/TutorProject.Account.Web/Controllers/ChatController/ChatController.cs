using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TutorProject.Account.BLL.Chats.Data;
using TutorProject.Account.BLL.Chats.Services;
using TutorProject.Account.Common.Models;
using TutorProject.Account.Web.Controllers.ChatController.Dto;

namespace TutorProject.Account.Web.Controllers.ChatController
{
    [Controller]
    [Route("api/chats")]
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;
        public ChatController(IChatService chatService, IMapper mapper)
        {
            _chatService = chatService;
            _mapper = mapper;
        }
        
        [HttpPost()]
        public async Task CreateChat(CreateChatDTO createChatDto)
        {
            var createChatData = _mapper.Map<CreateChatData>(createChatDto);
            await _chatService.CreateChat(createChatData);
        }

        [HttpGet("tutors/{tutorID}/chats")]
        public async Task<List<ChatDto>> FindChatsForTutor(Guid tutorID)
        {
            var result = await _chatService.GetChatsForTutor(tutorID);
            return _mapper.Map<List<ChatDto>>(result);
        }
        
        [HttpGet("clients/{clientID}/chats")]
        public async Task<List<ChatDto>> FindChatsForClient(Guid clientID)
        {
            var result = await _chatService.GetChatsForClient(clientID);
            return _mapper.Map<List<ChatDto>>(result);
        }

        [HttpGet("{chatID}")]
        public async Task<ChatDto> FindChatByID(Guid chatID)
        {
            var result = await _chatService.GetChatByID(chatID);
            return _mapper.Map<ChatDto>(result);
        }
    }
}