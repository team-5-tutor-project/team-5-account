using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TutorProject.Account.BLL.Authorization;
using TutorProject.Account.BLL.Chats.Data;
using TutorProject.Account.BLL.Chats.Services;
using TutorProject.Account.Web.Controllers.ChatController.Dto;

namespace TutorProject.Account.Web.Controllers.ChatController
{
    [Controller]
    [Route("api/chats")]
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        public ChatController(IChatService chatService, IMapper mapper, IAuthorizationService authorizationService)
        {
            _chatService = chatService;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }
        
        [HttpPost]
        [SwaggerOperation(Summary = "Создать чат")]
        public async Task<ActionResult> CreateChat([FromBody] CreateChatDTO createChatDto, string authorizationToken)
        {
            var checkResult = await _authorizationService.CheckRights(authorizationToken, createChatDto.ClientID, createChatDto.TutorID);

            if (!checkResult.IsSuccessful)
                return BadRequest(checkResult.ErrorMessage);
            
            var createChatData = _mapper.Map<CreateChatData>(createChatDto);
            await _chatService.CreateChat(createChatData);

            return Ok();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Получить список чатов для пользователя по токену авторизации")]
        public async Task<ActionResult<List<ChatDto>>> FindChatsByToken(string authorizationToken)
        {
            var checkResult = await _authorizationService.CheckRights(authorizationToken);

            if (!checkResult.IsSuccessful)
                return BadRequest(checkResult.ErrorMessage);
            
            var result = await _chatService.GetChatsByUserId(checkResult.AuthorizedUser.Id);
            return _mapper.Map<List<ChatDto>>(result);
        }

        [HttpGet("{chatID}")]
        [SwaggerOperation(Summary = "Получить чат по ID")]
        public async Task<ActionResult<ChatDto>> FindChatByID([FromRoute] Guid chatID, string authorizationToken)
        {
            var chat = await _chatService.GetChatByID(chatID);
            
            var checkResult = await _authorizationService.CheckRights(authorizationToken, chat.Client.Id, chat.Tutor.Id);
            if (!checkResult.IsSuccessful)
                return BadRequest(checkResult.ErrorMessage);
            
            return _mapper.Map<ChatDto>(chat);
        }
    }
}